using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheTimeMinute;
        ICacheManager _cacheManager;

        public CacheAspect(Type cacheType,int cacheTimeMinute=60)
        {
            _cacheType = cacheType;
            _cacheTimeMinute = cacheTimeMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                 throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var key = args.Method.ReflectedType.Namespace + "." + args.Method.ReflectedType.Name/* + "." + args.Method.Name*/;
            
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            else
            {
                _cacheManager.Add(key, args.ReturnValue, _cacheTimeMinute);
            }
            base.OnInvoke(args);
        }
    }
}

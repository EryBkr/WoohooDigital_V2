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
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private Type _cacheType;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            string key = args.Method.ReflectedType.Namespace + "." + args.Method.ReflectedType.Name;
            _cacheManager.Remove(key);
            base.OnSuccess(args);
        }
    }
}

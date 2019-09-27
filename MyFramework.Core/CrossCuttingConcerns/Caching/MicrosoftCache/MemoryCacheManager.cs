using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Core.CrossCuttingConcerns.Caching.MicrosoftCache
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }


        public void Add(string key, object data, int cacheTime=60)
        {
            if (data==null)
            {
                return;
            }
            var policy = new CacheItemPolicy() {AbsoluteExpiration=DateTime.Now+TimeSpan.FromMinutes(cacheTime)};
            Cache.Add(new CacheItem(key, data), policy);

        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Cache.Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
    }
}

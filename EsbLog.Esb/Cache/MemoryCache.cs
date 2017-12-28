using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Cache
{
    public class EsbMemoryCache : MemoryCache ,ICache
    {
        public EsbMemoryCache(string name) :base(name){}

        public void Set<T>(string key, T value)
        {
            base.Set(key, value, new CacheItemPolicy { SlidingExpiration = TimeSpan.FromDays(1) });
        }

        public void Set<T>(string key, T value, DateTime expireAt)
        {
            base.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = expireAt });
        }

        public void Set<T>(string key, T value, TimeSpan expiry)
        {
            base.Set(key, value, new CacheItemPolicy { SlidingExpiration = expiry });
        }

        public T Get<T>(string key)
        {
            var value = base.Get(key);
            if (value == null)
            {
                return default(T);
            }
            else
            {
                return (T)value;
            }
        }

        public void Remove(string key)
        {
            base.Remove(key);
        }

        public bool HasKey(string key)
        {
            return base.Contains(key);
        }
    }
}

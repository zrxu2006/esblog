using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Cache
{
    public interface ICache
    {
        void Set<T>(string key, T value);
        void Set<T>(string key, T value, DateTime expireAt);
        void Set<T>(string key, T value, TimeSpan expiry);

        T Get<T>(string key);

        void Remove(string key);

        bool HasKey(string key);
    }
}

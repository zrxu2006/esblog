using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Platform.Database
{
    public class PlatformDbFactory
    {
        IConnectionString _connectionString;
        public PlatformDbFactory(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public PlatformDBContext GetPlatformDb()
        {
            return new PlatformDBContext(_connectionString.ConnectionString);
        }
    }
}

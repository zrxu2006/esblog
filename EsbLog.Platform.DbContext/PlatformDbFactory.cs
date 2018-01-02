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

        public PlatformDbContext GetPlatformDb()
        {
            return new PlatformDbContext(_connectionString.ConnectionString);
        }
    }
}

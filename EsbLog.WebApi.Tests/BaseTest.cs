using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.WebApi.Tests
{
    public class BaseTest
    {
        public PlatformDbFactory DBFactory = new PlatformDbFactory(new PlatformConnectionStringProvider());

    }
}

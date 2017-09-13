using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EsbLog.Platform.Database.UnitTest
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void TestConnectionString()
        {
            IConnectionString con = new PlatformConnectionStringProvider();
            var dbFactory = new PlatformDbFactory(con);
            using (var db = dbFactory.GetPlatformDb())
            {
                int count = db.Apps.Count();
                count = db.Permissions.Count();
            }
        }
    }
}

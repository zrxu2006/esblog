using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Platform.Database;
using System.Data.Entity;
using EsbLog.Domain.Platform;
using System.Linq;

namespace EsbLog.WebApi.Tests.Database
{
    [TestClass]
    public class UnitTestDbFactory
    {
        [TestMethod]
        public void TestDbFactory()
        {
            PlatformDbFactory factory = new PlatformDbFactory(new PlatformConnectionStringProvider());

            using (var db = factory.GetPlatformDb())
            {
                int dbcount = db.Apps.Count();
                db.Apps.Add(new App
                {
                    Name = "AppName1",
                    Code = "AppCode1",
                    Description = "AppDescription1",
                    PublicKey = Guid.NewGuid().ToString()
                });
                db.SaveChanges();
            }
        }
    }
}

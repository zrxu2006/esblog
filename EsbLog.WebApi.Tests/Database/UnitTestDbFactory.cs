using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Platform.Database;
using System.Data.Entity;
using EsbLog.Domain.Platform;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        [TestMethod]
        public void TestPermissionApp()
        {
            PlatformDbFactory factory = new PlatformDbFactory(new PlatformConnectionStringProvider());

            using (var db = factory.GetPlatformDb())
            {
                string password = "Test1";
                MD5 md5 = MD5.Create();
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var md5String = Convert.ToBase64String(bytes);

                var newUser = new LoginUser
                {
                    LoginName = "Test1",
                    Password = md5String,
                    UserType = "U"
                };

                newUser.Apps.Add(
                db.Apps.FirstOrDefault());

                db.Users.Add(newUser);
                db.SaveChanges();

            }
        }
    }
}

using EsbLog.Domain.Platform;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EsbLog.Web.Repository.Concrete
{
    public class AppManagerRepository : IAppManagerRepository
    {
        PlatformDbFactory _factory;
        public AppManagerRepository(PlatformDbFactory dbFactory)
        {
            _factory = dbFactory;            
        }
        
        #region MockData

        private static List<App> _appList = new List<App>();

        static AppManagerRepository()
        {
            _appList.Add(new App
            {
                AppId = 1,
                Code = "App01",
                Description = "App 01 Description",
                Name = "App Name 01",
                PublicKey = Guid.NewGuid().ToString()
            });

            _appList.Add(new App
            {
                AppId = 2,
                Code = "App02",
                Description = "App 02 Description",
                Name = "App Name 02",
                PublicKey = Guid.NewGuid().ToString()
            });

            _appList.Add(new App
            {
                AppId = 3,
                Code = "App03",
                Description = "App 03 Description",
                Name = "App Name 03",
                PublicKey = Guid.NewGuid().ToString()
            });

            _appList.Add(new App
            {
                AppId = 4,
                Code = "App04",
                Description = "App 04 Description",
                Name = "App Name 04",
                PublicKey = Guid.NewGuid().ToString()
            });

            _appList.Add(new App
            {
                AppId = 5,
                Code = "App05",
                Description = "App 05 Description",
                Name = "App Name 05",
                PublicKey = Guid.NewGuid().ToString()
            });

            _appList.Add(new App
            {
                AppId = 6,
                Code = "App06",
                Description = "App 06 Description",
                Name = "App Name 06",
                PublicKey = Guid.NewGuid().ToString()
            });
        }

        #endregion
        public bool AddApp(App app)
        {
            using (var db = _factory.GetPlatformDb())
            {
                db.Apps.Add(app);
                db.SaveChanges();
            }
            return true;
        }

        public IEnumerable<App> FindAllApps()
        {
            using (var db = _factory.GetPlatformDb())
            {
                return db.Apps
                    .Include(a=> a.Users)
                    .ToList();
            }
        }

        public IEnumerable<App> FindApp(Predicate<App> filter)
        {
            using (var db = _factory.GetPlatformDb())
            {
                return db.Apps
                    .Include(a=>a.Users)
                    .Where(a => filter(a)).ToList();
            }
        }

        public bool IsExist(string appcode)
        {
            using (var db = _factory.GetPlatformDb())
            {
                return db.Apps.FirstOrDefault(a => a.Code == appcode)!= null;
            }
        }

        public bool EditApp(App app)
        {
            using (var db = _factory.GetPlatformDb())
            {
                var editApp = db.Apps.FirstOrDefault(a=> a.AppId==app.AppId);

                editApp.Code = app.Code;
                editApp.Description = app.Description;
                editApp.Name = app.Name;
                editApp.PublicKey = app.PublicKey;
                db.SaveChanges();                
            }

            return true;
        }
    }
}

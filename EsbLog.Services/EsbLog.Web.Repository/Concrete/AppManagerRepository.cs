using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository.Concrete
{
    public class AppManagerRepository : IAppManagerRepository
    {
        #region MockData

        private static List<App> _appList = new List<App>();
        public AppManagerRepository() { }
        static AppManagerRepository()
        {
            _appList.Add(new App
            {
                AppId = 1,
                Code = "App01",
                Description = "App 01 Description",
                Name = "App Name 01",
                PublicKey = Guid.NewGuid()
            });

            _appList.Add(new App
            {
                AppId = 2,
                Code = "App02",
                Description = "App 02 Description",
                Name = "App Name 02",
                PublicKey = Guid.NewGuid()
            });

            _appList.Add(new App
            {
                AppId = 3,
                Code = "App03",
                Description = "App 03 Description",
                Name = "App Name 03",
                PublicKey = Guid.NewGuid()
            });

            _appList.Add(new App
            {
                AppId = 4,
                Code = "App04",
                Description = "App 04 Description",
                Name = "App Name 04",
                PublicKey = Guid.NewGuid()
            });

            _appList.Add(new App
            {
                AppId = 5,
                Code = "App05",
                Description = "App 05 Description",
                Name = "App Name 05",
                PublicKey = Guid.NewGuid()
            });

            _appList.Add(new App
            {
                AppId = 6,
                Code = "App06",
                Description = "App 06 Description",
                Name = "App Name 06",
                PublicKey = Guid.NewGuid()
            });
        }
        
        #endregion
        public bool AddApp(App app)
        {
            _appList.Add(app);
            return true;
        }

        public IEnumerable<App> FindAllApps()
        {
            return _appList;
        }

        public IEnumerable<App> FindApp(Predicate<App> filter)
        {
            return _appList.Where(a => filter(a));
        }

        public bool IsExist(string appcode)
        {
            throw new NotImplementedException();
        }

        public bool EditApp(App app)
        {
            var appNew = _appList.FirstOrDefault(a => a.AppId == app.AppId);
            if (appNew == null)
            {
                _appList.Add(appNew);
            }
            else
            {
                _appList.Remove(appNew);
                _appList.Add(app);
            }

            return true;
        }
    }
}

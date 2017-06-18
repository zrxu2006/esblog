using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository
{
    public interface IAppManagerRepository
    {
        bool AddApp(App app);

        IEnumerable<App> FindAllApps();

        IEnumerable<App> FindApp(Predicate<App> filter);

        bool IsExist(string appcode);

        bool EditApp(App app);
    }
}

using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository
{
    public interface IPermissionRepository
    {
        IEnumerable<Permission> FindAll();
        IEnumerable<Permission> FindPermissions(Predicate<Permission> filter);
        bool Edit(Permission permission);
        bool Add(Permission permission);
    }
}

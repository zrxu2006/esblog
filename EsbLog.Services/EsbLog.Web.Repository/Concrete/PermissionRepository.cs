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
    public class PermissionRepository:IPermissionRepository
    {
        PlatformDbFactory _factory;
        public PermissionRepository(PlatformDbFactory dbFactory)
        {
            _factory = dbFactory;    
        }
        public IEnumerable<Permission> FindAll()
        {
            using (var db = _factory.GetPlatformDb())
            {
                return db.Permissions.ToList();
            }
        }

        public IEnumerable<Permission> FindPermissions(Predicate<Domain.Platform.Permission> filter)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Permission permission)
        {
            using (var db = _factory.GetPlatformDb())
            {
                var existingP = db.Permissions  
                                //.Include(p=>p.Apps)
                                .FirstOrDefault(p => p.PermissionId == permission.PermissionId);
                if (existingP == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    
                }

            }
            return true;
        }


        public bool Add(Permission permission)
        {
            using (var db = _factory.GetPlatformDb())
            {
                var app = db.Apps.FirstOrDefault();
                //permission.Apps.Add(app);
                db.Permissions.Add(permission);               

                db.SaveChanges();
            }
            return true;
        }
    }
}

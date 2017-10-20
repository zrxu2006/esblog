using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Platform
{
    public class Permission
    {
        public Permission()
        {
            //Apps = new HashSet<App>();
        }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string PermissionStatus { get; set; }
        //public virtual ICollection<App> Apps { get; set; }
    }
}

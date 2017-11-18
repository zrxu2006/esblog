using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class UserSessionModel
    {
        public UserSessionModel()
        {
            UserApps = new HashSet<App>();
        }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public bool IsManager { get; set; }
        public ICollection<App> UserApps { get; set; }
    }
}
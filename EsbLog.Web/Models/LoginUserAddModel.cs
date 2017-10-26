using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class LoginUserAddModel
    {
        public LoginUserAddModel()
        {
            AppList = new List<App>();
        }
        public string LoginName { get; set; }
        //public string Password { get; set; }
        public string AppIds { get; set; }

        public IEnumerable<App> AppList { get; set; }

    }
}
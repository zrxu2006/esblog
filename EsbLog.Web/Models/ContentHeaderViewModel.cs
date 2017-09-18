using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class ContentHeaderViewModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string HeaderName { get; set; }
        public HeaderLevelEnum HeaderLevel { get; set; }
    }

    public enum HeaderLevelEnum
    {
        Menu,
        SubMenu
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class HomeModel
    {
        public bool IsManager { get; set; }
        public int AppCount { get; set; }
        public int PermissionCount { get; set; }
        public int ExtensionCount { get; set; }
        public long LogCount { get; set; }
    }
}
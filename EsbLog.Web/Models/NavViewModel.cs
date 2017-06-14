using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class NavViewModel
    {
        public string NavName { get; set; }
        public string Category { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public IEnumerable<NavViewModel> NavItems { get; set; }
    }
}
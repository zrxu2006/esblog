using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace EsbLog.Web.Models
{
    public class ContentHeaderDisplayViewModel
    {
        public IEnumerable<ContentHeaderViewModel> Headers { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}
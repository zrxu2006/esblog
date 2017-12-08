using EsbLog.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class LogRequestModel : PagingRequest
    {
        public string AppIds { get; set; }
        public string LogLevels { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
using EsbLog.Domain.Log;
using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.Models
{
    public class LogModel
    {
        public LogModel()
        {
            Logs = new List<LogResultModel>();
            LogLevelNames = LogLevelExtention.GetLogLevelNames();
            Apps = new List<App>();
        }
        public IEnumerable<LogResultModel> Logs { get; set; }
        public IEnumerable<App> Apps { get; set; }
        public IEnumerable<string> LogLevelNames { get; set; }
        public string AppIds { get; set; }
        public string LogLevels { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class LogResultModel
    {
        public string AppName { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }

    public class PagingRequest<T>
    {
        public T Request { get; set; }
        public int PageSize { get; set; }
        public int Index { get; set; }
    }

    public class PagingResult<T>
    {
        public PagingResult()
        {
            Result = new HashSet<T>();
        }
    
        public ICollection<T> Result { get; set; }
        public int PageSize { get; set; }
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
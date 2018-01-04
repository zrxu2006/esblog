using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Log
{
    public class LogEntry
    {
        public long Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime? Creation { get; set; }
        public int AppId { get; set; }
        public virtual App App { get; set; }

    }
}

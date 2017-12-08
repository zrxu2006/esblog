using EsbLog.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogEntry>> GetLogsAsync(LogQueryRequest queryRequest);
    }
}

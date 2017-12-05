using EsbLog.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain
{
    public interface ILogRepository
    {
        //int Save(Log entity);
        //Task<int> SaveAsync(Log entity);
        Task<IEnumerable<LogEntry>> GetLogsAsync(LogQueryRequest queryRequest);
    }
}

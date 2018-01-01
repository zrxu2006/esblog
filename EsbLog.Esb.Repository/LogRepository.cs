using EsbLog.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Repository
{
    public class LogRepository:ILogRepository
    {
        public Task<bool> AddLog(LogEntry log)
        {
            string t = log.LogLevel;
            throw new NotImplementedException();
        }
    }
}

using EsbLog.Domain.Log;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Repository
{
    public class LogRepository:ILogRepository
    {
        IPlatformDbContext _context;
        public LogRepository(IPlatformDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddLog(LogEntry log)
        {
            string t = log.LogLevel;
            return Task.FromResult(true);
            //throw new NotImplementedException();
        }
    }
}

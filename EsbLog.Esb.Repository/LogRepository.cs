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
        PlatformDbFactory _factory;
        public LogRepository(PlatformDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<bool> AddLog(LogEntry log)
        {
            try
            {
                using (var db = _factory.GetPlatformDb())
                {
                    if (log != null)
                    {
                        log.Creation = log.Creation ?? DateTime.Now;
                        db.Logs.Add(log);
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
                
            return true;
        }
    }
}

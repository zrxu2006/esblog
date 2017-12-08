using EsbLog.Domain.Log;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EsbLog.Web.Repository.Concrete
{
    public class LogRepository:ILogRepository
    {
        PlatformDbFactory _factory;
        public LogRepository(PlatformDbFactory dbFactory)
        {
            _factory = dbFactory; 
        }
        public async Task<IEnumerable<LogEntry>> GetLogsAsync(LogQueryRequest queryRequest)
        {
            using (var db = _factory.GetPlatformDb())
            {
                var result = db.Logs
                                .Include(l => l.App);

                var appids = (queryRequest.AppIds??string.Empty).Split(',')
                                    .Select(s => ParseToInt(s))
                                    .Where(id=>id>0)
                                    .ToList();
                var levels = (queryRequest.LogLevels??string.Empty).Split(',')
                                    .Where(l => !string.IsNullOrEmpty(l))
                                    .ToList();

                if (appids.Count > 0)
                {
                    result.Where(l => appids.Contains(l.AppId));
                }
                if (levels.Count > 0)
                {
                    result.Where(l => levels.Contains(l.LogLevel
                                    , StringComparer.OrdinalIgnoreCase));
                }
                if (queryRequest.StartDate.HasValue)
                {
                    result.Where(l => l.Creation >= queryRequest.StartDate.Value);
                }
                if (queryRequest.EndDate.HasValue)
                {
                    result.Where(l => l.Creation < queryRequest.EndDate.Value.AddDays(1));
                }

                int pageSize = queryRequest.PageSize == 0 ? 10 :
                                queryRequest.PageSize;
                int pageIndex = (int)queryRequest.PageIndex;
                return await result.Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            }
        }

        private int ParseToInt(string id)
        {
            int idValue = 0;
            int.TryParse(id, out idValue);
            return idValue;
        }
    }
}

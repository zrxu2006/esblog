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
    public class LogRepository : ILogRepository
    {
        PlatformDbFactory _factory;
        public LogRepository(PlatformDbFactory dbFactory)
        {
            _factory = dbFactory;
        }
        public async Task<LogQueryResult> GetLogsAsync(LogQueryRequest queryRequest)
        {
            LogQueryResult returnResult = new LogQueryResult();

            using (var db = _factory.GetPlatformDb())
            {
                IQueryable<LogEntry> query = db.Logs.AsNoTracking()
                                            .Include(l=>l.App);

                var appids = (queryRequest.AppIds??string.Empty).Split(',')
                                    .Select(s => ParseToInt(s))
                                    .Where(id=>id>0)
                                    .ToList();
                var levels = (queryRequest.LogLevels??string.Empty).Split(',')
                                    .Where(l => !string.IsNullOrEmpty(l))
                                    .ToList();

                if(appids.Count>0)
                {
                    query = query.Where(l => appids.Contains(l.AppId));

                }

                if(levels.Count>0)
                {
                    query = query.Where(l => levels.Contains(l.LogLevel
                                    , StringComparer.OrdinalIgnoreCase));
                }

                if(queryRequest.StartDate.HasValue)
                {
                    query = query.Where(l => queryRequest.StartDate.HasValue
                                && l.Creation >= queryRequest.StartDate.Value);                   
                }

                if(queryRequest.EndDate.HasValue)
                {
                    DateTime endDate = queryRequest.EndDate.Value.AddDays(1);
                    query = query.Where(l=> queryRequest.EndDate.HasValue
                                && l.Creation < endDate);                  
                }
                      
                int pageSize = queryRequest.PageSize == 0 ? 10 :
                                queryRequest.PageSize;
                int pageIndex = (int)queryRequest.PageIndex;

                var list = query
                            .OrderBy(l => l.Creation)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToList();
                var count = query
                            .Count();
                               
                returnResult.PageIndex = queryRequest.PageIndex;
                returnResult.PageSize = queryRequest.PageSize;
                returnResult.Total = count;
                returnResult.ResultData = new HashSet<LogEntry>(list);

                return await Task.FromResult(returnResult);
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

using EsbLog.Api.App_Start;
using EsbLog.Domain.Platform;
using EsbLog.Esb.Cache;
using EsbLog.Esb.Message;
using EsbLog.Log4Net;
using EsbLog.Platform.Database;
using log4net;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EsbLog.Api.Controllers
{
    public class LogController : ApiController
    {
        ILog _log;
        IBus _bus;
        IPlatformDbContext _context;
        ICache _cache;
        const string APP_CACHE = "APP_CACHE";
        public LogController(ILog log,IBus bus,IPlatformDbContext context,ICache cache)
        {
            _log = log;
            _bus = bus;
            _context = context;
            _cache = cache;
        }

        [HttpPost]
        public async Task Post([FromBody]LogRequest value)
        {
            _log.Info("Post 开始");

            int appId = GetAppIdByCode(value.AppCode);

            if (appId > 0)
            {
                await _bus.Publish<ILogRequested>(new
                {
                    AppId = value.AppCode,
                    LogLevel = value.LogLevel,
                    Content = value.Message,
                    Time = value.Time
                });
            }
            else
            {
                _log.Error(string.Format("无效的AppCode:{0}", value.AppCode));
            }

            _log.Info("Post 结束");
        }

        private int GetAppIdByCode(string code)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(code))
            {
                var cachedApps = GetCachedApps();
                var app = cachedApps
                            .FirstOrDefault(c => 
                                    code.Equals(c.Code, 
                                    StringComparison.OrdinalIgnoreCase));
                if (app != null)
                {
                    id = app.AppId;
                }
            }
            
            return id;
        }

        private IEnumerable<App> GetCachedApps()
        {
            IEnumerable<App> cachedApps = new List<App>();
            if (!_cache.HasKey(APP_CACHE))
            {
                cachedApps = _context.Apps.ToList();
                _cache.Set(APP_CACHE, cachedApps);
            }
            else
            {
                cachedApps = _cache.Get<IEnumerable<App>>(APP_CACHE);
            }

            return cachedApps;
        }

        [HttpGet]
        public string Get(string id)
        {
            _log.Info("get" + id);
            _bus.Publish<ILogRequested>(new
            {
                AppId = 1,
                LogLevel = "DEBUG",
                Content = "TEST",
                Time = DateTime.Now
            }).GetAwaiter().GetResult();

            return id;
        }
        
        
        
    }
}

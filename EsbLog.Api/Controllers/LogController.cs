using EsbLog.Api.App_Start;
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
        public LogController(ILog log,IBus bus,IPlatformDbContext context)
        {
            _log = log;
            _bus = bus;
            _context = context;
        }

        [HttpPost]
        public async Task Post([FromBody]LogRequest value)
        {
            _log.Info("Post 开始");

            await _bus.Publish<ILogRequested>(new 
            {
                AppId = value.AppCode,
                LogLevel = value.LogLevel,
                Content = value.Message,
                Time = value.Time
            });

            _log.Info("Post 结束");
        }

        [HttpGet]
        public string Get(string id)
        {
            _log.Info("get" + id);
            return id;
        }
        
        
        
    }
}

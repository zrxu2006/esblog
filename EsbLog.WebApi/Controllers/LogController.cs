using EsbLog.Esb.Message;
using EsbLog.Log4Net;
using EsbLog.WebApi.App_Start;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EsbLog.WebApi.Controllers
{
    /// <summary>
    /// EsbLog 日志WebApi
    /// </summary>
    public class LogController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger("EsbLog.App.Log");
        // POST api/values
        public async Task Post([FromBody]LogRequest value)
        {
            log.Info("Post 开始");

            await WebApiApplication.LogBus.Publish<ILogRequested>(new 
            {
                AppId = value.AppId,
                LogLevel = value.LogLevel,
                Content= DateTime.Now.ToString(),
                Ticks = DateTime.Now.Ticks
            });
            
            log.Info("Post 结束");
        }

        public string Get(string id)
        {
            log.Info("get" + id);
            return id;
        }
    }
}

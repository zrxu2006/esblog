using EsbLog.Log4Net;
using EsbLog.WebApi.App_Start;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public void Post([FromBody]LogRequest value)
        {
            var s = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            log.Info(s);
        }

        public string Get(string id)
        {
            log.Info("get" + id);
            return id;
        }
    }
}

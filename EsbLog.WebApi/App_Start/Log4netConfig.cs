using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EsbLog.WebApi.App_Start
{
    public class Log4netConfig
    {
        public static void Config()
        {
            var configFile = new FileInfo(HttpContext.Current.Server.MapPath("~/log4net.config"));
            XmlConfigurator.ConfigureAndWatch(configFile);
            log4net.LogManager.GetLogger("EsbLog.App.Log").Info("App 启动");
        }
    }
}
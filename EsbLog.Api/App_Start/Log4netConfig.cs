using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EsbLog.Api.App_Start
{
    public class Log4netConfig
    {
        public static void Config()
        {
            var configFile = new FileInfo(HttpContext.Current.Server.MapPath("~/log4net.config"));
            XmlConfigurator.ConfigureAndWatch(configFile);
            LogManager.GetLogger(Log4netLoggerName.ESBLOG_API).Info("App 启动");
        }
    }

    public class Log4netLoggerName
    {
        public const string ESBLOG_API = "EsbLog.Api.Log";
        public const string ESBLOG_API_ERROR = "EsbLog.Api.Error";
    }
}
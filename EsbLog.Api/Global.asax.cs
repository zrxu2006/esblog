using Autofac;
using EsbLog.Api.App_Start;
using EsbLog.Api.Infrastruction;
using log4net;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace EsbLog.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        IContainer _conainer;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Log4netConfig.Config();
            _conainer = AutofacConfig.Build();
        }

        protected void Application_End()
        {
            var bc = _conainer.Resolve<IBusControl>();
            bc.Stop();
            LogManager.GetLogger(Log4netLoggerName.ESBLOG_API).Info("APP END");
        }
    }
}

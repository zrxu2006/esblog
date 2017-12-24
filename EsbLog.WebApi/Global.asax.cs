using EsbLog.WebApi.App_Start;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EsbLog.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IBusControl _busControl;
        public static IBus LogBus
        {
            get { return _busControl; }
        }
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Log4netConfig.Config();

            _busControl = ConfigureBus();
            _busControl.Start();
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _busControl.Stop();
            log4net.LogManager.GetLogger("EsbLog.App.Log").Info("APP END");
        }

        IBusControl ConfigureBus()
        {
            //return Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
            //    {
            //        h.Username("guest");
            //        h.Password("guest");
            //    });
            //});

            return Bus.Factory.CreateUsingInMemory(c => { });
        }
    }
}

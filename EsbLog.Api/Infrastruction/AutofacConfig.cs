using Autofac;
using Autofac.Integration.WebApi;
using EsbLog.Api.App_Start;
using log4net;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;

namespace EsbLog.Api.Infrastruction
{
    public class AutofacConfig
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var log = LogManager.GetLogger(Log4netLoggerName.ESBLOG_API);
            builder.Register(c => log)
                    .SingleInstance();

            RegisterMassTransit(builder);
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // start bus
            var bc = container.Resolve<IBusControl>();
            bc.Start();

            return container;
        }

        private static void RegisterMassTransit(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                //var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                //{
                //    var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                //    {
                //        h.Username("guest");
                //        h.Password("guest");
                //    });

                //    cfg.ReceiveEndpoint("customer_update_queue", ec =>
                //    {
                //        ec.LoadFrom(context);
                //    });
                //});

                var busControl = Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    cfg.ReceiveEndpoint("customer_update_queue", ec =>
                    {
                        ec.LoadFrom(context);
                    });
                });

                return busControl;
            })
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();
        }
    }
}
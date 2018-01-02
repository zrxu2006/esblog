using Autofac;
using EsbLog.Esb.Consume;
using EsbLog.Esb.Repository;
using EsbLog.Platform.Database;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Services.Dependancies
{
    public static class AutofacConfig
    {
        public static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TestService>();
            builder.RegisterType<LogRepository>()
                    .As<ILogRepository>();
            builder.Register(c => new PlatformDbContext(c.Resolve<IConnectionString>().ConnectionString))
                .As<IPlatformDbContext>();                    
            builder.RegisterType<PlatformConnectionStringProvider>()
                    .As<IConnectionString>()
                    .SingleInstance();
            RegisterMassTransit(builder);
            return builder.Build();
        }

        private static void RegisterMassTransit(ContainerBuilder builder)
        {
            builder.RegisterType<SaveLogConsumer>();
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
                    cfg.ReceiveEndpoint("test_queue", ec =>
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

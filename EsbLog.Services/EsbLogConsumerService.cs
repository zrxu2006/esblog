using EsbLog.Domain;
using EsbLog.Esb.Consume;
using log4net;
using log4net.Config;
using MassTransit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace EsbLog.Services
{
    class EsbLogConsumerService : ServiceControl
    {
        readonly ILog _log = LogManager.GetLogger(
                                        typeof(EsbLogConsumerService));
        IBusControl _bus;

        //StandardKernel _kernel;

        public bool Start(HostControl hostControl)
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
                             
            _bus = ConfigureBus();
            _bus.Start();
            //_log.Info("Service Started.");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _bus.Stop();
            _log.Info("Service end.");
            return true;
        }

        private IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "esblog_queue", e =>
                {
                    //e.Consumer<SaveLogConsumer>();                 
                });
            });
            //return Bus.Factory.CreateUsingInMemory(cfg =>
            //{
            //    cfg.ReceiveEndpoint("event_queue", e =>
            //    {
            //        e.Handler<IValueEntered>(context =>
            //        {
            //            return Task.Run(() =>
            //            {                           
            //                _log.InfoFormat("value entered:{0}",context.Message.Value);
            //                Console.Out.WriteLine("new value:{0}", context.Message.Value);
            //            });
            //        });

            //    });
            //});
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsbLog.Poc.Contracts;
using MassTransit;
using Topshelf;
using log4net;
using System.IO;
using log4net.Config;

namespace EsbLog.Poc.Services
{   
    public class Program
    {
        static void Main(string[] args)
        {            
            HostFactory.Run(cfg => cfg.Service(x => new EventConsumerService()));
        }
    }

    class EventConsumerService : ServiceControl
    {
        readonly ILog _log = LogManager.GetLogger(
                                         typeof(EventConsumerService));
        IBusControl _bus;
        public bool Start(HostControl hostControl)
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            _bus = ConfigureBus();
            _bus.Start();
            _log.Info("Service Started.");
            return true;
        }

        private IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri("rabbitmq://192.168.1.100/"), h =>
                    {
                        h.Username("esblog");
                        h.Password("esblog");
                    });

                    cfg.ReceiveEndpoint(host, "event_queue", e =>
                    {
                        e.Handler<IValueEntered>(context => 
                        { 
                            return Task.Run(() =>
                            {
                                _log.InfoFormat("value entered:{0}", context.Message.Value);
                                Console.Out.WriteLine("new value:{0}", context.Message.Value);
                            });
                        });
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

        public bool Stop(HostControl hostControl)
        {
            _bus.Stop();

            return true;
        }
    }
}

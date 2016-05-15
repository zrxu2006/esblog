using EsbLog.Poc.Consumers;
using EsbLog.Poc.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysConsole = System.Console;

namespace EsbLog.Poc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = ConfigureBus();

            
                busControl.Start();
            
                do
                {

                    SysConsole.WriteLine("ENter message (or quit to exit)");
                    SysConsole.Write("> ");
                    string value = SysConsole.ReadLine();

                    if("quit".Equals(value,StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    
                    busControl.Publish<IValueEntered>(new { Value = value });

                } while (true);
            
        }

        private static IBusControl ConfigureBus()
        {
            //return Bus.Factory.CreateUsingInMemory(cfg =>
            //{
            //    cfg.ReceiveEndpoint("queue", ep => { });
            //});

            //return Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    cfg.Host(new Uri("rabbitmq://192.168.1.100/"), h =>
            //    {
            //        h.Username("esblog");
            //        h.Password("esblog");
            //    });

            //    //cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
            //    //{
            //    //    e.Consumer<UpdateCustomerConsumer>();
            //    //});
            //});

            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });               
            });

        }
    }
}

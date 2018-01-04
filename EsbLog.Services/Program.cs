using EsbLog.Services.Dependancies;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;

namespace EsbLog.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacConfig.BuildAutofacContainer();

            HostFactory.Run(c =>
            {
                c.UseAutofacContainer(container);

                c.Service<EsbLogConsumerService>(x =>
                {
                    x.ConstructUsingAutofacContainer();
                    x.WhenStarted(s => s.Start());
                    x.WhenStopped(s => s.Stop());
                });

                c.RunAsLocalSystem();

                c.SetDescription("EsbLog service");
                c.SetDisplayName("EsbLog 服务");
                c.SetServiceName("EsbLog Service");
            });
            //HostFactory.Run(cfg =>
            //{
            //    cfg.Service<EsbLogConsumerService>(c =>
            //    {
            //        c.WhenStarted(s => s.Start());
            //    });
            //    cfg.Service(x => new EsbLogConsumerService());

            //    cfg.RunAsLocalSystem();

            //    cfg.SetDescription("EsbLog service");
            //    cfg.SetDisplayName("EsbLog 服务");
            //    cfg.SetServiceName("EsbLogService");

            //});

            //Console.ReadKey();
        }
    }
}

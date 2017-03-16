using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace EsbLog.Services
{
    class Program
    {
        static void Main(string[] args)
        {            
            HostFactory.Run(cfg =>
            {
                cfg.Service(x => new EsbLogConsumerService());

                cfg.RunAsLocalSystem();

                cfg.SetDescription("EsbLog service");
                cfg.SetDisplayName("EsbLog 服务");
                cfg.SetServiceName("EsbLogService");
            });

            //Console.ReadKey();
        }
    }
}

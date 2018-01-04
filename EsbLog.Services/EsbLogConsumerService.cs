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
    public class EsbLogConsumerService 
    {
        readonly ILog _log = LogManager.GetLogger(
                                        typeof(EsbLogConsumerService));
        IBusControl _bus;

        public EsbLogConsumerService(IBusControl bus)
        {
            _bus = bus;
        }

        public bool Start()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
                             
            _bus.Start();
            _log.Info("Service Started.");
            return true;
        }

        public bool Stop()
        {
            _bus.Stop();
            _log.Info("Service end.");
            return true;
        }
    }
}

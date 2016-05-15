using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace EsbLog.Poc.Topshelf
{
    public class TownCrier
    {
        readonly Timer _timer;
        readonly ILog _log = LogManager.GetLogger(
                                         typeof(TownCrier));

        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => 
            {
                Console.WriteLine("It is {0} and all is well", DateTime.Now);
                _log.InfoFormat("TopshelfDemo is Started :{0}",DateTime.Now);
            };
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

    public class Program
    {
        public static void Main()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            HostFactory.Run(x =>                                 //1
            {
                x.Service<TownCrier>(s =>                        //2
                {
                    s.ConstructUsing(name => new TownCrier());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("Sample Topshelf Host");        //7
                x.SetDisplayName("Stuff显示");                       //8
                x.SetServiceName("Stuff服务");                       //9
            });                                                  //10
        }
    }
}

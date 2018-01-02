using EsbLog.Esb.Message;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Services
{
    public class TestService
    {
        IBusControl _bus;
        public TestService(IBusControl bus)
        {
            _bus = bus;
        }
        public void Start()
        {
            _bus.Start();

            Task.Run(() =>
            {
                foreach (int i in Enumerable.Range(1, 10))
                {
                    Task.Delay(5000).GetAwaiter().GetResult();
                    _bus.Publish<ILogRequested>(new
                    {
                        AppId = 1,
                        LogLevel = "DEBUG",
                        Content = "Test",
                        Time = DateTime.Now
                    });
                }
                
            });
            
        }

        public void Stop()
        {
            _bus.Stop();
        }
    }
}

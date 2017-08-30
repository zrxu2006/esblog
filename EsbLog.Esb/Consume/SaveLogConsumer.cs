using EsbLog.Domain;
using EsbLog.Esb.Message;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Consume
{
    /// <summary>
    /// 保存日志Consumer
    /// </summary>
    public class SaveLogConsumer : IConsumer<ILogRequested>
    {
        //ILogRepository _repository;
        //public SaveLogConsumer(ILogRepository rep)
        //{
        //    _repository = rep;
        //}

        public Task Consume(ConsumeContext<ILogRequested> context)
        {
            //Log log = new Log();
            //log.AppId = context.Message.AppId;
            //log.Level = context.Message.LogLevel;
            //log.Ticks = context.Message.Ticks;
            //log.Content = context.Message.Content;

            //var repository = new EFLogRepository();

            //return Task.Run(() => repository.Save(log));
            //return _repository.SaveAsync(log);
            return Task.Delay(1);
        }
    }
}

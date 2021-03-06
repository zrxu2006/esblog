﻿using EsbLog.Domain;
using EsbLog.Domain.Log;
using EsbLog.Esb.Message;
using EsbLog.Esb.Repository;
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
        ILogRepository _repository;
        
        public SaveLogConsumer(ILogRepository repo)
        {
            _repository = repo;
        }

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
            _repository.AddLog(new LogEntry
            {
                LogLevel = "Test"
            });
            return Task.Delay(1);
        }
    }
}

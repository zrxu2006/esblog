using EsbLog.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Repository
{
    public interface ILogRepository
    {
        Task<bool> AddLog(LogEntry log);
    }
}

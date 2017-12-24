using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Esb.Message
{
    /// <summary>
    /// 日志请求事件消息
    /// </summary>
    public interface ILogRequested
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        int AppId { get;  }

        /// <summary>
        /// 日志等级
        /// </summary>
        string LogLevel { get; }

        /// <summary>
        /// 日志内容
        /// </summary>
        string Content { get; }

        /// <summary>
        /// 时间戳
        /// </summary>
        DateTime Time { get; }
    }
}

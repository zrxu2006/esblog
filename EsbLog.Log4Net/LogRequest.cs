using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Log4Net
{
    /// <summary>
    /// Log请求
    /// </summary>   
    public class LogRequest
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string LogLevel { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Core
{
    public class EsbLogRequest
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        
        /// <summary>
        /// 请求时间戳
        /// </summary>
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// 请求签名
        /// </summary>
        public string Sign { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Tools.HttpRequest
{
    [Serializable]
    public class ProxyIP
    {
        public string IP
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }
        public long IPID
        {
            get;
            set;
        }
        public int SuccessNumber
        {
            get;
            set;
        }
        public int TotalNumber
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Paging
{
    public abstract class PagingRequest
    {
        public PagingRequest()
        {
            PageSize = 10;
        }
        public virtual int PageSize { get; set; }
        //public virtual long Total { get; set; }
        public virtual long PageIndex { get; set; }
    }
}

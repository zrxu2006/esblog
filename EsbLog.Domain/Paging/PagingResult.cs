using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain.Paging
{
    public abstract class PagingResult<T>
    {
        public PagingResult()
        {
            ResultData = new HashSet<T>();
        }
        public virtual int PageSize { get; set; }
        public virtual long Total { get; set; }
        public virtual long PageIndex { get; set; }
        public ICollection<T> ResultData { get; private set; }

        public bool HasMore
        {
            get
            {
                return LastPageIndex > PageIndex;
            }
        }

        public long LastPageIndex
        {
            get
            {
                if (Total == 0) return 0;
                return Total / PageSize;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Predicate<T> condition);

        bool Add(T entity);
        bool Edit(T entity);

    }
}

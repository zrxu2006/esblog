using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Domain
{
    public class EFLogRepository :ILogRepository
    {
        public EFLogRepository()
        {
        }

        public Task<int> SaveAsync(Log entity)
        {
            return Task.Run(() => Save(entity));
            //using(var db = new EsbLogContainer())
            //{
            //    db.LogSet.Add(log);
            //    return db.SaveChangesAsync();
            //}
            
        }

        public int Save(Log entity)
        {
            using(var db = new EsbLogContainer())
            {
                db.LogSet.Add(entity);
                return db.SaveChanges();
            }
        }

    }
}

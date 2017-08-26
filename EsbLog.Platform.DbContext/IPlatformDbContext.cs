using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Platform.Database
{
    public interface IPlatformDbContext:IDisposable
    {
        IDbSet<App> Apps { get; }
        int SaveChanges();
        //Task<int> SaveChangesAsync();
        System.Data.Entity.Database Database { get; }
    }
}

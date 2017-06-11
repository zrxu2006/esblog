using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EsbLog.Domain.Platform;
using EsbLog.Platform.Database.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace EsbLog.Platform.Database
{    
    public class PlatformDBContext : DbContext
    {
        internal PlatformDBContext(string connectString):base(connectString)
        {
        }
        public DbSet<LoginUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add<EntityMappingConfiguration<LoginUserMap>>(new LoginUserMap());
        }
    }

}

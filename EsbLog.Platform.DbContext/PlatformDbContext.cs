using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EsbLog.Domain.Platform;
using EsbLog.Platform.Database.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Data;
using System.Data.Entity.SqlServer;

namespace EsbLog.Platform.Database
{
    [DbConfigurationType(typeof(SqlServerProviderConfiguration))]
    public class PlatformDBContext : DbContext,IPlatformDbContext
    {
        public PlatformDBContext(string connectString):base(connectString)
        {
        }

        public PlatformDBContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            System.Data.Entity.Database.SetInitializer<PlatformDBContext>(null);

            #if DEBUG
            Database.Log = sql => { Debug.WriteLine(sql); };
            #endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            //modelBuilder.Configurations.Add<EntityMappingConfiguration<LoginUserMap>>(new LoginUserMap());
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            // TODO: Add extra data exception types, as needed, here
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Validation failed for one or more entities. Refer to validation errors listed below.");

                foreach (var entityError in ex.EntityValidationErrors)
                {
                    sb.AppendLine();
                    sb.AppendLine(string.Format("Failed to commit [{0}] in the [{1}] state.", entityError.Entry.Entity.GetType().FullName, entityError.Entry.State));
                    foreach (var validationError in entityError.ValidationErrors)
                        sb.AppendLine(string.Format("\t{0} - {1}", validationError.PropertyName, validationError.ErrorMessage));
                }

                throw new DataException(sb.ToString(), ex);
            }
        }

        public override async Task<int> SaveChangesAsync()
        {
            try
            {
                return await base.SaveChangesAsync();
            }
            // TODO: Add extra data exception types, as needed, here
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Validation failed for one or more entities. Refer to validation errors listed below.");

                foreach (var entityError in ex.EntityValidationErrors)
                {
                    sb.AppendLine();
                    sb.AppendLine(string.Format("Failed to commit [{0}] in the [{1}] state.", entityError.Entry.Entity.GetType().FullName, entityError.Entry.State));
                    foreach (var validationError in entityError.ValidationErrors)
                        sb.AppendLine(string.Format("\t{0} - {1}", validationError.PropertyName, validationError.ErrorMessage));
                }

                throw new DataException(sb.ToString(), ex);
            }
        }

        public IDbSet<App> Apps { get; set; }
        public IDbSet<LoginUser> Users { get; set; }
    }

    public class SqlServerProviderConfiguration : DbConfiguration
    {
        public SqlServerProviderConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }

    public class LocalDBProviderConfiguration : DbConfiguration
    {
        public LocalDBProviderConfiguration()
        {
            SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.LocalDbConnectionFactory("mssqllocaldb"));
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}

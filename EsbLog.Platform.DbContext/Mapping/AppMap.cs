using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsbLog.Platform.Database.Mapping
{
    public class AppMap : EntityTypeConfiguration<App>
    {
        public AppMap()
        {
            ToTable("tblApp");

            HasKey(l => l.AppId);

            Property(l => l.AppId).HasColumnName("Id")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.Name).HasColumnName("AppName");
            Property(l => l.Code).HasColumnName("Code");
            Property(l => l.Description).HasColumnName("Description");
            Property(l => l.PublicKey).HasColumnName("PublicKey");

            HasOptional(l => l.User).WithMany(u => u.Apps)
                .Map(m =>
                {
                    m.MapKey("UserId");
                });
        }
    }
}

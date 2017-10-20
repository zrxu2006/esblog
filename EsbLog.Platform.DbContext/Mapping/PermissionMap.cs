using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Platform.Database.Mapping
{
    public class PermissionMap : EntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            ToTable("tblPermission");

            HasKey(p => p.PermissionId);

            Property(p => p.PermissionId).HasColumnName("PermissionId")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.PermissionName).HasColumnName("PermissionName");
            Property(p => p.PermissionStatus).HasColumnName("PermissionStatus");

            //HasMany(p => p.Apps).WithMany(a => a.Permissions)
            //        .Map(m =>
            //        {
            //            m.ToTable("tblAppPermission");
            //            m.MapLeftKey("PermissionId");
            //            m.MapRightKey("AppId");
            //        });
        }
    }
}

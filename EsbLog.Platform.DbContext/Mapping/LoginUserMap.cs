using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;
using EsbLog.Domain.Platform;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsbLog.Platform.Database.Mapping
{
    public class LoginUserMap : EntityTypeConfiguration<LoginUser>
    {
        public LoginUserMap()
        {
            ToTable("tblLoginUser");

            HasKey(l => l.Id);

            Property(l => l.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.LoginName).HasColumnName("LoginName");
            Property(l => l.Password).HasColumnName("Password");
            Property(l => l.LoginTime).HasColumnName("LoginTime");
            Property(l => l.UserType).HasColumnName("UserType");
        }
    }
}

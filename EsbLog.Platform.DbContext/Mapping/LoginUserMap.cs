using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;
using EsbLog.Domain.Platform;

namespace EsbLog.Platform.Database.Mapping
{
    public class LoginUserMap: EntityMappingConfiguration<LoginUser>
    {
        public LoginUserMap()
        {
            ToTable("tblLoginUser");

            Requires(l => l.Id);

            Property(l => l.Id).HasColumnName("Id");
            Property(l => l.UserName).HasColumnName("UserName");
            Property(l => l.Password).HasColumnName("Password");
            Property(l => l.LoginTime).HasColumnName("LoginTime");
        }
    }
}

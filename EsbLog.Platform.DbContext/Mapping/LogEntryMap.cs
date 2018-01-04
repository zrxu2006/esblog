using EsbLog.Domain.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Platform.Database.Mapping
{
    public class LogEntryMap: EntityTypeConfiguration<LogEntry>
    {
        public LogEntryMap()
        {
            ToTable("tblLog");

            HasKey(l => l.Id);

            Property(l => l.LogLevel).HasColumnName("Level");
            Property(l => l.Message).HasColumnName("Message");
            Property(l => l.Creation).HasColumnName("AppCreateTime");
            //Property(l => l.Creation).HasColumnName("CreateTime");
            Property(l => l.AppId).HasColumnName("AppId");

            HasRequired(l => l.App).WithMany().HasForeignKey(l => l.AppId);
                
        }
    }
}

using Autofac;
using Autofac.Core;
using EsbLog.Esb.Cache;
using EsbLog.Esb.Repository;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Api.Infrastruction
{
    public class AutofacDependanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlatformConnectionStringProvider>()
                .As<IConnectionString>();
            builder.RegisterType<LogRepository>()
                .As<ILogRepository>();
            builder.Register(c => new EsbMemoryCache("ESB_LOG"))
                    .As<ICache>()
                    .SingleInstance();
            builder.Register(c => new PlatformDBContext(c.Resolve<IConnectionString>().ConnectionString)
                    ).As<IPlatformDbContext>()
                    .SingleInstance();
        }

    }
}
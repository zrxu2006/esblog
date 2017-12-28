using Autofac;
using Autofac.Core;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Api.Infrastruction
{
    public class AutofacDependanceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlatformConnectionStringProvider>()
                .As<IConnectionString>();

            builder.Register(c => new PlatformDBContext(c.Resolve<IConnectionString>().ConnectionString)
                    ).As<IPlatformDbContext>()
                    .SingleInstance();
        }

    }
}
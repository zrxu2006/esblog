﻿using AutoMapper;
using EsbLog.Web.App_Start;
using EsbLog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EsbLog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            EsblogWebConfig.RegisterContentHeader(EsblogConfig.ContentHeaders);
            ConfigAutoMap();
        }

        private void ConfigAutoMap()
        {
            Mapper.Initialize(m => m.AddProfile<EsbLogAutoMapperProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}

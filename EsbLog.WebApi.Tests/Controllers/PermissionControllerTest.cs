using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Web.Controllers;
using EsbLog.Web.Repository.Concrete;
using EsbLog.Web.Models;
using AutoMapper;
using EsbLog.Domain.Platform;
using EsbLog.Web.Infrastructure;

namespace EsbLog.WebApi.Tests.Controllers
{
    [TestClass]
    public class PermissionControllerTest : BaseTest
    {
        [TestInitialize]
        public void init()
        {
            //Mapper.Configuration.
            Mapper.Configuration.AddProfile(new EsbLogAutoMapperProfile());
            //Mapper.Initialize(c => c.AddProfile(new EsbLogAutoMapperProfile()));
            //Mapper.CreateMap<LoginUserAddModel, LoginUser>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.UserType, opt => opt.UseValue<string>("U"))
            //    .ForMember(dest => dest.LoginTime, opt => opt.UseValue<DateTime?>(null))
            //    .ForMember(dest => dest.Apps, opt => opt.Ignore());
        }
        [TestMethod]
        public void AddMethod()
        {
            var app = new AppManagerRepository(DBFactory);
            var account = new AccountRepository(DBFactory);
            var controller = new PermissionManageController(app,account);

            controller.Add(new LoginUserAddModel
            {
                LoginName= "Test2@Test.com",
                AppIds = "1,2,3"
            });
        }
    }
}

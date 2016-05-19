using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.WebApi.Controllers;

namespace EsbLog.WebApi.Tests.Controllers
{
    [TestClass]
    public class LogControllerTest
    {
        [TestMethod]
        public void Post()
        {
            var controller = new LogController();
            controller.Post("hahahhahhh");
        }
    }
}

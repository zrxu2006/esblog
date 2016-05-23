using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.WebApi.Controllers;
using EsbLog.Log4Net;
using System.Net.Http;
using System.Web.Http;
using EsbLog.Tools.HttpRequest;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EsbLog.WebApi.Tests.Controllers
{
    [TestClass]
    public class LogControllerTest
    {
        [TestMethod]
        public void Post()
        {
            var controller = new LogController();
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:8888/api/log")
            };

            controller.Configuration = new HttpConfiguration();

            LogRequest r = new LogRequest();
            r.AppId = "Test1";
            r.LogLevel = "Debug";
            controller.Post(r);
        }

        [TestMethod]
        public void PostIIS()
        {
           
            //Task.Run(()=>task()).Start();
            HttpGet reqGet = new HttpGet("http://localhost:8988/api/values");
            var result = reqGet.Request();


            //HttpPost req = new HttpPost("http://localhost:8988/api/values");
            //req.PostData = "va";
            //var strRes = req.Request();

            for (int i = 1; i < 3; i++)
            {
                task();
            }

            //HttpClient c = new HttpClient();
            //c.BaseAddress = "http://localhost:8888/api/log";
            //c.PostAsync()

            
            //controller.Post(r);
        }

        private void task()
        {
            LogRequest r = new LogRequest();
            r.AppId = "ttt";
            r.LogLevel = "ddd";

            HttpPost req = new HttpPost("http://localhost:8988/api/log");
            req.PostData = JsonConvert.SerializeObject(r);
            var strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
            strRes = req.Request();
        }


        [TestMethod]
        public void PostIIS2()
        {
            LogRequest();
        }

        private static async void LogRequest()
        {
            try
            {
                HttpClient hc = new HttpClient();

                HttpResponseMessage responseMessage = await hc.GetAsync("http://localhost:8988/api/values");

                LogRequest r = new LogRequest();
                r.AppId = "TTT";
                r.LogLevel = "sssss";

                //var responseMessage = await hc.PostAsJsonAsync<LogRequest>("http://localhost:8888/api/log", r);
                //var s = responseMessag
            }
            catch(Exception e)
            {

            }
            
        }
    }
}

using EsbLog.Domain.Log;
using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    [EsblogAuth]
    public class LogController : Controller
    {
        //
        // GET: /Log/
        [HttpGet]
        public ActionResult Index()
        {
            LogModel model = new LogModel();
            var user = this.GetUserSession();
            if (user != null)
            {
                model.Apps = user.UserApps;
            }

            var logs = new HashSet<LogResultModel>();
            logs.Add(new LogResultModel
            {
                AppName = "T1",
                LogLevel = LogLevel.Debug.ToString(),
                Message = "asdfasdf",
                Time = DateTime.Now
            });

            logs.Add(new LogResultModel
            {
                AppName = "T2",
                LogLevel = LogLevel.Debug.ToString(),
                Message = "asdfasdf2",
                Time = DateTime.Now
            });
            model.Logs = logs;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LogPagingRequestModel query)
        {
            return RedirectToAction("LogPaging", "Partial", new LogPagingRequestModel { PageIndex = 0, PageSize = 10 });
            //return null; 

            //PagingResult<LogResultModel> result = new PagingResult<LogResultModel>();

            //result.Result.Add(new LogResultModel
            //{
            //    AppName = "T1",
            //    LogLevel = LogLevel.Debug.ToString(),
            //    Message = "asdfasdf",
            //    Time = DateTime.Now
            //});
            
            //result.Result.Add(new LogResultModel
            //{
            //    AppName = "T2",
            //    LogLevel = LogLevel.Debug.ToString(),
            //    Message = "asdfasdf2",
            //    Time = DateTime.Now
            //});

            //result.Result.Add(new LogResultModel
            //{
            //    AppName = "T3",
            //    LogLevel = LogLevel.Error.ToString(),
            //    Message = "asdfasasdf3",
            //    Time = DateTime.Now
            //});

            //result.Result.Add(new LogResultModel
            //{
            //    AppName = "T4",
            //    LogLevel = LogLevel.Info.ToString(),
            //    Message = "asdfasdf4",
            //    Time = DateTime.Now
            //}); 
            //return Json(result);
        }
	}
}
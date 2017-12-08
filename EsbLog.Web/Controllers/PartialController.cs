using EsbLog.Domain.Log;
using EsbLog.Web.Models;
using EsbLog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    public class PartialController : Controller
    {
        ILogRepository _repo;
        public PartialController(ILogRepository repo)
        {
            _repo = repo;
        }

        //
        // GET: /Partial/
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult LogPaging(LogPagingRequestModel request)
        {
            var model = new LogPagingPartialViewModel(request);
            ////_repo.GetLogsAsync()
            //model.Result.PageIndex = request.PageIndex;
            //model.Result.PageSize = request.PageSize;
            //model.Result.Total = 200;
            //model.Result.ResultData.Add(new LogResultModel
            //{
            //    AppName = "App1",
            //    LogLevel = "Debug",
            //    Message = "asdf",
            //    Time = DateTime.Now
            //});
            //model.UpdateTargetId = "queryResult";
            var queryRequest = new LogQueryRequest();

            var logs = _repo.GetLogsAsync(queryRequest);

            return PartialView("LogPaging", model);
        }
	}
}
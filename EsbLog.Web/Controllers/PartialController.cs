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
            var queryRequest = new LogQueryRequest
            {
                AppIds = request.AppIds,
                EndDate = request.EndDate,
                LogLevels = request.LogLevels,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                StartDate = request.StartDate
            };
            LogQueryResult logs = _repo.GetLogsAsync(queryRequest)
                        .GetAwaiter().GetResult();
         
            var model = new LogPagingPartialViewModel(request);

            LogPagingResultModel result = model.Result;
            result.PageIndex = request.PageIndex;
            result.PageSize = request.PageSize;
            result.ResultData = new HashSet<LogResultModel>(logs
                                .ResultData
                                .Select(l => new LogResultModel
                                {
                                    AppName = l.App.Name,
                                    LogLevel = l.LogLevel,
                                    Message = l.Message,
                                    Time = l.Creation
                                })
                                .ToList());
            return PartialView("LogPaging", model);
        }
    }
}
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

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LogPagingRequestModel query)
        {
            return RedirectToAction("LogPaging", "Partial", query);            
        }
	}
}
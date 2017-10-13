using EsbLog.Domain.Platform;
using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using EsbLog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    [EsblogAuth]
    public class PermissionManageController : Controller
    {
        IAppManagerRepository _appRepo;
        public PermissionManageController(IAppManagerRepository appRepository)
        {
            _appRepo = appRepository;
        }
        //
        // GET: /Permission/
        public ActionResult Index()
        {
            App a = new App
            {
                AppId = 1,
                Code = "APP01",
                Name = "App-01",
                PublicKey = Guid.NewGuid().ToString()
            };


            
            ViewBag.AppList = _appRepo.FindAllApps();
            ViewBag.AppList = new List<App>();
            ViewBag.AppList.Add(a);
            return View();
        }

        [HttpPost]
        public ActionResult Index(PermissionQueryRequest queryRequest)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
	}
}
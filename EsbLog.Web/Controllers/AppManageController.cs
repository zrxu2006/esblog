﻿using EsbLog.Web.Repository;
using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace EsbLog.Web.Controllers
{
    [Authorize]
    public class AppManageController : Controller
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        IAppManagerRepository _repo;
        public AppManageController(IAppManagerRepository repo)
        {
            _repo = repo;

        }
        //
        // GET: /AppManage/
        public ActionResult Index()
        {
            _logger.Trace("test");
            return View(_repo.FindAllApps());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(App app)
        {
            if (ModelState.IsValid)
            {
                app.PublicKey = Guid.NewGuid().ToString();
                _repo.AddApp(app);
                return RedirectToAction("Index");
            }
            return View(app);
        }

        public ActionResult Edit(int id)
        {
            var app = _repo.FindAllApps().FirstOrDefault(a => a.AppId == id);
            if (app == null)
            {
                return RedirectToAction("Add");
            }
            else
            {
                return View(app);
            }
        }

        [HttpPost]
        public ActionResult Edit(App app)
        {
            if (ModelState.IsValid)
            {
                _repo.EditApp(app);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit", new { id = app.AppId });
            }
        }
	}
}
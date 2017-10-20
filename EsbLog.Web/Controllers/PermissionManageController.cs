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
        IPermissionRepository _perRepo;
        IAccountRepository _accountRepo;
        public PermissionManageController(IAppManagerRepository appRepository,
                IAccountRepository accountRepo)
        {
            _appRepo = appRepository;
            _accountRepo = accountRepo;
        }

        // GET: /Permission/
        public ActionResult Index()
        {
            var appLoginUsers = _accountRepo.FindUsers();

            return View(appLoginUsers);
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
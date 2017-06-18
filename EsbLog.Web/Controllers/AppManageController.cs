using EsbLog.Web.Repository;
using EsbLog.Domain.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    public class AppManageController : Controller
    {
        IAppManagerRepository _repo;
        public AppManageController(IAppManagerRepository repo)
        {
            _repo = repo;

        }
        //
        // GET: /AppManage/
        public ActionResult Index()
        {
            return View(_repo.FindAllApps());
        }

        
	}
}
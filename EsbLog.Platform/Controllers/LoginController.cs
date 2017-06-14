using EsbLog.Platform.Database;
using EsbLog.Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Platform.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Session["User"] = login.UserName;
            }
            PlatformDBContext c = new PlatformDBContext(new PlatformConnectionStringProvider());
            
            return View(login);
            //return RedirectToAction("Index", "AppManager");
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            //return View();
        }
	}
}
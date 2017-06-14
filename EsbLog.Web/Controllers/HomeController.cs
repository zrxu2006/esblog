using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(LoginUserViewModel user)
        {
            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
                
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginUserViewModel user)
        {
            if (user.UserName.Contains("admin"))
            {
                return RedirectToAction("Index", "Account");
            }
            return Content(string.Format("{0},{1},{2}",user.UserName,user.Password,user.RememberMe));
        }
	}
}
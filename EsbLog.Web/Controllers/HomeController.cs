using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Login(LoginUserViewModel user)
        {
            return Content(string.Format("{0},{1},{2}",user.UserName,user.Password,user.RememberMe));
        }
	}
}
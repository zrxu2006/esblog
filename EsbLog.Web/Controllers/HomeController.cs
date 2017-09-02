using EsbLog.Web.Models;
using EsbLog.Web.Repository;
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
        IAccountRepository _repo;
        public HomeController(IAccountRepository repo)
        {
            _repo = repo;
        }
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
            int userId = _repo.ValidateUser(user.UserName, user.Password);
            if (userId>0)
            {
                Session["User"] = user;
                _repo.UpdateLoginTime(userId);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
            
            //return Content(string.Format("{0},{1},{2}",user.UserName,user.Password,user.RememberMe));
        }
	}
}
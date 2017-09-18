using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using EsbLog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EsbLog.Web.Controllers
{
    [EsblogAuth]
    public class AccountController : Controller
    {
        IAccountRepository _repo;
        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginUserViewModel user, string returnUrl)
        {
            int userId = _repo.ValidateUser(user.UserName, user.Password);
            if (userId > 0)
            {
                //Session["User"] = user;
                _repo.UpdateLoginTime(userId);
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(string.IsNullOrEmpty(returnUrl)
                                    ? Url.Action("Index", "Account")
                                    : returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "用户名或者密码错误");
                return View();
            }

            //return Content(string.Format("{0},{1},{2}",user.UserName,user.Password,user.RememberMe));
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Recover(string recoverEmail)
        {
            return Content("TODO :" + recoverEmail);
        }

        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }
	}
}
using AutoMapper;
using EsbLog.Domain.Platform;
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
            if (string.IsNullOrEmpty(user.UserName))
            {
                ModelState.AddModelError("", "用户名或者密码错误");
                return View();
            }
            int userId = _repo.ValidateUser(user.UserName, user.Password);
            if (userId > 0)
            {
                //Session["User"] = user;
                _repo.UpdateLoginTime(userId);
                var u = _repo.FindUserById(userId);
                var userSession = Mapper.Map<UserSessionModel>(u);
                this.SetUserSession(userSession);
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Redirect(string.IsNullOrEmpty(returnUrl)
                                    ? Url.Action("Index", "Home",new{id= userId})
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            this.ClearUserId();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]       
        public ActionResult SendPsw(int id)
        {
            var user = _repo.FindUserById(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendPsw(LoginUser user)
        {
            var resendUser = _repo.FindUserById(user.Id);

            // TODO
            // Send psw to email

            TempData["success"] = true;
            return RedirectToAction("SendPsw", new { id = user.Id });
        }

        [HttpGet]
        public ActionResult EditPsw()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPsw(EditPswModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["success"] = false;
                TempData["Message"] = "请输入原密码和新密码";
                return View(new EditPswModel());
            }
            bool isSucceed = true;
            string message = string.Empty;
            int? userId = this.GetUserId();
            if (!userId.HasValue)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var user = _repo.FindUserById(userId.Value);
                if (user == null)
                {
                    return RedirectToAction("Logout");
                }
                else
                {
                    isSucceed = model.NewPassword == model.NewPasswordConfirm;
                    if (!isSucceed)
                    {
                        message = "请确认新密码！";
                    }
                    else
                    {
                        if (_repo.ValidateUser(user.LoginName, model.OldPassword) == userId.Value)
                        {
                            _repo.UpdatePsw(userId.Value, model.NewPassword);
                        }else
                        {
                            isSucceed = false;
                            message = "原密码不正确！";
                        }
                    }                    
                }
            }

            TempData["success"] = isSucceed;
            TempData["Message"] = message;
            return View();
        }
    }
}
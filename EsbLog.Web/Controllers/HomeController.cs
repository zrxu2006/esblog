using EsbLog.Web.Models;
using EsbLog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EsbLog.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IAccountRepository _repo;
        IAppManagerRepository _appRepo;
        public HomeController(IAccountRepository repo, IAppManagerRepository appRepo)
        {
            _repo = repo;
            _appRepo = appRepo;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            int? id = Session["id"] as int?;
            if (!id.HasValue)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Request.RawUrl });                
            }
            else
            {
                var user = _repo.FindUserById(id.Value);
                HomeModel m = new HomeModel();
                m.IsManager = user.UserType.ToLower() == "m";
                if (m.IsManager)
                {
                    m.AppCount = _appRepo.GetCount();
                    m.PermissionCount = _repo.GetCount();
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Index","Log");
                }                
            }            
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(); 
        }
                
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginUserViewModel user,string returnUrl)
        {
            int userId = _repo.ValidateUser(user.UserName, user.Password);
            if (userId>0)
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //Session["User"] = null;
            return RedirectToAction("Login");
        }
	}
}
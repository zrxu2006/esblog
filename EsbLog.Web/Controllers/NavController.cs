using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EsbLog.Web.Controllers
{
    [EsblogAuth]
    public class NavController : Controller
    {
        private readonly static List<NavViewModel> _navMenu
                                = new List<NavViewModel>();
        private static IEnumerable<NavViewModel> GetNavMenu()
        {
            if (_navMenu.Count == 0)
            {
                _navMenu.Add(new NavViewModel
                {
                    NavName = "应用管理",
                    ControllerName = "AppManage",
                    ActionName = "Index"
                });

                _navMenu.Add(new NavViewModel
                {
                    NavName = "权限管理",
                    ControllerName = "PermissionManage",
                    ActionName = "Index"
                });

                _navMenu.Add(new NavViewModel
                {
                    NavName = "扩展管理",
                    ControllerName = "Extension",
                    ActionName = "Index"

                });
            }
          
            return _navMenu;
        }
        //
        // GET: /Nav/
        public ActionResult Menu(string selectedNav = null)
        {
            ViewBag.SelectedNav = selectedNav;
            ViewBag.UserName = this.User.Identity.Name;
           
            return PartialView(GetNavMenu());
        }
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult MatrixMenu(string controller = null)
        {
            //ViewBag.SelectedNav = selectedNav;
            //ViewBag.UserName = this.User.Identity.Name;
            var menuList = GetNavMenu();
            foreach (var m in menuList)
            {
                m.IsActive = string.Equals(m.ControllerName, controller, StringComparison.OrdinalIgnoreCase);
            }
            return PartialView(GetNavMenu());
        }
        [AllowAnonymous]
        public ActionResult MatrixContentHeader(RouteData routeData) 
        {
            var model = new ContentHeaderDisplayViewModel();
            model.Headers = EsblogConfig.ContentHeaders
                            .Where(c => c.ControllerName.ToUpper() 
                                    == routeData.Values["controller"].ToString().ToUpper());
            model.RouteValues = routeData.Values;
            return PartialView(model);
        }
	}
}
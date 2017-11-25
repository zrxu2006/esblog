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
        private readonly static List<NavViewModel> _navManageMenu
                                = new List<NavViewModel>();
        private readonly static List<NavViewModel> _navAppMenu
                                = new List<NavViewModel>();
        private static IEnumerable<NavViewModel> GetNavMenu(bool isManager)
        {
            if (_navManageMenu.Count == 0)
            {
                _navManageMenu.Add(new NavViewModel
                {
                    NavName = "首页",
                    ControllerName = "Home",
                    ActionName = "Index"
                });
                _navManageMenu.Add(new NavViewModel
                {
                    NavName = "应用管理",
                    ControllerName = "AppManage",
                    ActionName = "Index"
                });

                _navManageMenu.Add(new NavViewModel
                {
                    NavName = "权限管理",
                    ControllerName = "PermissionManage",
                    ActionName = "Index"
                });                
            }

            if (_navAppMenu.Count == 0)
            {
                _navAppMenu.Add(new NavViewModel
                {
                    NavName = "日志查询",
                    ControllerName = "Log",
                    ActionName = "Index"
                });

                _navAppMenu.Add(new NavViewModel
                {
                    NavName = "扩展管理",
                    ControllerName = "Extension",
                    ActionName = "Index"
                });

                _navAppMenu.Add(new NavViewModel
                {
                    NavName = "报表管理",
                    ControllerName = "Report",
                    ActionName = "Index"
                });
            }
            if (isManager)
            {
                return _navManageMenu;
            }
            else
            {
                return _navAppMenu;
            }
        }
        //
        // GET: /Nav/
        //public ActionResult Menu(string selectedNav = null)
        //{
        //    ViewBag.SelectedNav = selectedNav;
        //    ViewBag.UserName = this.User.Identity.Name;
           
        //    return PartialView(GetNavMenu());
        //}
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult MatrixMenu(ViewContext context)
        {
            var controller = context.RouteData.Values["controller"].ToString();
            
            var user = context.HttpContext.Session["User"] as UserSessionModel;
           
            var menuList = GetNavMenu(user.IsManager);
            foreach (var m in menuList)
            {
                m.IsActive = string.Equals(m.ControllerName, controller, StringComparison.OrdinalIgnoreCase);
            }
            return PartialView(menuList);
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
using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    [Authorize]
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
            return PartialView(GetNavMenu());
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Platform.Controllers
{
    [Authorize]
    public class AppManagerController : Controller
    {
        //
        // GET: /AppManager/
        public ActionResult Index()
        {
            return View();
        }

        
	}
}
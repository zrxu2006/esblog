using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Infrastructure
{
    public static class EsblogControllerExtension
    {
        public static int? GetUserId(this Controller controller)
        {
            return (int?)controller.Session["id"];
        }

        public static void SetUserId(this Controller controller, int userId)
        {
            controller.Session["id"] = userId;
        }

        public static void ClearUserId(this Controller controller)
        {
            controller.Session["id"] = null;
        }
    }
}
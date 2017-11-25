using EsbLog.Web.Models;
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
            controller.Session["User"] = null;
        }

        public static bool IsManagerUser(this Controller controller)
        {
            var us = controller.Session["User"] as UserSessionModel;
            return us != null && us.IsManager;
        }

        public static void SetUserSession(this Controller controller, UserSessionModel model)
        {
            controller.SetUserId(model.UserId);
            controller.Session["User"] = model;
        }

        public static UserSessionModel GetUserSession(this Controller controller)
        {
            return controller.Session["User"] as UserSessionModel;
        }
    }
}
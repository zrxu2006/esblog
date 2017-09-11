using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Infrastructure
{
    public class EsblogExceptionFilterAttribute:FilterAttribute,IExceptionFilter
    {
        private static Logger _logger = LogManager.GetLogger("Esblog.Web");
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var error = string.Format("Controller:{0},Action:{1},Exception:{2}"
                                    , filterContext.RouteData.Values["controller"]
                                    , filterContext.RouteData.Values["action"]
                                    , filterContext.Exception.ToString());
                _logger.Error(error);
            }
            //throw new NotImplementedException();
        }
    }
}
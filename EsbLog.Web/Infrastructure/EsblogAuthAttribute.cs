using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace EsbLog.Web.Infrastructure
{
    public class EsblogAuthAttribute:AuthorizeAttribute,IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                //&& !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true)
                && !filterContext.Principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if ((filterContext.Result == null ||
                filterContext.Result is HttpUnauthorizedResult)
                && filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{
                        {"controller","Account" },
                        {"action","Login"},
                        {"returnUrl",filterContext.HttpContext.Request.RawUrl}
                    });
            }
        }
        
    }
}
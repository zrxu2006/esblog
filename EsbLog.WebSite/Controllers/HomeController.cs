using EsbLog.WebSite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.WebSite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login() 
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetCode()
        {
            //首先实例化验证码的类

            ValidateCode validateCode = new ValidateCode();

            //生成验证码指定的长度
            string code = validateCode.CreateValidateCode(5);

            //将验证码赋值给Session变量
            System.Web.HttpContext.Current.Session["ValidateCode"] = code;

            //创建验证码的图片

            byte[] bytes = validateCode.CreateValidateGraphic(code);

            //最后将验证码返回

            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult CheckCode(string userName,string password,string code)
        {
            return Content("asdfasdf");
        }
	}
}
using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsbLog.Web.App_Start
{
    public class EsblogWebConfig
    {
        public static void RegisterContentHeader(EsblogContentHeaderCollection headers)
        {
            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Index",
                ControllerName = "AppManage",
                HeaderLevel = HeaderLevelEnum.Menu,
                HeaderName = "应用管理"
            });

            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Add",
                ControllerName = "AppManage",
                HeaderLevel = HeaderLevelEnum.SubMenu,
                HeaderName = "新增"
            });

            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Edit",
                ControllerName = "AppManage",
                HeaderLevel = HeaderLevelEnum.SubMenu,
                HeaderName = "编辑"
            });

            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Index",
                ControllerName = "AppManage",
                HeaderLevel = HeaderLevelEnum.Menu,
                HeaderName = "应用管理"
            });

            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Index",
                ControllerName = "Account",
                HeaderLevel = HeaderLevelEnum.Menu,
                HeaderName = "账户管理"
            });
            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "Test1",
                ControllerName = "Account",
                HeaderLevel = HeaderLevelEnum.SubMenu,
                HeaderName = "测试1"
            });
            headers.Add(new ContentHeaderViewModel
            {
                ActionName = "test",
                ControllerName = "Account",
                HeaderLevel = HeaderLevelEnum.SubMenu,
                HeaderName = "测试"
            });
        }
    }
}
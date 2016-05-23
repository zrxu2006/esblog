using EsbLog.Tools.HttpRequest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Tools.HttpRequest
{
    /// <summary>
    /// 网络请求接口
    /// </summary>
    public interface IHttpRequest
    {
        /// <summary>
        /// 网络请求
        /// </summary>
        /// <returns></returns>
        string Request();
        /// <summary>
        /// 异步网络请求
        /// </summary>
        /// <param name="callback"></param>
        void RequestAsync(AsyncCallback<string> callback);
        /// <summary>
        /// 获取网络请求对象
        /// </summary>
        /// <returns></returns>
        List<Cookie> GetResponseObj();
    }
}

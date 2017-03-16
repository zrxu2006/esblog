using EsbLog.Tools.HttpRequest.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Tools.HttpRequest
{
   /// <summary>
    /// Performs a Http-Post request to the resource identified by the <c>Uri</c> with the <c>PostData</c>.
    /// <remarks>
    /// OAtuh parameters are not sent in the reqeuest.
    /// If an OAuth request is intended, please use <see cref="OAuthHttpPost"/> or <see cref="OAuthMultiPartHttpPost"/>.
    /// </remarks>
    /// </summary>
    /// <example>
    /// Below is an example of the post data:
    /// <![CDATA[
    /// action=submit&oauth_token%253Ddea035e505ac54b80c9c9077eebaafc7%2526oauth_callback%253Doob%2526from%253D%2526with_cookie%253D&oauth_token=dea035ea505ac54b280c9c9077deebaafc7&oauth_callback=oob&from=&forcelogin=
    /// ]]>
    /// </example>
    public class HttpPost : HttpRequest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpPost"/> with the specified <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The uri to identify a resource in the remote server.</param>
        public HttpPost(string uri)
            : base(uri)
        {
            base.Method = HttpMethod.Post;
            base.ContentType = Constants.PostContentType;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="HttpPost"/> with the specified <paramref name="uri"/> and <paramref name="postData"/>.
        /// </summary>
        /// <param name="uri">The uri to identify a resource in the remote server.</param>
        /// <param name="postData">The data to be posted.</param>
        public HttpPost(string uri, Dictionary<string, string> postDataDic)
            : this(uri)
        {
            int i = 0;
            StringBuilder strBPost = new StringBuilder();
            foreach (KeyValuePair<string, string> tempData in postDataDic)
            {
                if (i > 0)
                {
                    strBPost.AppendFormat("&{0}={1}", tempData.Key, tempData.Value);
                }
                else
                {
                    strBPost.AppendFormat("{0}={1}", tempData.Key, tempData.Value);
                }
                i++;
            }

            this.PostData = strBPost.ToString();
        }

        /// <summary>
        /// Gets or sets the data to post (in url-encoded format).
        /// </summary>
        public virtual string PostData
        {
            get;
            set;
        }

        /// <summary>
        /// When overridden in derived classes, writes post data into the request stream.
        /// </summary>
        /// <remarks>
        /// ASCII encoding is used to convert <see cref="PostData"/> into bytes. 
        /// Other encoding like UTF8 could cause unexpected issue in some cases like AddToFavorite.
        /// </remarks>
        /// <param name="reqStream">The request stream to write data with.</param>
        protected override void WriteBody(Stream reqStream)
        {
            if (!string.IsNullOrEmpty(PostData))
            {
                var dataBytes = ReqEncoding.GetBytes(PostData);
                reqStream.Write(dataBytes, 0, dataBytes.Length);
            }
        }

        /// <summary>
        /// <see cref="HttpRequest.AppendHeaders"/>
        /// </summary>
        protected override void AppendHeaders(WebHeaderCollection headers)
        {
            headers.Add(HttpRequestHeader.ContentEncoding, base.ReqEncoding.EncodingName);
            base.AppendHeaders(headers);
        }
    }
}

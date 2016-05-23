using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Tools.HttpRequest
{
    public class UploadFile
    {
        public string UploadProductImg(Stream fileStream, string fileName)
        {
            string strReqUrl = ConfigurationManager.AppSettings["ImageServer"].ToString() + "UploadProductImage.aspx";
            return Upload(fileStream, fileName, strReqUrl);
        }
        public string UploadImage(Stream fileStream, string fileName)
        {
            string strReqUrl = ConfigurationManager.AppSettings["ImageServer"].ToString() + "UploadFile.aspx";
            return Upload(fileStream, fileName, strReqUrl);
        }
        public string Upload(Stream fileStream, string filename, string fileServer)
        {
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");//元素分割标记 
            StringBuilder sb = new StringBuilder();
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"bossfile\"; filename=\"" + filename + "\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");//value前面必须有2个换行  

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileServer);
            request.ContentType = "multipart/form-data; boundary=" + boundary;//其他地方的boundary要比这里多--  
            request.Method = "POST";

            //  FileStream fileStream = new FileStream(@"C:\Users\boss\Pictures\lologo.png", FileMode.OpenOrCreate, FileAccess.Read);

            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            //http请求总长度  
            request.ContentLength = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Dispose();
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse webResponse2 = request.GetResponse();

            string strHtml = RetrieveResponse(webResponse2);
            return strHtml;

        }
        protected virtual string RetrieveResponse(WebResponse webResponse)
        {
            var respContent = string.Empty;

            var respStream = webResponse.GetResponseStream();
            using (StreamReader reader = new StreamReader(respStream, Encoding.UTF8))
            {
                respContent = reader.ReadToEnd();

            }
            webResponse.Close();

            return respContent;
        }
    }
}

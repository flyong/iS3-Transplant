using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client.Service
{
    public static class WebApiCaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string HttpDelete(string url, string body)
        {
            return CommonHttp(url, "Delete", body);
        }
        public static string HttpPost(string url, string body)
        {
            return CommonHttp(url, "Post", body);
        }
        public static string HttpPut(string url, string body)
        {
            return CommonHttp(url, "Put", body);
        }
        public static string CommonHttp(string url, string type, string body)
        {
            try 
            {

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = type;
                request.Accept = "application/json, text/javascript, */*"; //"text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json; charset=utf-8";

                request.Headers.Add("token:" + Globals.token);

                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                var res = (HttpWebResponse)ex.Response;
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                sb.Append(sr.ReadToEnd());
                //string ssb = sb.ToString();
                throw new Exception(sb.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

/// <summary>
/// Get Method
/// </summary>
/// <param name="url"> 地址</param>
/// <param name="needtoken">是否需要token验证</param>
/// <returns></returns>
        public static string HttpGet(string url, bool needtoken)
        {
            try
            {
                if (ServiceConfig.NeedCache)
                {
                    //缓存判断
                    if (iS3Cache.checkIfExist(url))
                    {
                        if (iS3Cache.CheckIfLastet(url))
                        {
                            return iS3Cache.GetFromCache(url);
                        }
                    }
                }
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                myRequest.Timeout = 20000;
                if (needtoken)
                {
                    myRequest.Headers.Add("token:" + Globals.token);
                }
                HttpWebResponse myResponse = null;

                myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                if (ServiceConfig.NeedCache)
                {
                    //缓存保存
                    iS3Cache.SaveToCache(url, content);
                }
                return content;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}

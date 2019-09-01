using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace iS3.Core.Client.Service
{
    public class FileService
    {
        public static  async Task<string> DownLoad(string DestnationPath, string project, string fileName)
        {


            try
            {
                string url = ServiceConfig.BaseURL + string.Format(ServiceConfig.fileFromat, project, fileName);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                myRequest.Timeout = 20000;
                HttpWebResponse myResponse = null;
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                Stream responseStream = myResponse.GetResponseStream();
                //判断是否报错
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                responseStream.Close();

                if  (content.Contains("error"))
                {
                    JObject Jobj = JObject.Parse(content);
                    string error = Jobj["error"].ToString();                 
                    return error;
                }

                //返回正常，再一次请求
                HttpWebRequest myfileRequest = (HttpWebRequest)WebRequest.Create(url);
                myfileRequest.Method = "GET";
                myfileRequest.Timeout = 20000;
                HttpWebResponse myfileResponse = (HttpWebResponse)myfileRequest.GetResponse();
                Stream responsefileStream = myfileResponse.GetResponseStream();


                //读取图片
                Stream fsStream = new FileStream(DestnationPath +"\\"+ fileName, FileMode.Create);
                byte[] buffer = new byte[1024 * 1024];
                while (true)

                {
                    int read = responsefileStream.Read(buffer, 0, buffer.Length);

                    if (read <= 0) break;

                    fsStream.Write(buffer, 0, read);
                }

                responsefileStream.Close();
                fsStream.Close();
                return "下载成功";

            }
            catch (Exception ex)
            {
                return "下载出错："+ex.ToString();
            }

        }

        public static async Task<string> UpLoad(string resourcepath, string project)
        {
            string[] st;
            if (resourcepath.Contains('/'))
            {
                st = resourcepath.Split('/');
            }
            else
            {
                st = resourcepath.Split('\\');
            }
            string fileName = st[st.Length - 1];

            string url = ServiceConfig.BaseURL + string.Format(ServiceConfig.fileFromat, project, fileName);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "PUT";
            myRequest.Timeout = 20000;

            try
            {
                // MemoryStream resquestStream = new MemoryStream();
                Stream fileStream = new FileStream(resourcepath, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader brMyfile = new BinaryReader(fileStream);
                brMyfile.BaseStream.Seek(0, SeekOrigin.Begin);
                byte[] bytes = brMyfile.ReadBytes(Convert.ToInt32(fileStream.Length.ToString()));
                brMyfile.Close();
                myRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
                HttpWebResponse myResponse = null;
                myResponse = (HttpWebResponse)myRequest.GetResponse();

                Stream responseStream = myResponse.GetResponseStream();

                //判断是否报错
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                if (content.Contains("error"))
                {
                    JObject Jobj = JObject.Parse(content);
                    string error = Jobj["error"].ToString();
                    if (error == "")
                        return "上传成功";
                    else
                        return error;
                }
                return "上传成功";

            }
            catch (Exception ex)
            {
                return "上传失败";
            }

        }

        public static async Task<string> UpLoad(string resourcepath, string standardname,string project)
        {
            string url = ServiceConfig.BaseURL + string.Format(ServiceConfig.fileFromat, project, standardname);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "PUT";
            myRequest.Timeout = 60000;

            try
            {
                // MemoryStream resquestStream = new MemoryStream();
                Stream fileStream = new FileStream(resourcepath, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader brMyfile = new BinaryReader(fileStream);
                brMyfile.BaseStream.Seek(0, SeekOrigin.Begin);
                byte[] bytes = brMyfile.ReadBytes(Convert.ToInt32(fileStream.Length.ToString()));
                brMyfile.Close();
                myRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
                HttpWebResponse myResponse = null;
                myResponse = (HttpWebResponse)myRequest.GetResponse();

                Stream responseStream = myResponse.GetResponseStream();

                //判断是否报错
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string content = reader.ReadToEnd();
                if (content.Contains("error"))
                {
                    JObject Jobj = JObject.Parse(content);
                    string error = Jobj["error"].ToString();
                    if (error == "")
                        return "上传成功";
                    else
                        return error;
                }
                return "上传成功";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
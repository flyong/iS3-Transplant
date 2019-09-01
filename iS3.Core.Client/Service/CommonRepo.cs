using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;

namespace iS3.Core.Client.Service
{
    public class CommonRepo
    {

        //登录校验
        //
        public static async Task<ResultData> GetLoginResult(string username, string password)
        {
            try
            {
                string body = JsonConvert.SerializeObject(new { Username = username, Password = password });
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPost(ServiceConfig.BaseURL + ServiceConfig.loginURL, body));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<ResultData>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<DataSourceType>> GetDataSourceTypes()
        {
            try
            {
                string result = await Task.Run(() =>
                                  WebApiCaller.HttpGet(ServiceConfig.BaseURL + ServiceConfig.datasourcetypeURL, true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<DataSourceType>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<DataSourceInfo> PostDataSourceInfo(DataSourceInfo model)
        {
            try
            {
                string body = JsonConvert.SerializeObject(model);
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPost(ServiceConfig.BaseURL + ServiceConfig.datasourceinfoURL, body));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<DataSourceInfo>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //获取工程列表信息
        //
        public static async Task<List<ProjectList>> GetProjectList()
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + ServiceConfig.projectlistURL, true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<ProjectList>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<List<string>> Getappendixnames(string url)
        {
            try
            {
                string result = await Task.Run(() =>
              WebApiCaller.HttpGet(url, true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<string>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static async Task<string> AddProjectList(ProjectList projectList)
        {
            try
            {
                string body = JsonConvert.SerializeObject(projectList);
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPost(ServiceConfig.BaseURL + ServiceConfig.projectlistURL, body));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<ProjectList> UpdateProjectList(ProjectList projectList)
        {
            try
            {
                string body = JsonConvert.SerializeObject(projectList);
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPut(ServiceConfig.BaseURL + ServiceConfig.projectlistURL, body));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<ProjectList>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<string> DeleteProjectList(ProjectList projectList)
        {
            try
            {
                string body = JsonConvert.SerializeObject(projectList);
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpDelete(ServiceConfig.BaseURL + ServiceConfig.projectlistURL, body));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //获取工程定义信息
        //
        public static async Task<ProjectInfo> GetProjectInfo(string project)
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.projectinfoFormat, project), true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<ProjectInfo>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //获取对象树-域列表
        //
        public static async Task<List<Domain>> GetDomains(string project)
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.projectdomainFormat, project), true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<Domain>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //获取对象组信息
        //
        public static async Task<List<ObjectsDefinition>> GetObjectsDefinition(string project, string domain)
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.projectobjectdefinitionFormat, project, domain), true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<ObjectsDefinition>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //获取对象树信息
        //
        public static async Task<List<TreeDefinition>> GetProjectTree(string project, string domain)
        {
            try
            {

                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.projecttreeFormat, project, domain), true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<TreeDefinition>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static async Task<TreeDefinition> AddProjectTree(string project, string domain, string objtype, int objid, int parentid)
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPost(ServiceConfig.BaseURL + string.Format(ServiceConfig.projecttreeAddFormat, project, domain, objtype, objid, parentid), ""));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<TreeDefinition>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<EngineeringMap>> GetEMaps(string project)
        {

            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.projectemapFormat, project), true));
                JObject obj = JObject.Parse(result);
                string data = obj["data"].ToString();
                return JsonConvert.DeserializeObject<List<EngineeringMap>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

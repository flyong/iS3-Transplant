using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iS3.Core;
using iS3.Core.Client.Service;
using iS3.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iS3.Core.Client
{
    public class RepositoryForClient
    {
        public static async Task<DGObject> RetrieveObj(DGObject _obj)
        {
            Type type = iS3Property.GetType(_obj.parent.parent.name, _obj.parent.definition.Type);
            Type myGenericClassType = typeof(RepositoryForClient<>);
            DGObject obj = new DGObject();
            var tt = Activator.CreateInstance(myGenericClassType.MakeGenericType(new Type[] { type }));
            var task = myGenericClassType.MakeGenericType(new Type[] { type }).
                GetMethod("RetrieveObj", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).
                Invoke(tt, new object[] { Globals.project.projectID, _obj }) as Task;
            await task;
            obj = task.GetType().GetProperty("Result").GetValue(task, null) as DGObject;
            obj.parent = _obj.parent;
            return obj;
        }
        public static async Task<List<DGObject>> RetrieveObjs(DGObjects objs)
        {
            Type type = iS3Property.GetType(objs.parent.name, objs.definition.Type);
            Type myGenericClassType = typeof(RepositoryForClient<>);
            var tt = Activator.CreateInstance(myGenericClassType.MakeGenericType(new Type[] { type }));
            var task = myGenericClassType.MakeGenericType(new Type[] { type }).
                GetMethod("RetrieveObjs", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).
                Invoke(tt, new object[] { Globals.project.projectID, objs }) as Task;
            await task;

            List<DGObject> dGObjects = (task.GetType().GetProperty("Result").GetValue(task, null) as IEnumerable).Cast<DGObject>().ToList();
            foreach (DGObject o in dGObjects)
            {
                o.parent = objs;
            }
            return dGObjects;
        }
        public static async Task<DGObject> Create(DGObject _obj)
        {
            Type type = iS3Property.GetType(_obj.parent.parent.name, _obj.parent.definition.Type);
            Type myGenericClassType = typeof(RepositoryForClient<>);
            DGObject obj = new DGObject();
            var tt = Activator.CreateInstance(myGenericClassType.MakeGenericType(new Type[] { type }));
            var task = myGenericClassType.MakeGenericType(new Type[] { type }).
                GetMethod("Create", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).
                Invoke(tt, new object[] { Globals.project.projectID, _obj }) as Task;
            await task;
            obj = task.GetType().GetProperty("Result").GetValue(task, null) as DGObject;
            obj.parent = _obj.parent;
            return obj;
        }
        public static async Task<DGObject> Create(DGObject _obj, string domainName, string objType)
        {
            Type type = iS3Property.GetType(domainName, objType);
            Type myGenericClassType = typeof(RepositoryForClient<>);
            DGObject obj = new DGObject();
            var tt = Activator.CreateInstance(myGenericClassType.MakeGenericType(new Type[] { type }));
            var task = myGenericClassType.MakeGenericType(new Type[] { type }).
                GetMethod("CreateModel", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).
                Invoke(tt, new object[] { _obj, domainName, objType }) as Task;
            await task;
            obj = task.GetType().GetProperty("Result").GetValue(task, null) as DGObject;
            //obj.Parent = _obj.Parent;
            return obj;
        }
        public static async Task<int> Delete(DGObject _obj, string domainName, string objType)
        {
            Type type = iS3Property.GetType(domainName, objType);
            Type myGenericClassType = typeof(RepositoryForClient<>);

            var tt = Activator.CreateInstance(myGenericClassType.MakeGenericType(new Type[] { type }));
            var task = myGenericClassType.MakeGenericType(new Type[] { type }).
                GetMethod("DeleteModel", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).
                Invoke(tt, new object[] { _obj, domainName, objType }) as Task;
            await task;
            int result = int.Parse(task.GetType().GetProperty("Result").GetValue(task, null).ToString());
            //obj.Parent = _obj.Parent;
            return result;
        }
    }
    public class RepositoryForClient<T> : IRepository<T> where T : class, new()
    {
        public virtual async Task<T> RetrieveObj(string project, DGObject obj)
        {
            try
            {
                string domain = obj.parent.parent.name;
                string dgobjecttype = obj.parent.definition.Type;
                int id = obj.ID;
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), project, id), true));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual async Task<List<T>> RetrieveObjs(string project, DGObjects objs)
        {
            try
            {
                string domain = objs.parent.name;
                string dgobjecttype = objs.definition.Type;
                int objsid = objs.definition.ID;
                string filter = MessageConverter.EnCode(objs.definition.Filter);
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpGet(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectsFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), project, objsid, filter), true));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Task<List<T>> BatchCreate(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<int> BatchDelete(List<T> models)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<T> CreateModel(T model, string domain, string dgobjecttype)
        {
            try
            {
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPut(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectRootFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), Globals.project.projectID), JsonConvert.SerializeObject(model)));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual async Task<T> Create(T model)
        {
            try
            {
                string domain = (model as DGObject).parent.parent.name;
                string dgobjecttype = (model as DGObject).parent.definition.Type;
                int id = (model as DGObject).ID;
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpPost(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), Globals.project.projectID, id), JsonConvert.SerializeObject(model)));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<int> Delete(T model)
        {
            try
            {
                string domain = (model as DGObject).parent.parent.name;
                string dgobjecttype = (model as DGObject).parent.definition.Type;
                int id = (model as DGObject).ID;
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpDelete(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), Globals.project.projectID, id), JsonConvert.SerializeObject(model)));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<int>(data);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public virtual async Task<int> DeleteModel(T model, string domain, string dgobjecttype)
        {
            try
            {
                int id = (model as DGObject).ID;
                //网络请求 
                string result = await Task.Run(() =>
                   WebApiCaller.HttpDelete(ServiceConfig.BaseURL + string.Format(ServiceConfig.DGObjectFormat,
                    domain.ToLower(), dgobjecttype.ToLower(), Globals.project.projectID,id), JsonConvert.SerializeObject(model)));
                JObject Jobj = JObject.Parse(result);
                string data = Jobj["data"].ToString();
                return JsonConvert.DeserializeObject<int>(data);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public virtual async Task<T> Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<T>> RetrieveByObjs(int objsid, string filter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}

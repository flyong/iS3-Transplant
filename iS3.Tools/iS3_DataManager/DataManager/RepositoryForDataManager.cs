using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.MiniServer;
using System.Data.Entity;

namespace iS3_DataManager.DataManager
{
    public class RepositoryForDataManager<T> : IRepository<T> where T : iS3AreaHandle, new()
    {
        public DbContext context { get; set; }
        public string project;
        //统一入口
        public static RepositoryForDataManager<T> GetInstance(string project)
        {
            try
            {
                //反射获取Context
                //
                string path = "iS3_DataManager.ObjectModels";//命名空间.类型名,程序集
                Type o = Type.GetType(path);//加载类型
                if (o != null)
                {
                    object obj = Activator.CreateInstance(o, project);
                    (obj as RepositoryForDataManager<T>).project = project;
                    return obj as RepositoryForDataManager<T>;
                }
                else
                {
                    RepositoryForDataManager<T> repo = new RepositoryForDataManager<T>(project);
                    repo.project = project;
                    return repo;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public RepositoryForDataManager(string project)
        {
            try
            {
                //反射获取Context
                //
                string path = "iS3_DataManager.ObjectModels";//命名空间.类型名,程序集
                Type o = Type.GetType(path);//加载类型
                object obj = Activator.CreateInstance(o, project); //根据类型创建实例
                context = obj as DbContext;
            }
            catch (Exception ex)
            {

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

        public Task<T> Create(T model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(T model)
        {
            throw new NotImplementedException();
        }

        public Task<T> Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> RetrieveByObjs(int objsid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}

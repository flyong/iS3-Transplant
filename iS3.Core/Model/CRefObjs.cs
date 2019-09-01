using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace iS3.Core.Model 
{
    //用于描述对象嵌套关系的自定义数据结构
    public class CRefObjs
    {
        //指向的对象组对象定义ID
        public int RefObjsID { get; set; }
        //对象组内成员ID列表
        public List<int> RefObjsIDs { get; set; }
        //标准化的插入操作
        public void insertID(int ObjID)
        {
            if (RefObjsIDs == null) RefObjsIDs = new List<int>();
            RefObjsIDs.Add(ObjID);
        }
        public void insertID(List<int> ObjIDs)
        {
            if (RefObjsIDs!=null)
            {
                foreach (int key in ObjIDs)
                {
                    insertID(key);
                }
            }
        }
        //标准化的更新操作
        public void Update(int OldObjID, int NewObjID)
        {
            if (RefObjsIDs == null) return;
            for (int i = 0; i < RefObjsIDs.Count; i++)
            {
                if (RefObjsIDs[i] == OldObjID)
                {
                    RefObjsIDs[i] = NewObjID;
                    return;
                }
            }
        }
        //标准化的删除操作
        public void Remove(int ObjID)
        {
            if (RefObjsIDs == null) return;
            RefObjsIDs.Remove(ObjID);
        }

        public static CRefObjs DeserializeToRefObjs(string JsonStr)
        {
            JsonStr = JsonStr.Replace("\"", "");
            return JsonConvert.DeserializeObject<CRefObjs>(JsonStr);
        }
        public static string SerializeToJson(CRefObjs cRefObjs)
        {
            return JsonConvert.SerializeObject(cRefObjs);
        }
    }
}

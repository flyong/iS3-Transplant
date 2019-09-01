using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class iS3Property
    {
        public static object GetInstance(string domain, string DGObject)
        {
            string dllName = string.Format("iS3.{0}", domain);
            if (!DllImport.assemblyDict.ContainsKey(dllName))
            {
                return null;
            }
            string nameSpace = string.Format("iS3.{0}.Model.{1}", domain, DGObject);
            Assembly assembly = DllImport.assemblyDict[dllName];
            Type t = assembly.GetType(nameSpace);
            return assembly.CreateInstance(nameSpace);
        }
        public static List<T> Convert<T>(List<DGObject> objs) where T : class
        {
            List<T> list = new List<T>();
            foreach (DGObject obj in objs)
            {
                list.Add(obj as T);
            }
            return list;
        }
        public static Type GetType(string domain, string DGObject)
        {

            string dllName = string.Format("iS3.{0}", domain);
            if (!DllImport.assemblyDict.ContainsKey(dllName))
            {
                return null;
            }
            string nameSpace = string.Format("iS3.{0}.Model.{1}", domain, DGObject);
            Assembly assembly = DllImport.assemblyDict[dllName];
            Type t = assembly.GetType(nameSpace);
            return t;
        }
        public static List<PropertyDef> GetProperty<T>(T model)
        {
            string typeName = model.GetType().Name;
            List<PropertyDef> propertyDefs = new List<PropertyDef>();
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            int index = 0;
            foreach (PropertyInfo item in propertyInfos)
            {
                PropertyDef def = new PropertyDef()
                {
                    id = index++,
                    key = item.Name,
                    value = (item.GetValue(model, null) == null ? "" : item.GetValue(model, null)).ToString(),
                    type = item.PropertyType
                };
                propertyDefs.Add(def);

                iS3EntityIdenty(def, item);
            }
            return propertyDefs;
        }

        public static void iS3EntityIdenty(PropertyDef def, PropertyInfo propertyInfo)
        {
            Type basetype = typeof(iS3Entity);
            if ((propertyInfo.PropertyType.IsGenericType))
            {
                var columnType = propertyInfo.PropertyType.GetGenericArguments()[0];
                if (basetype.IsAssignableFrom(columnType))
                {
                    def.isenumable = true;
                    def.type = columnType;
                }
                //object genericList = CreateGeneric(typeof(List<>), typeof(EC));
                //genericList.GetType().InvokeMember("Add", BindingFlags.Default | BindingFlags.InvokeMethod, null, genericList, new object[] { o1，o2，o3 });
            }
        }

        public static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
            return Activator.CreateInstance(specificType, args);
        }
    }
}

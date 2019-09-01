using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iS3.Core.Model
{
    /// <summary>
    /// 基类对象定义
    /// </summary>
    public class DGObject:iS3Entity
    {
        /// <summary>
        /// 父对象DGObjects
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public DGObjects parent { get; set; }
        /// <summary>
        /// 对象名称
        /// </summary>
        [NotMapped]
        public string name { get; set; }


        // Summary:
        //     Chart views of the objects
        // Remarks:
        //   
        public virtual async Task<List<FrameworkElement>> chartViews(
            IEnumerable<DGObject> objs, double width, double height)
        {
            return null;
        }
        public static List<T> Transfer<T>(List<DGObject> objList) where T:class
        {
            List<T> list = new List<T>();
            foreach (DGObject _obj in objList)
            {
                list.Add(_obj as T);
            }
            return list;
        }
    }
}

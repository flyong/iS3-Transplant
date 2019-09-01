using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace iS3.Core.Model
{
    /// <summary>
    /// 对象组定义
    /// </summary>
    public class ObjectsDefinition
    {
        public int ID { get; set; }
        public string Name_Chs { get; set; }
        public string Name_En { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Domain { get; set; }
        public Nullable<int> GISLayerID { get; set; }
        public Nullable<int> DBID { get; set; }
        public string TableNameSQL { get; set; }
        public string OrderSQL { get; set; }
        public string ConditionSQL { get; set; }
        public string Remark { get; set; }
        public string Filter { get; set; }
    }
}

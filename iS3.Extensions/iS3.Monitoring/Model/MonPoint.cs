using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace iS3.Monitoring.Model
{
    [Table("Monitoring_MonPoint")]
    public class MonPoint:DGObject
    {
        public string Name { get; set; }
        public Nullable<int> MonPointType { get; set; }
        public Nullable<decimal> XCoordinate { get; set; }
        public Nullable<decimal> YCoordinate { get; set; }
        public Nullable<decimal> ZCoordinate { get; set; }
        public Nullable<int> MonGroupID { get; set; }
        public string SensorName { get; set; }
        public Nullable<decimal> IniValue { get; set; }
        public Nullable<System.DateTime> STime { get; set; }
        public Nullable<int> PerInfoID { get; set; }
        public string Remark { get; set; }
        //ignore
        [NotMapped]
        public List<MonData> monDatas { get; set; } = new List<MonData>();
    }
}
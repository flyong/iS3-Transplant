using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace iS3.Monitoring.Model
{
    [Table("Monitoring_MonData")]
    public class MonData:DGObject
    {
        public Nullable<int> MonPointID { get; set; }
        public Nullable<decimal> Reading { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<System.DateTime> DataTime { get; set; }
        public Nullable<System.DateTime> SysTime { get; set; }
    }
}
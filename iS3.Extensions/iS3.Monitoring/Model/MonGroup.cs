using iS3.Core;
using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace iS3.Monitoring.Model
{
    [Table("Monitoring_MonGroup")]
    public class MonGroup:DGObject,IDGObjects
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> MonGroupType { get; set; }
        public string MonPointIDs { get; set; }
        public Nullable<int> MonProjectID { get; set; }
        public string RefSpecifications { get; set; }
        public string PerInfoIDs { get; set; }
        public string Remark { get; set; }

        //ignore
        [NotMapped]
        public List<MonPoint> MonPoints { get; set; } = new List<MonPoint>();
    }
}
using iS3.Core;
using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace iS3.Monitoring.Model
{
    [Table("Monitoring_MonProject")]
    public  class MonProject:DGObject, IDGObjects
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> PerInfoID { get; set; }
        public string MonInstInfoIDs { get; set; }
        public string PlanFile { get; set; }
        public string Remark { get; set; }


        public string MonGroupIDs { get; set; }
        //ignore
        [NotMapped]
        public List<MonGroup> MonGroups { get; set; } = new List<MonGroup>();

    }
}
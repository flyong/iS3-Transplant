using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace iS3.Monitoring.Model
{
    [Table("Monitoring_MonInstrument")]
    public class MonInstrument:DGObject
    {
        public string Name { get; set; }
        public Nullable<int> UnitID { get; set; }
        public string Remark { get; set; }
    }
}
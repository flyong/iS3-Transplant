using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Environment.Model
{
    [Table("Environment_PhreaticWater")]
    public class PhreaticWater:DGObject
    {
        public string SiteName { get; set; }
        public Nullable<double> AvBuriedDepth { get; set; }
        public Nullable<double> AvElevation { get; set; }
        public Nullable<int> StratumSectionID { get; set; }
    }
}

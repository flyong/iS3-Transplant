using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Environment.Model
{
    [Table("Environment_ConfinedWater")]
    public class ConfinedWater:DGObject
    {
        public string BoreholeName { get; set; }
        public string SiteName { get; set; }
        public Nullable<int> StrataSectionID { get; set; }
        public Nullable<double> TopElevation { get; set; }
        public Nullable<double> ObservationDepth { get; set; }
        public string StatumName { get; set; }
        public Nullable<double> Layer { get; set; }
        public Nullable<double> WaterTable { get; set; }
        public Nullable<System.DateTime> ObservationDate { get; set; } = new DateTime();
    }
}

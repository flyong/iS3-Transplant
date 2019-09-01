using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Environment.Model
{
    [Table("Environment_WaterProperty")]
    public class WaterProperty:DGObject
    {
        public string BoreholeName { get; set; }
        public Nullable<double> Cl { get; set; }
        public Nullable<double> SO4 { get; set; }
        public Nullable<double> Mg { get; set; }
        public Nullable<double> NH { get; set; }
        public Nullable<double> pH { get; set; }
        public Nullable<double> CO2 { get; set; }
        public string Corrosion { get; set; }
        public Nullable<int> StratumSectionID { get; set; }
    }
}

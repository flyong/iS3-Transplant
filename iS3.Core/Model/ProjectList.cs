using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    [Table("System_ProjectList")]
    public class ProjectList
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string CODE { get; set; }
        public string ProjectTitle { get; set; }
        public Nullable< int> DBID { get; set; }
        public string FileService { get; set; }
        public string AnalysisService { get; set; }
        public Nullable<int> DefaultMapID { get; set; }
        public Nullable<Decimal> X { get; set; }
        public Nullable<Decimal> Y { get; set; }
        public string ModuleIDs { get; set; }
        public string Remark { get; set; }
    }
}

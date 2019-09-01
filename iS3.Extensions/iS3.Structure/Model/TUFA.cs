using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;


namespace iS3.Structure.Model
{
    //路面基层
    [Table("Structure_TUFA")]
    public partial class TUFA : DGObject
    {


        public string ABLA_MATE { get; set; }
        
        public Nullable<int> ABLA_THIC { get; set; }
       
        public string ROAD_TYPE { get; set; }

       
        public string FOUN_MATE { get; set; }

        public string INVE_YN { get; set; }
    
    }
}

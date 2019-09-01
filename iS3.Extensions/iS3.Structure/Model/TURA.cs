using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    [Table("Structure_TURA")]
    //套拱
    public partial class TURA : DGObject
    {


        public string SECT_ID { get; set; }
  
        public  Nullable<bool> TURA_YN { get; set; }
     
        public string TURA_CON { get; set; }

        public Nullable<decimal> TURA_THIC { get; set; }

        public Nullable<decimal> TURA_RADI { get; set; }

        public Nullable<decimal> COVE_THIC { get; set; }
    }
}

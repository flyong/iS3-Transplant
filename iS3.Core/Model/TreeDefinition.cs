using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace iS3.Core.Model
{
    public class TreeDefinition
    {
        public int ID { get; set; }
        public string Name_Chs { get; set; }
        public string Name_En { get; set; }

        public int ParentID { get; set; }
        public int RefObjID { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string Filter { get; set; } = "";
        //ignore
        public List<TreeDefinition> Chillds { get; set; } = new List<TreeDefinition>();
    }
}

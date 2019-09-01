using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Client
{
    public class PropertyDef
    {
        public int  id{ get; set; }
        public string key { get; set; }
        public string value { get; set; } = null;
        public bool isenumable { get; set; } = false;
        //public List<PropertyDef> propertyDefs { get; set; } = new List<PropertyDef>();
        public Type type { get; set; } = null;
    }
}

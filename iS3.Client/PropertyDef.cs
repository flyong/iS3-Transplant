using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Client
{
    public class PropertyDef
    {
        public int  id{ get; set; }
        public string key { get; set; }
        public string value { get; set; } = null;
    }
}

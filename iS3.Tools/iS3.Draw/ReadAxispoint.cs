using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace iS3.Draw
{
    public class Axispoint
    {
        //轴线点坐标
        public  decimal pointx;
        public  decimal pointy;
        public  decimal pointz;
        //轴线点桩号
        public  string mileage;

        public Axispoint(decimal x,decimal y,decimal z,string m)
        {
            pointx = x;
            pointy = y;
            pointz = z;
            mileage = m;
        }
               
    }
}

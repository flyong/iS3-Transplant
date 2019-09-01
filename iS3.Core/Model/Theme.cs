using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace iS3.Core.Model
{
    //用于描述主题图
    public class ThemeView
    {
        public ThemeView(string st)
        {
            name = st;
            themesections = new List<ThemeSection>();
        }
        public string name { get; set; }
        public List<ThemeSection> themesections { get; set; }

    }
    public class ThemeSection
    {
        public string name { get; set; }
        public List<ThemeLayer> themelayers { get; set; }
        public List<string> layernames { get; set; }
        public ThemeSection()
        {
            themelayers = new List<ThemeLayer>();
            layernames = new List<string>();
        }
    }
    public class ThemeLayer
    {
        
        public string tpkname { get; set; }
        public string geodatabasename { get; set; }
        public List<string> layernames { get; set; }

        public ThemeLayer()
        {
            layernames = new List<string>();
        }
    }
}


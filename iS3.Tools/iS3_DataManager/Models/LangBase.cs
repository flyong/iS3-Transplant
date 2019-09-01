using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.Models
{
    /// <summary>
    /// the language string of this Domain display name
    /// ["en":"Borehole","chs":"钻孔"]
    /// </summary>
    public class LangBase
    {
        public string LangStr
        {
            get;set;            
        }


        public static string ConvertToLanStr(LangDict langdict)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(langdict);
        }
        public class LangDict :Dictionary<LangType, string>
        {
        }
    }

}

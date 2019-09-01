using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.StandardManager
{
    public class DataType
    {
        public  Dictionary<string, string> Gettype { get; set; }
        public DataType()
        {
        	Dictionary<string,string> GetType=new Dictionary<string,string>();
            GetType.Add("ID","string");
            GetType.Add("0DP","int");
            GetType.Add("2DP","double");
            GetType.Add("PA","string");
            GetType.Add("DMS","double");
            GetType.Add("1DP","double");
            GetType.Add("2SF","double");
            GetType.Add("3DP","double");
            GetType.Add("3SF","string");
            GetType.Add("DT","string");
            GetType.Add("INT","int");
            GetType.Add("MC","double");
            GetType.Add("T","string");
            GetType.Add("Y/N","bool");
            GetType.Add("无","string");
            GetType.Add("string","string");
            GetType.Add("Deg", "double");
            GetType.Add("deg", "double");
            GetType.Add("X", "string");
            GetType.Add("DateTime", "string");
            GetType.Add("decimal", "double");
            this.Gettype=GetType;            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    public partial class ResultData
    {
        public int result { get; set; }
        public string description { get; set; }
        public LoginData data { get; set; }
        public ResultData()
        {

        }
        public ResultData(LoginData data)
        {
            this.data = data;
        }
        public ResultData(int result, string description)
        {
            this.result = result;
            this.description = description;
        }
    }
    public partial class LoginData
    {
        public int id { get; set; }
        public string username { get; set; }
        public string token { get; set; }
    }
}

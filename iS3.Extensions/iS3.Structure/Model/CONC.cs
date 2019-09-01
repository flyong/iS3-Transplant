using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //初喷混凝土
    [Table("Structure_CONC")]
    public partial class CONC : DGObject
    {
        //衬砌类型
        public string LINE_TYPE { get; set; }
        //喷射混凝土型号
        public string CONC_TYPE { get; set; }
        //喷射混凝土厚度
        public Nullable<int> CONC_THIC { get; set; }
        //喷射混凝土位置
        public string CONC_SITU { get; set; }
        //是否设置仰拱
        public  string INVE_YN { get; set; }
        //预留变形量
        public Nullable<int> DEFO_THIC { get; set; }
               
    }
}

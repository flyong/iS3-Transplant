using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Construction.Model
{
    //围岩变更
    [Table("Construction_CHAG")]
    public partial class CHAG : DGObject
    {
        //处理卡编号
        public string CHAG_NUMB { get; set; }
        //工程名称
        public string CHAG_NAME { get; set; }
        //里程桩号(变更位置)
        public string CHAG_CHAI { get; set; }
        //变更类型
        public string CHAG_TYPE1 { get; set; }
        //原衬砌类别
        public string CHAG_PRIM { get; set; }
        //变更后衬砌类别
        public string CHAG_PRES { get; set; }
        //变更原因
        public string CHAG_REAS { get; set; }
        //处理意见
        public string CHAG_MANA { get; set; }
        //处理卡签发日期
        public string CHAG_DATE1 { get; set; }
        //变更令签发日期
        public string CHAG_DATE2 { get; set; }
        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }


    }
}

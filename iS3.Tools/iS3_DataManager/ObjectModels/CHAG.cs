using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_CHAG")]
	public class CHAG:DGObject
 	{ 
/// <summary>
///
///处理卡编号 </summary>
		public string CHAG_NUMB {get;set;}
/// <summary>
///
///工程名称 </summary>
		public string CHAG_NAME {get;set;}
/// <summary>
///
///里程桩号 </summary>
		public string CHAG_CHAI {get;set;}
/// <summary>
///
///变更类型 </summary>
		public string CHAG_TYPE1 {get;set;}
/// <summary>
///
///原衬砌类别 </summary>
		public string CHAG_PRIM {get;set;}
/// <summary>
///
///变更后衬砌类别 </summary>
		public string CHAG_PRES {get;set;}
/// <summary>
///
///变更原因 </summary>
		public string CHAG_REAS {get;set;}
/// <summary>
///
///处理意见 </summary>
		public string CHAG_MANA {get;set;}
/// <summary>
///
///处理卡签发日期 </summary>
		public string CHAG_DATE1 {get;set;}
/// <summary>
///
///变更令签发日期 </summary>
		public string CHAG_DATE2 {get;set;}
/// <summary>
///
///关联文件（现场日志表） </summary>
		public string FILE_FSET {get;set;}
	}
}
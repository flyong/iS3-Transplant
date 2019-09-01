using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ASP")]
	public class ASP:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string ASP_NO {get;set;}
/// <summary>
///
///ASP_ID </summary>
		public string ASP_ID {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string ASP_INTE {get;set;}
/// <summary>
///
///超前支护方案 </summary>
		public string ASP_SUPP {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string ASP_SRL {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
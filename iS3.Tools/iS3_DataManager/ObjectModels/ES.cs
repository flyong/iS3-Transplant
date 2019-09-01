using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ES")]
	public class ES:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string ES_NO {get;set;}
/// <summary>
///
///ES_ID </summary>
		public string ES_ID {get;set;}
/// <summary>
///
///掌子面桩号 </summary>
		public string ES_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string ES_INTE {get;set;}
/// <summary>
///
///开挖方法 </summary>
		public string ES_EXCA {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string ES_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string ES_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
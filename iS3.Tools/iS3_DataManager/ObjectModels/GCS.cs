using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GCS")]
	public class GCS:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string GCS_NO {get;set;}
/// <summary>
///
///GCS_ID </summary>
		public string GCS_ID {get;set;}
/// <summary>
///
///掌子面桩号 </summary>
		public string GCS_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string GCS_INTE {get;set;}
/// <summary>
///
///注浆施工方案 </summary>
		public string GCS_SUPP {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string GCS_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string GCS_RGCSU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
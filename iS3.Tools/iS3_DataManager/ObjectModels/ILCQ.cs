using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ILCQ")]
	public class ILCQ:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string ILCQ_NO {get;set;}
/// <summary>
///
///ILCQ_ID </summary>
		public string ILCQ_ID {get;set;}
/// <summary>
///
///衬砌类型 </summary>
		public string ILCQ_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string ILCQ_INTE {get;set;}
/// <summary>
///
///衬砌设计厚度 </summary>
		public string ILCQ_GESC {get;set;}
/// <summary>
///
///衬砌实际厚度 </summary>
		public string ILCQ_WATE {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string ILCQ_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string ILCQ_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
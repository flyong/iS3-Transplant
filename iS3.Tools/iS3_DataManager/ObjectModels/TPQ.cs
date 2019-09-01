using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TPQ")]
	public class TPQ:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string TPQ_NO {get;set;}
/// <summary>
///
///TPQ_ID </summary>
		public string TPQ_ID {get;set;}
/// <summary>
///
///锚杆类型 </summary>
		public string TPQ_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string TPQ_INTE {get;set;}
/// <summary>
///
///锚杆设计数量 </summary>
		public string TPQ_GESC {get;set;}
/// <summary>
///
///锚杆实际数量 </summary>
		public string TPQ_WATE {get;set;}
/// <summary>
///
///锚杆设计长度 </summary>
		public string TPQ_SURR {get;set;}
/// <summary>
///
///锚杆实际长度 </summary>
		public string TPQ_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
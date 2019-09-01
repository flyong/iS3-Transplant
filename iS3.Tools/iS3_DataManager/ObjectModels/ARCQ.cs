using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ARCQ")]
	public class ARCQ:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string ARCQ_NO {get;set;}
/// <summary>
///
///ARCQ_ID </summary>
		public string ARCQ_ID {get;set;}
/// <summary>
///
///锚杆类型 </summary>
		public string ARCQ_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string ARCQ_INTE {get;set;}
/// <summary>
///
///锚杆设计数量 </summary>
		public string ARCQ_GESC {get;set;}
/// <summary>
///
///锚杆实际数量 </summary>
		public string ARCQ_WATE {get;set;}
/// <summary>
///
///锚杆设计长度 </summary>
		public string ARCQ_SURR {get;set;}
/// <summary>
///
///锚杆实际长度 </summary>
		public string ARCQ_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
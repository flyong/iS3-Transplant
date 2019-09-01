using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SCHE")]
	public class SCHE:DGObject
 	{ 
/// <summary>
///
///工程ID </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///标段号 </summary>
		public string PROG_NAME {get;set;}
/// <summary>
///
///左右幅 </summary>
		public string PROG_LORR {get;set;}
/// <summary>
///
///记录时间 </summary>
		public string PROG_DATE {get;set;}
/// <summary>
///
///终点桩号 </summary>
		public string PROG_END {get;set;}
/// <summary>
///
///施工面进度 </summary>
		public string PROG_SGJD {get;set;}
/// <summary>
///
///超前支护进度 </summary>
		public string PROG_CQJD {get;set;}
/// <summary>
///
///初衬进度 </summary>
		public string PROG_CCJD {get;set;}
/// <summary>
///
///二衬进度 </summary>
		public string PROG_ECJD {get;set;}
/// <summary>
///
///关联文件（现场日志表） </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///仰拱进度 </summary>
		public string PROG_YGJD {get;set;}
	}
}
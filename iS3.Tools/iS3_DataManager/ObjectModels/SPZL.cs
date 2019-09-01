using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SPZL")]
	public class SPZL:DGObject
 	{ 
/// <summary>
///
///标段号 </summary>
		public string SPZL_SECTION {get;set;}
/// <summary>
///
///上传者 </summary>
		public string SPZL_UPLOADER {get;set;}
/// <summary>
///
///视频时间 </summary>
		public string SPZL_DATE {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string SPZL_ZHQJ {get;set;}
/// <summary>
///
///视频名称 </summary>
		public string SPZL_SPMC {get;set;}
/// <summary>
///
///视频描述 </summary>
		public string SPZL_DISC {get;set;}
/// <summary>
///
///关联文件（现场日志表） </summary>
		public string FILE_FSET {get;set;}
	}
}
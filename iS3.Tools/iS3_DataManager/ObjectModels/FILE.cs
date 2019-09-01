using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_FILE")]
	public class FILE:DGObject
 	{ 
/// <summary>
///
///文件集引用 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///文件名 </summary>
		public string FILE_NAME {get;set;}
/// <summary>
///
///内容描述 </summary>
		public string FILE_DESC {get;set;}
/// <summary>
///
///文件格式 </summary>
		public string FILE_TYPE {get;set;}
/// <summary>
///
///设计程序和版本号 </summary>
		public string FILE_PROG {get;set;}
/// <summary>
///
///文件类型 </summary>
		public string FILE_DOCT {get;set;}
/// <summary>
///
///时间 </summary>
		public string FILE_DATE {get;set;}
	}
}
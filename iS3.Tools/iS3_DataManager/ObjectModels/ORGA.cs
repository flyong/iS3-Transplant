using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ORGA")]
	public class ORGA:DGObject
 	{ 
/// <summary>
///
///组织ID </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///组织名称 </summary>
		public string ORGA_NAME {get;set;}
/// <summary>
///
///组织代码 </summary>
		public string ORGA_CODE {get;set;}
/// <summary>
///
///组织类型 </summary>
		public string ORGA_TYPE {get;set;}
/// <summary>
///
///组织描述 </summary>
		public string ORGA_DESC {get;set;}
/// <summary>
///
///备注 </summary>
		public string ORGA_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
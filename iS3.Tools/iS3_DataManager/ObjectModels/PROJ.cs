using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PROJ")]
	public class PROJ:DGObject
 	{ 
/// <summary>
///
///工程ID </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///工程名称 </summary>
		public string PROJ_NAME {get;set;}
/// <summary>
///
///建设目的 </summary>
		public string PROJ_PURP {get;set;}
/// <summary>
///
///地理位置描述 </summary>
		public string PROJ_LOCA {get;set;}
/// <summary>
///
///项目持续时间 </summary>
		public string PROJ_TRND {get;set;}
/// <summary>
///
///业主 </summary>
		public string PROJ_CLNT {get;set;}
/// <summary>
///
///建设单位 </summary>
		public string PROJ_CONT {get;set;}
/// <summary>
///
///项目经理 </summary>
		public string PROJ_MNGR {get;set;}
/// <summary>
///
///合同 </summary>
		public string PROJ_COND {get;set;}
/// <summary>
///
///备注 </summary>
		public string PROJ_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
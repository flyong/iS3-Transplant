using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_EPRO")]
	public class EPRO:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///已有工程区ID </summary>
		public string EPRO_ID {get;set;}
/// <summary>
///
///已有工程类型 </summary>
		public string EPRO_TYPE {get;set;}
/// <summary>
///
///使用情况 </summary>
		public string EPRO_SERV {get;set;}
/// <summary>
///
///分布范围 </summary>
		public string EPRO_DSRG {get;set;}
/// <summary>
///
///与线路关系 </summary>
		public string EPRO_RELA {get;set;}
/// <summary>
///
///备注 </summary>
		public string EPRO_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
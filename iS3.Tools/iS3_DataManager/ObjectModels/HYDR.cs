using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_HYDR")]
	public class HYDR:DGObject
 	{ 
/// <summary>
///
///工程ID </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///水系数量 </summary>
		public Nullable<int> HYDR_NMRV {get;set;}
/// <summary>
///
///水库数量 </summary>
		public Nullable<int> HYDR_NMRS {get;set;}
/// <summary>
///
///备注 </summary>
		public string HYDR_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
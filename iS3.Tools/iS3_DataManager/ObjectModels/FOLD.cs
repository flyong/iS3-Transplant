using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_FOLD")]
	public class FOLD:DGObject
 	{ 
/// <summary>
///
///褶皱ID </summary>
		public string FOLD_ID {get;set;}
/// <summary>
///
///褶皱名称 </summary>
		public string FOLD_NAME {get;set;}
/// <summary>
///
///褶皱类型 </summary>
		public string FOLD_TYPE {get;set;}
/// <summary>
///
///成因 </summary>
		public string FOLD_CAUS {get;set;}
/// <summary>
///
///轴面产状 </summary>
		public string FOLD_ATTD {get;set;}
/// <summary>
///
///与路线关系 </summary>
		public string FOLD_REL1 {get;set;}
/// <summary>
///
///线路位置 </summary>
		public string FOLD_REL2 {get;set;}
/// <summary>
///
///备注 </summary>
		public string FOLD_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
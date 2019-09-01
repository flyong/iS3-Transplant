using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_FRAC")]
	public class FRAC:DGObject
 	{ 
/// <summary>
///
///节理表编号 </summary>
		public string FRAC_SET {get;set;}
/// <summary>
///
///节理最大间距 </summary>
		public Nullable<int> FRAC_IMAX {get;set;}
/// <summary>
///
///节理平均间距 </summary>
		public Nullable<int> FRAC_IAVE {get;set;}
/// <summary>
///
///节理最小间距 </summary>
		public Nullable<int> FRAC_IMIN {get;set;}
/// <summary>
///
///节理指数（每延米节理数目） </summary>
		public Nullable<int> FRAC_INDX {get;set;}
/// <summary>
///
///备注 </summary>
		public string FRAC_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GMPG")]
	public class GMPG:DGObject
 	{ 
/// <summary>
///
///工程ID </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///地貌区ID </summary>
		public string GMPG_ID {get;set;}
/// <summary>
///
///分布范围 </summary>
		public string GMPG_DSRG {get;set;}
/// <summary>
///
///成因 </summary>
		public string GMPG_FMRS {get;set;}
/// <summary>
///
///类型 </summary>
		public string GMPG_TYPE {get;set;}
/// <summary>
///
///形态特征 </summary>
		public string GMPG_CHAR {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
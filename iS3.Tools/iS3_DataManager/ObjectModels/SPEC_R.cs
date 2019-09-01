using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SPEC_R")]
	public class SPEC_R:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///特殊性岩土区ID </summary>
		public string SPEC_ID {get;set;}
/// <summary>
///
///特殊性岩土类型 </summary>
		public string SPEC_TYPE {get;set;}
/// <summary>
///
///分布范围 </summary>
		public string SPEC_DSRG {get;set;}
/// <summary>
///
///面积 </summary>
		public Nullable<double> SPEC_AREA {get;set;}
/// <summary>
///
///工程地质性质 </summary>
		public string SPEC_EGP {get;set;}
/// <summary>
///
///与线路关系 </summary>
		public string SPEC_RELA {get;set;}
/// <summary>
///
///备注 </summary>
		public string SPEC_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
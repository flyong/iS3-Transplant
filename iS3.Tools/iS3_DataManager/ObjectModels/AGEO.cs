using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_AGEO")]
	public class AGEO:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///不良地质现象区ID </summary>
		public string AGEO_ID {get;set;}
/// <summary>
///
///不良地质现象类型 </summary>
		public string AGEO_TYPE {get;set;}
/// <summary>
///
///分布范围 </summary>
		public string AGEO_DSRG {get;set;}
/// <summary>
///
///面积 </summary>
		public Nullable<double> AGEO_AREA {get;set;}
/// <summary>
///
///工程地质性质 </summary>
		public string AGEO_EGP {get;set;}
/// <summary>
///
///危害程度 </summary>
		public string AGEO_TLOD {get;set;}
/// <summary>
///
///发展规律 </summary>
		public string AGEO_LAWD {get;set;}
/// <summary>
///
///备注 </summary>
		public string AGEO_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
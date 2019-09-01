using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GETD")]
	public class GETD:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///深度 </summary>
		public Nullable<double> GETD_DEPH {get;set;}
/// <summary>
///
///温度 </summary>
		public Nullable<int> GETD_TEMP {get;set;}
/// <summary>
///
///测量方法 </summary>
		public string GETD_METH {get;set;}
/// <summary>
///
///地层 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///备注 </summary>
		public string GETD_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_WEAT")]
	public class WEAT:DGObject
 	{ 
/// <summary>
///
///气象区ID </summary>
		public string WEAT_ID {get;set;}
/// <summary>
///
///形状ID </summary>
		public string SHAP_ID {get;set;}
/// <summary>
///
///分布范围 </summary>
		public string WEAT_DSRG {get;set;}
/// <summary>
///
///气候类型 </summary>
		public string WEAT_TYPE {get;set;}
/// <summary>
///
///年平均降水量 </summary>
		public Nullable<double> WEAT_MAP {get;set;}
/// <summary>
///
///年平均温度 </summary>
		public Nullable<double> WEAT_MAT {get;set;}
/// <summary>
///
///备注 </summary>
		public string WEAT_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
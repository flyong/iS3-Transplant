using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SHAP")]
	public class SHAP:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string SHAP_ID {get;set;}
/// <summary>
///
///形状类型 </summary>
		public string SHAP_TYPE {get;set;}
/// <summary>
///
///坐标点总计数 </summary>
		public Nullable<int> SHAP_NUMB {get;set;}
/// <summary>
///
///坐标点编号 </summary>
		public string SHAP_DNO {get;set;}
/// <summary>
///
///X坐标 </summary>
		public Nullable<double> SHAP_NATE {get;set;}
/// <summary>
///
///Y坐标 </summary>
		public Nullable<double> SHAP_NATN {get;set;}
/// <summary>
///
///Z坐标 </summary>
		public Nullable<double> SHAP_GL {get;set;}
/// <summary>
///
///坐标系代码 </summary>
		public string SHAP_GREF {get;set;}
/// <summary>
///
///备注 </summary>
		public string SHAP_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
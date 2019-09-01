using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_LOCA")]
	public class LOCA:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///位置点类型 </summary>
		public string LOCA_TYPE {get;set;}
/// <summary>
///
///X坐标（东） </summary>
		public Nullable<double> LOCA_NATE {get;set;}
/// <summary>
///
///Y坐标（北） </summary>
		public Nullable<double> LOCA_NATN {get;set;}
/// <summary>
///
///高程（地表） </summary>
		public Nullable<double> LOCA_GL {get;set;}
/// <summary>
///
///坐标系代码 </summary>
		public string LOCA_GREF {get;set;}
/// <summary>
///
///位置信息观测方法 </summary>
		public string LOCA_LOCM {get;set;}
/// <summary>
///
///所处勘察阶段 </summary>
		public string LOCA_CLST {get;set;}
/// <summary>
///
///桩号 </summary>
		public string LOCA_CNGE {get;set;}
/// <summary>
///
///备注 </summary>
		public string LOCA_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
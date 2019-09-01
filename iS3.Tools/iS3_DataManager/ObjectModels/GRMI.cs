using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GRMI")]
	public class GRMI:DGObject
 	{ 
/// <summary>
///
///地震动参数区ID </summary>
		public string GRMI_ID {get;set;}
/// <summary>
///
///地震动峰值加速度  </summary>
		public Nullable<double> GRMI_GMPA {get;set;}
/// <summary>
///
///地震动反应周期 </summary>
		public Nullable<int> GRMI_GMRP {get;set;}
/// <summary>
///
///抗震设防烈度 </summary>
		public string GRMI_SFI {get;set;}
/// <summary>
///
///设计地震分组 </summary>
		public string GRMI_DEG {get;set;}
/// <summary>
///
///基本地震加速度 </summary>
		public Nullable<double> GRMI_BSA {get;set;}
/// <summary>
///
///剪切波速 </summary>
		public string GRMI_SWV {get;set;}
/// <summary>
///
///备注 </summary>
		public string GRMI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
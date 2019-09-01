using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RPLT")]
	public class RPLT:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RPLT_LOCA {get;set;}
/// <summary>
///
///样本ID </summary>
		public string SPEC_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string RPLT_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RPLT_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RPLT_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RPLT_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RPLT_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RPLT_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string RPLT_DESC {get;set;}
/// <summary>
///
///实验类型 </summary>
		public string RPLT_PLTF {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string RPLT_SAMD {get;set;}
/// <summary>
///
///加载方式 </summary>
		public string RPLT_LOAM {get;set;}
/// <summary>
///
///试样形状 </summary>
		public string RPLT_SAMS {get;set;}
/// <summary>
///
///样本含水率 </summary>
		public Nullable<double> RPLT_MC {get;set;}
/// <summary>
///
///试件直径 </summary>
		public Nullable<double> RPLT_SIZE {get;set;}
/// <summary>
///
///试样高度 </summary>
		public Nullable<double> RPLT_HEIG {get;set;}
/// <summary>
///
///加载点间距 </summary>
		public Nullable<double> RPLT_LPS {get;set;}
/// <summary>
///
///等效岩芯直径 </summary>
		public Nullable<double> RPLT_ECD {get;set;}
/// <summary>
///
///各向异性指数 </summary>
		public string RPLT_ANII {get;set;}
/// <summary>
///
///破坏特征 </summary>
		public string RPLT_DESF {get;set;}
/// <summary>
///
///破坏荷载 </summary>
		public Nullable<double> RPLT_DESL {get;set;}
/// <summary>
///
///点荷载强度指数 </summary>
		public Nullable<double> RPLT_PLS {get;set;}
/// <summary>
///
///尺寸修正后的点荷载强度指数 </summary>
		public Nullable<double> RPLT_PLSI {get;set;}
/// <summary>
///
///备注 </summary>
		public string RPLT_REM {get;set;}
	}
}
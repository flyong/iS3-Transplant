using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TTTS")]
	public class TTTS:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string TTTS_LOCA {get;set;}
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
		public string TTTS_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string TTTS_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string TTTS_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string TTTS_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string TTTS_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string TTTS_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string TTTS_DESC {get;set;}
/// <summary>
///
///实验类型 </summary>
		public string TTTS_PLTF {get;set;}
/// <summary>
///
///标本直径 </summary>
		public Nullable<double> TTTS_SDIA {get;set;}
/// <summary>
///
///标本长度 </summary>
		public Nullable<double> TTTS_LEN {get;set;}
/// <summary>
///
///标本初始含水量 </summary>
		public Nullable<double> TTTS_IMC {get;set;}
/// <summary>
///
///标本最终含水量 </summary>
		public Nullable<double> TTTS_FMC {get;set;}
/// <summary>
///
///初始体积密度 </summary>
		public Nullable<double> TTTS_BDEN {get;set;}
/// <summary>
///
///初始干密度 </summary>
		public Nullable<double> TTTS_DDEN {get;set;}
/// <summary>
///
///围压 </summary>
		public Nullable<int> TTTS_CELL {get;set;}
/// <summary>
///
///破坏时主应力差 </summary>
		public Nullable<int> TTTS_DEVF {get;set;}
/// <summary>
///
///轴向应变 </summary>
		public Nullable<double> TTTS_STRN {get;set;}
/// <summary>
///
///无侧限抗剪强度 </summary>
		public Nullable<double> TTTS_CU {get;set;}
/// <summary>
///
///破坏模式 </summary>
		public string TTTS_MODE {get;set;}
/// <summary>
///
///备注 </summary>
		public string TTTS_REM {get;set;}
	}
}
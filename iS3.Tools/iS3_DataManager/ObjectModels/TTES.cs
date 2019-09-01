using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TTES")]
	public class TTES:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string TTES_LOCA {get;set;}
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
		public string TTES_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string TTES_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string TTES_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string TTES_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string TTES_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string TTES_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string TTES_DESC {get;set;}
/// <summary>
///
///实验类型 </summary>
		public string TTES_PLTF {get;set;}
/// <summary>
///
///粘聚力 </summary>
		public Nullable<int> TTES_COH {get;set;}
/// <summary>
///
///内摩擦角 </summary>
		public Nullable<double> TTES_AOF {get;set;}
/// <summary>
///
///标本直径 </summary>
		public Nullable<double> TTES_SDIA {get;set;}
/// <summary>
///
///标本长度 </summary>
		public Nullable<double> TTES_LEN {get;set;}
/// <summary>
///
///标本初始含水量 </summary>
		public Nullable<double> TTES_IMC {get;set;}
/// <summary>
///
///标本最终含水量 </summary>
		public Nullable<double> TTES_FMC {get;set;}
/// <summary>
///
///初始体积密度 </summary>
		public Nullable<double> TTES_BDEN {get;set;}
/// <summary>
///
///初始干密度 </summary>
		public Nullable<double> TTES_DDEN {get;set;}
/// <summary>
///
///饱和度的测试方法 </summary>
		public string TTES_SAT {get;set;}
/// <summary>
///
///固结细节描述 </summary>
		public string TTES_CONS {get;set;}
/// <summary>
///
///固结/剪切阶段开始时的有效应力 </summary>
		public Nullable<int> TTES_CONP {get;set;}
/// <summary>
///
///剪切阶段的围压 </summary>
		public Nullable<int> TTES_CELL {get;set;}
/// <summary>
///
///剪切阶段开始时的孔隙水压 </summary>
		public Nullable<int> TTES_PWPI {get;set;}
/// <summary>
///
///剪切过程中的轴向应变率 </summary>
		public Nullable<double> TTES_STRR {get;set;}
/// <summary>
///
///破坏时轴向应变 </summary>
		public Nullable<double> TTES_STRN {get;set;}
/// <summary>
///
///破坏时主应力差 </summary>
		public Nullable<int> TTES_DEVF {get;set;}
/// <summary>
///
///破坏时孔隙水压 </summary>
		public Nullable<int> TTES_PWPF {get;set;}
/// <summary>
///
///破坏时的体积应变（仅排空） </summary>
		public Nullable<double> TTES_STV {get;set;}
/// <summary>
///
///破坏模式 </summary>
		public string TTES_MODE {get;set;}
/// <summary>
///
///备注 </summary>
		public string TTES_REM {get;set;}
	}
}
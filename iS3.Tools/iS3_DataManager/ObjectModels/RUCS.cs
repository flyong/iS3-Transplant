using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RUCS")]
	public class RUCS:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RUCS_LOCA {get;set;}
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
		public string RUCS_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RUCS_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RUCS_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RUCS_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RUCS_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RUCS_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string RUCS_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string RUCS_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string RUCS_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> RUCS_SAMN {get;set;}
/// <summary>
///
///含水率 </summary>
		public Nullable<double> RUCS_MC {get;set;}
/// <summary>
///
///试件直径 </summary>
		public Nullable<double> RUCS_SDIA {get;set;}
/// <summary>
///
///试样高度 </summary>
		public Nullable<double> RUCS_LEN {get;set;}
/// <summary>
///
///试样横截面面积 </summary>
		public Nullable<double> RUCS_SCSA {get;set;}
/// <summary>
///
///加载方向 </summary>
		public string RUCS_LOAD {get;set;}
/// <summary>
///
///最大破坏荷载 </summary>
		public Nullable<double> RUCS_MADL {get;set;}
/// <summary>
///
///破坏类型 </summary>
		public string RUCS_MODE {get;set;}
/// <summary>
///
///轴向荷载 </summary>
		public Nullable<double> RUCS_AXIL {get;set;}
/// <summary>
///
///正应力 </summary>
		public Nullable<double> RUCS_DIRS {get;set;}
/// <summary>
///
///纵向应变 </summary>
		public Nullable<double> RUCS_VERS {get;set;}
/// <summary>
///
///横向应变 </summary>
		public Nullable<double> RUCS_LATS {get;set;}
/// <summary>
///
///单轴抗压强度（饱和状态） </summary>
		public string RUCS_SUCS {get;set;}
/// <summary>
///
///单轴抗压强度（烘干状态） </summary>
		public string RUCS_DUCS {get;set;}
/// <summary>
///
///软化系数 </summary>
		public Nullable<double> RUCS_SOFC {get;set;}
/// <summary>
///
///杨氏模量 </summary>
		public string RUCS_YMOD {get;set;}
/// <summary>
///
///泊松比 </summary>
		public Nullable<double> RUCS_POIS {get;set;}
/// <summary>
///
///测量模量的应力水平 </summary>
		public string RUCS_ESTR {get;set;}
/// <summary>
///
///杨氏模量的测定方法 </summary>
		public string RUCS_ETYP {get;set;}
/// <summary>
///
///备注 </summary>
		public string RUCS_REM {get;set;}
	}
}
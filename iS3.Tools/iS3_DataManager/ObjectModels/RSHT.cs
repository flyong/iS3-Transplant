using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RSHT")]
	public class RSHT:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RSHT_LOCA {get;set;}
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
		public string RSHT_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RSHT_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RSHT_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RSHT_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RSHT_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RSHT_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试样含水率 </summary>
		public Nullable<double> RSHT_MC {get;set;}
/// <summary>
///
///试样直径 </summary>
		public Nullable<double> RSHT_SDIA {get;set;}
/// <summary>
///
///试样高度 </summary>
		public Nullable<double> RSHT_HEIG {get;set;}
/// <summary>
///
///剪切面积 </summary>
		public Nullable<double> RSHT_LEN {get;set;}
/// <summary>
///
///法向荷载 </summary>
		public Nullable<double> RSHT_AXIL {get;set;}
/// <summary>
///
///正应力 </summary>
		public Nullable<double> RSHT_AXIS {get;set;}
/// <summary>
///
///剪应力 </summary>
		public Nullable<double> RSHT_SHES {get;set;}
/// <summary>
///
///剪切位移（各级荷载下的位移） </summary>
		public Nullable<double> RSHT_SHED {get;set;}
/// <summary>
///
///法向位移（各级荷载下的位移） </summary>
		public Nullable<double> RSHT_AXID {get;set;}
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
///备注 </summary>
		public string RSHT_REM {get;set;}
	}
}
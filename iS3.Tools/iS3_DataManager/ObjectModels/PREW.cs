using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PREW")]
	public class PREW:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///水文钻孔（井）ID </summary>
		public string HYDW_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string PREW_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string PREW_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string PREW_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string PREW_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string PREW_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string PREW_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string PREW_DESC {get;set;}
/// <summary>
///
///起始深度 </summary>
		public Nullable<double> PREW_STAD {get;set;}
/// <summary>
///
///终止深度 </summary>
		public Nullable<double> PREW_ENDD {get;set;}
/// <summary>
///
///试段长度 </summary>
		public Nullable<double> PREW_LENG {get;set;}
/// <summary>
///
///起始高程 </summary>
		public Nullable<double> PREW_STAE {get;set;}
/// <summary>
///
///终止高程 </summary>
		public Nullable<double> PREW_TERE {get;set;}
/// <summary>
///
///洗孔情况描述 </summary>
		public string PREW_WACD {get;set;}
/// <summary>
///
///试段描述 </summary>
		public string PREW_TEPD {get;set;}
/// <summary>
///
///栓塞类型 </summary>
		public string PREW_EMBT {get;set;}
/// <summary>
///
///止水效果 </summary>
		public string PREW_WASE {get;set;}
/// <summary>
///
///时间间隔 </summary>
		public string PREW_TIMI {get;set;}
/// <summary>
///
///压力 </summary>
		public Nullable<double> PREW_PRES {get;set;}
/// <summary>
///
///流量 </summary>
		public Nullable<double> PREW_FLOW {get;set;}
/// <summary>
///
///水位埋深 </summary>
		public Nullable<double> PREW_WATD {get;set;}
/// <summary>
///
///测点距水位 </summary>
		public Nullable<double> PREW_MPWL {get;set;}
/// <summary>
///
///PQ曲线类型 </summary>
		public string PREW_PQCT {get;set;}
/// <summary>
///
///透水率 </summary>
		public Nullable<double> PREW_WATP {get;set;}
/// <summary>
///
///备注 </summary>
		public string PREW_REM {get;set;}
	}
}
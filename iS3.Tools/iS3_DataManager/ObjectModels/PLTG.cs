using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PLTG")]
	public class PLTG:DGObject
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
///试样来源 </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string _DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string PLTG_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string PLTG_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string PLTG_TESN {get;set;}
/// <summary>
///
///试验底埋深 </summary>
		public Nullable<double> PLTG_DPTH {get;set;}
/// <summary>
///
///承压板直径或边长 </summary>
		public Nullable<int> PLTG_PDIA {get;set;}
/// <summary>
///
///总载荷 </summary>
		public Nullable<double> PLTG_SEAT {get;set;}
/// <summary>
///
///加载方式 </summary>
		public string PLTG_LST {get;set;}
/// <summary>
///
///加载循环次数 </summary>
		public Nullable<int> PLTG_CYC {get;set;}
/// <summary>
///
///第二次加载弹性模量 </summary>
		public Nullable<double> PLTG_EV2 {get;set;}
/// <summary>
///
///备注 </summary>
		public string PLTG_REM {get;set;}
/// <summary>
///
///试验时天气环境概况 </summary>
		public string PLTG_ENV {get;set;}
/// <summary>
///
///测试方法 </summary>
		public string PLTG_METH {get;set;}
/// <summary>
///
///试验状态 </summary>
		public string PLTG_STAT {get;set;}
/// <summary>
///
///地层记录代码或编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///变形模量 </summary>
		public Nullable<double> PLTG_SMOD {get;set;}
/// <summary>
///
///弹性模量 </summary>
		public Nullable<double> PLTG_EMOD {get;set;}
/// <summary>
///
///地基反力系数 </summary>
		public Nullable<double> PLTG_GRRC {get;set;}
	}
}
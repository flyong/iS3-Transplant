using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_MOIS")]
	public class MOIS:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string MOIS_LOCA {get;set;}
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
		public string MOIS_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string MOIS_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string MOIS_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string MOIS_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string MOIS_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string MOIS_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string MOIS_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string MOIS_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string MOIS_SAMD {get;set;}
/// <summary>
///
///烘干温度 </summary>
		public Nullable<double> MOIS_DRYT {get;set;}
/// <summary>
///
///试样数量 </summary>
		public Nullable<int> MOIS_SAMN {get;set;}
/// <summary>
///
///烘干时间 </summary>
		public string MOIS_DRTM {get;set;}
/// <summary>
///
///称量盒干燥质量 </summary>
		public Nullable<double> MOIS_WBDQ {get;set;}
/// <summary>
///
///烘干前试样和称量盒总质量 </summary>
		public Nullable<double> MOIS_TMSW1 {get;set;}
/// <summary>
///
///烘干后试样和称量盒总质量 </summary>
		public Nullable<double> MOIS_TMSW2 {get;set;}
/// <summary>
///
///天然含水率 </summary>
		public Nullable<int> MOIS_MC {get;set;}
/// <summary>
///
///备注 </summary>
		public string MOIS_REM {get;set;}
	}
}
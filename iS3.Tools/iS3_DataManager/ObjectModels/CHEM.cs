using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_CHEM")]
	public class CHEM:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string CHEM_LOCA {get;set;}
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
		public string CHEM_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string CHEM_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string CHEM_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string CHEM_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string CHEM_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string CHEM_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string CHEM_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string CHEM_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> CHEM_SAMN {get;set;}
/// <summary>
///
///pH值 </summary>
		public Nullable<double> HYCH_PH {get;set;}
/// <summary>
///
///硬度 </summary>
		public Nullable<double> HYCH_HARD {get;set;}
/// <summary>
///
///钾离子含量 </summary>
		public Nullable<double> HYCH_K {get;set;}
/// <summary>
///
///钠离子含量 </summary>
		public Nullable<double> HYCH_NA {get;set;}
/// <summary>
///
///钙离子含量 </summary>
		public Nullable<double> HYCH_GA {get;set;}
/// <summary>
///
///镁离子含量 </summary>
		public Nullable<double> HYCH_MG {get;set;}
/// <summary>
///
///碳酸氢根含量 </summary>
		public Nullable<double> HYCH_HCO3 {get;set;}
/// <summary>
///
///硫酸根含量 </summary>
		public Nullable<double> HYCH_SO4 {get;set;}
/// <summary>
///
///氯离子含量 </summary>
		public Nullable<double> HYCH_CL {get;set;}
/// <summary>
///
///化学试验类型 </summary>
		public string HYCH_CHTY {get;set;}
/// <summary>
///
///备注 </summary>
		public string CHEM_REM {get;set;}
	}
}
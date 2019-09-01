using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_AWAD")]
	public class AWAD:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string AWAD_LOCA {get;set;}
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
		public string AWAD_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string AWAD_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string AWAD_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string AWAD_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string AWAD_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string AWAD_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string AWAD_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string AWAD_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string AWAD_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> AWAD_SAMN {get;set;}
/// <summary>
///
///天然质量 </summary>
		public Nullable<double> AWAD_NATQ {get;set;}
/// <summary>
///
///烘干后质量 </summary>
		public Nullable<double> AWAD_DMAS {get;set;}
/// <summary>
///
///饱和质量 </summary>
		public Nullable<double> AWAD_SMAS {get;set;}
/// <summary>
///
///吸水率 </summary>
		public Nullable<int> AWAD_WAB {get;set;}
/// <summary>
///
///饱和吸水率 </summary>
		public string AWAD_SWAB {get;set;}
/// <summary>
///
///备注 </summary>
		public string AWAD_REM {get;set;}
	}
}
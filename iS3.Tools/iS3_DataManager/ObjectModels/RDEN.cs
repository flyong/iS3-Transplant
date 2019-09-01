using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RDEN")]
	public class RDEN:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RDEN_LOCA {get;set;}
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
		public string RDEN_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RDEN_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RDEN_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RDEN_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RDEN_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RDEN_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string RDEN_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string RDEN_DESC {get;set;}
/// <summary>
///
///试样体积 </summary>
		public Nullable<double> RDEN_SAMV {get;set;}
/// <summary>
///
///烘干后的试件重量 </summary>
		public Nullable<double> RDEN_DTPW {get;set;}
/// <summary>
///
///腊封试样空气中质量 </summary>
		public Nullable<double> RDEN_WSAQ {get;set;}
/// <summary>
///
///蜡封试样水中质量 </summary>
		public Nullable<double> RDEN_WSWQ {get;set;}
/// <summary>
///
///天然含水率 </summary>
		public Nullable<int> RDEN_MC {get;set;}
/// <summary>
///
///饱和含水率 </summary>
		public Nullable<int> RDEN_SMC {get;set;}
/// <summary>
///
///岩石烘干密度 </summary>
		public Nullable<int> RDEN_DDEN {get;set;}
/// <summary>
///
///岩石天然密度 </summary>
		public Nullable<int> RDEN_NDEN {get;set;}
/// <summary>
///
///孔隙率 </summary>
		public Nullable<double> RDEN_PORO {get;set;}
/// <summary>
///
///颗粒密度 </summary>
		public Nullable<int> RDEN_PDEN {get;set;}
/// <summary>
///
///块体密度 </summary>
		public Nullable<int> RDEN_BDEN {get;set;}
/// <summary>
///
///备注 </summary>
		public string RDEN_REM {get;set;}
	}
}
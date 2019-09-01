using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DSTG")]
	public class DSTG:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string DSTG_LOCA {get;set;}
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
		public string DSTG_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string DSTG_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string DSTG_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string DSTG_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string DSTG_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string DSTG_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string DSTG_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string DSTG_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string DSTG_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> DSTG_SAMN {get;set;}
/// <summary>
///
///测定前质量 </summary>
		public Nullable<double> DSTG_PMAS {get;set;}
/// <summary>
///
///第一次循环后质量 </summary>
		public Nullable<double> DSTG_MAS1 {get;set;}
/// <summary>
///
///第二次循环后质量 </summary>
		public Nullable<double> DSTG_MAS2 {get;set;}
/// <summary>
///
///圆筒质量 </summary>
		public Nullable<double> DSTG_CMAS {get;set;}
/// <summary>
///
///残留试件状态描述 </summary>
		public string DSTG_RSSD {get;set;}
/// <summary>
///
///筛出部分状态描述 </summary>
		public string DSTG_SPSD {get;set;}
/// <summary>
///
///耐崩解指数 </summary>
		public Nullable<double> DSTG_DISI {get;set;}
/// <summary>
///
///备注 </summary>
		public string DSTG_REM {get;set;}
	}
}
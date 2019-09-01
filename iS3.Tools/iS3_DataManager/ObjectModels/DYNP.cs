using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DYNP")]
	public class DYNP:DGObject
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
		public string DYNP_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string DYNP_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string _CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string DYNP_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string DYNP_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> DYNP_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string DYNP_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验类型 </summary>
		public string DYNP_TYPE {get;set;}
/// <summary>
///
///试验标高 </summary>
		public Nullable<double> DYNP_TESE {get;set;}
/// <summary>
///
///锤击重量 </summary>
		public Nullable<int> DYNP_HAMW {get;set;}
/// <summary>
///
///落距 </summary>
		public Nullable<double> DYNP_FALD {get;set;}
/// <summary>
///
///探杆直径 </summary>
		public Nullable<double> DYNP_PROD {get;set;}
/// <summary>
///
///锥角 </summary>
		public Nullable<int> DYNP_CONA {get;set;}
/// <summary>
///
///锤击数 </summary>
		public Nullable<int> DYNP_HAMN {get;set;}
/// <summary>
///
///试验评价 </summary>
		public string DYNP_TSTE {get;set;}
/// <summary>
///
///分层平均贯入击数 </summary>
		public Nullable<int> DYNP_SAPN {get;set;}
	}
}
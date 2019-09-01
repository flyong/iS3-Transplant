using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_INJC")]
	public class INJC:DGObject
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
		public string INJC_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string INJC_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string INJC_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string INJC_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string INJC_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string INJC_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string INJC_DESC {get;set;}
/// <summary>
///
///地下水位 </summary>
		public Nullable<double> INJC_WATD {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> INJC_DEPT {get;set;}
/// <summary>
///
///试验长度 </summary>
		public Nullable<double> INJC_LENG {get;set;}
/// <summary>
///
///试验段直径 </summary>
		public Nullable<double> INJC_DIAM {get;set;}
/// <summary>
///
///试段类型 </summary>
		public string INJC_TYPE {get;set;}
/// <summary>
///
///试验水头 </summary>
		public Nullable<double> INJC_HEAD {get;set;}
/// <summary>
///
///注入水量 </summary>
		public Nullable<double> INJC_INJW {get;set;}
/// <summary>
///
///单位时间注入量 </summary>
		public Nullable<double> INJC_UTIN {get;set;}
/// <summary>
///
///持续时间 </summary>
		public string INJC_DURA {get;set;}
/// <summary>
///
///透水率 </summary>
		public Nullable<double> INJC_WATP {get;set;}
/// <summary>
///
///备注 </summary>
		public string INJC_REM {get;set;}
	}
}
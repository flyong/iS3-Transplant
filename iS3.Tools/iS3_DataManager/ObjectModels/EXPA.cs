using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_EXPA")]
	public class EXPA:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string EXPA_LOCA {get;set;}
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
		public string EXPA_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string EXPA_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string EXPA_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string EXPA_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string EXPA_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string EXPA_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string EXPA_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string EXPA_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string EXPA_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> EXPA_SAMN {get;set;}
/// <summary>
///
///试件直径或边长 </summary>
		public Nullable<double> EXPA_SIZE {get;set;}
/// <summary>
///
///试件高度 </summary>
		public Nullable<double> EXPA_HEIG {get;set;}
/// <summary>
///
///轴向荷载 </summary>
		public Nullable<double> EXPA_LOAD {get;set;}
/// <summary>
///
///轴向变形 </summary>
		public Nullable<double> EXPA_ADEF {get;set;}
/// <summary>
///
///径向变形 </summary>
		public Nullable<double> EXPA_RDEF {get;set;}
/// <summary>
///
///有侧向约束的轴向变形 </summary>
		public Nullable<double> EXPA_ADLC {get;set;}
/// <summary>
///
///轴向自由膨胀率 </summary>
		public Nullable<double> EXPA_AFER {get;set;}
/// <summary>
///
///径向自由膨胀率 </summary>
		public Nullable<double> EXPA_RFER {get;set;}
/// <summary>
///
///侧向约束膨胀率 </summary>
		public Nullable<double> EXPA_LCER {get;set;}
/// <summary>
///
///备注 </summary>
		public string EXPA_REM {get;set;}
	}
}
using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RMDT")]
	public class RMDT:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RMDT_LOCA {get;set;}
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
		public string RMDT_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RMDT_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RMDT_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RMDT_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RMDT_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RMDT_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string RMDT_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string RMDT_DESC {get;set;}
/// <summary>
///
///薄片编号 </summary>
		public string RMDT_SHEN {get;set;}
/// <summary>
///
///采集位置 </summary>
		public string RMDT_COLL {get;set;}
/// <summary>
///
///野外定名 </summary>
		public string RMDT_NAME1 {get;set;}
/// <summary>
///
///室内鉴定名称 </summary>
		public string RMDT_NAME2 {get;set;}
/// <summary>
///
///备注 </summary>
		public string RMDT_REM {get;set;}
	}
}
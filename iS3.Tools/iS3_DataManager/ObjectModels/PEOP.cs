using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PEOP")]
	public class PEOP:DGObject
 	{ 
/// <summary>
///
///人员ID </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///检测/编制人姓名 </summary>
		public string PEOP_TPNA {get;set;}
/// <summary>
///
///检测/编制人身份证 </summary>
		public string PEOP_TPIC {get;set;}
/// <summary>
///
///检测/编制人电话 </summary>
		public string PEOP_TPPN {get;set;}
/// <summary>
///
///复核人姓名 </summary>
		public string PEOP_RENA {get;set;}
/// <summary>
///
///复核人身份证 </summary>
		public string PEOP_REIC {get;set;}
/// <summary>
///
///复核人电话 </summary>
		public string PEOP_REPN {get;set;}
/// <summary>
///
///现场监理人员 </summary>
		public string PEOP_SISU {get;set;}
/// <summary>
///
///监理人员身份证 </summary>
		public string PEOP_SSIC {get;set;}
/// <summary>
///
///监理人员电话 </summary>
		public string PEOP_SSPN {get;set;}
/// <summary>
///
///备注 </summary>
		public string PEOP_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
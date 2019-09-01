using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_CSIS")]
	public class CSIS:DGObject
 	{ 
/// <summary>
///
///施工分段ID </summary>
		public string CSIS_ID {get;set;}
/// <summary>
///
///项目标段号 </summary>
		public string CSIS_FDNB {get;set;}
/// <summary>
///
///左右幅 </summary>
		public string CSIS_LRFF {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string CSIS_MILE {get;set;}
/// <summary>
///
///记录时间 </summary>
		public string CSIS_RETM {get;set;}
/// <summary>
///
///施工面桩号 </summary>
		public string CSIS_SGCH {get;set;}
/// <summary>
///
///初衬桩号 </summary>
		public string CSIS_CWZH {get;set;}
/// <summary>
///
///二衬桩号 </summary>
		public string CSIS_ECZH {get;set;}
	}
}
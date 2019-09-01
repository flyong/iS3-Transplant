using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_EPY")]
	public class EPY:DGObject
 	{ 
/// <summary>
///
///掌子面桩号 </summary>
		public string EP_CHAI {get;set;}
/// <summary>
///
///预留核心土宽度 </summary>
		public Nullable<double> EP_RCSW {get;set;}
/// <summary>
///
///台阶步长 </summary>
		public Nullable<double> EP_XSS {get;set;}
/// <summary>
///
///开挖高度 </summary>
		public string EP_EH {get;set;}
/// <summary>
///
///开挖宽度 </summary>
		public string EP_EW {get;set;}
/// <summary>
///
///循环进尺 </summary>
		public string EP_CYCF {get;set;}
	}
}
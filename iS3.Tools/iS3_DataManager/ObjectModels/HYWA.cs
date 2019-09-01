using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_HYWA")]
	public class HYWA:DGObject
 	{ 
/// <summary>
///
///水文孔（井）ID </summary>
		public string HYDW_ID {get;set;}
/// <summary>
///
///含水层代码 </summary>
		public string HYWA_CODE {get;set;}
/// <summary>
///
///地层 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///层顶深度 </summary>
		public Nullable<double> HYWA_TOP {get;set;}
/// <summary>
///
///层底深度 </summary>
		public Nullable<double> HYWA_BASE {get;set;}
/// <summary>
///
///水位埋深 </summary>
		public Nullable<double> HYWA_DEPT {get;set;}
	}
}
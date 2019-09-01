using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_HDPF")]
	public class HDPF:DGObject
 	{ 
/// <summary>
///
///钻孔ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///地层ID </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///层底深度 </summary>
		public Nullable<double> HDPF_TOP {get;set;}
/// <summary>
///
///层顶深度 </summary>
		public Nullable<double> HDPF_BASE {get;set;}
	}
}
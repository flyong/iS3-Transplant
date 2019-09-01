using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GRIS")]
	public class GRIS:DGObject
 	{ 
/// <summary>
///
///地质预报分段ID </summary>
		public string GRIS_ID {get;set;}
/// <summary>
///
///项目标段号 </summary>
		public string GRIS_PJIS {get;set;}
/// <summary>
///
///左右幅 </summary>
		public string GRIS_LRFD {get;set;}
/// <summary>
///
///预报方法 </summary>
		public string GRIS_RPMD {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string GRIS_MILE {get;set;}
/// <summary>
///
///起始桩号 </summary>
		public string GRIS_STPN {get;set;}
/// <summary>
///
///终止桩号 </summary>
		public string GRID_EDPN {get;set;}
	}
}
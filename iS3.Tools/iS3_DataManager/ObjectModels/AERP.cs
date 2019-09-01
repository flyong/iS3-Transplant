using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_AERP")]
	public class AERP:DGObject
 	{ 
/// <summary>
///
///航片ID </summary>
		public string AERP_ID {get;set;}
/// <summary>
///
///航片类型 </summary>
		public string AERP_TYPE {get;set;}
/// <summary>
///
///飞行高度 </summary>
		public Nullable<double> AERP_HEIG {get;set;}
/// <summary>
///
///府视角度 </summary>
		public Nullable<int> AERP_DIP {get;set;}
/// <summary>
///
///成像时间 </summary>
		public string AERP_DTIM {get;set;}
/// <summary>
///
///执行人 </summary>
		public string AERP_STAFF {get;set;}
/// <summary>
///
///勘察单位 </summary>
		public string AERP_CONT {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
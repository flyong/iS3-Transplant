using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RSVR")]
	public class RSVR:DGObject
 	{ 
/// <summary>
///
///水库ID </summary>
		public string RSVR_ID {get;set;}
/// <summary>
///
///河流名称 </summary>
		public string RSVR_NAME {get;set;}
/// <summary>
///
///位置 </summary>
		public string RSVR_LOCA {get;set;}
/// <summary>
///
///与线路最近距离 </summary>
		public Nullable<double> RSVR_DCA {get;set;}
/// <summary>
///
///汇流面积 </summary>
		public Nullable<double> RSVR_CFAR {get;set;}
/// <summary>
///
///旱季流量 </summary>
		public Nullable<double> RSVR_DRYF {get;set;}
/// <summary>
///
///雨季流量 </summary>
		public Nullable<double> RSVR_RAIF {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
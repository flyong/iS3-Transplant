using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RIVR")]
	public class RIVR:DGObject
 	{ 
/// <summary>
///
///水系ID </summary>
		public string RIVR_ID {get;set;}
/// <summary>
///
///河流名称 </summary>
		public string RIVR_NAME {get;set;}
/// <summary>
///
///位置 </summary>
		public string RIVR_LOCA {get;set;}
/// <summary>
///
///与线路最近距离 </summary>
		public Nullable<double> RIVR_DCA {get;set;}
/// <summary>
///
///所属水系 </summary>
		public string RIVR_SYS {get;set;}
/// <summary>
///
///汇流面积 </summary>
		public Nullable<double> RIVR_CFAR {get;set;}
/// <summary>
///
///旱季流量 </summary>
		public Nullable<double> RIVR_DRYF {get;set;}
/// <summary>
///
///雨季流量 </summary>
		public Nullable<double> RIVR_RAIF {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
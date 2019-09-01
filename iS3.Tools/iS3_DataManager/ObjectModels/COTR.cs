using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_COTR")]
	public class COTR:DGObject
 	{ 
/// <summary>
///
///工程ID </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///地貌区ID </summary>
		public string GMPG_ID {get;set;}
/// <summary>
///
///高程采样点数 </summary>
		public Nullable<int> COTR_NSP {get;set;}
/// <summary>
///
///海拔 </summary>
		public Nullable<double> COTR_ELEV {get;set;}
/// <summary>
///
///X向起点坐标 </summary>
		public Nullable<double> COTR_XATR {get;set;}
/// <summary>
///
///X向终点坐标 </summary>
		public Nullable<double> COTR_XEND {get;set;}
/// <summary>
///
///Y向起点坐标 </summary>
		public Nullable<double> COTR_YSTR {get;set;}
/// <summary>
///
///Y向终点坐标 </summary>
		public Nullable<double> COTR_YEND {get;set;}
/// <summary>
///
///插值方法 </summary>
		public string COTR_IM {get;set;}
/// <summary>
///
///X向插值间距 </summary>
		public Nullable<double> COTR_XDIS {get;set;}
/// <summary>
///
///Y向插值间距 </summary>
		public Nullable<double> COTR_YDIS {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
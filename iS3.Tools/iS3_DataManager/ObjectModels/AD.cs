using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_AD")]
	public class AD:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///钻孔ID </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///掌子面桩号 </summary>
		public string GCS_CHAI {get;set;}
/// <summary>
///
///钻探长度 </summary>
		public Nullable<double> DETL_TOP {get;set;}
/// <summary>
///
///地层年代 </summary>
		public string DETL_GEO1 {get;set;}
/// <summary>
///
///地层岩性 </summary>
		public string DETL_GEO2 {get;set;}
/// <summary>
///
///RQD值 </summary>
		public Nullable<double> DETL_RQD {get;set;}
/// <summary>
///
///承载力 </summary>
		public Nullable<double> DETL_BEAR {get;set;}
/// <summary>
///
///摩阻力 </summary>
		public Nullable<double> DETL_FRIC {get;set;}
/// <summary>
///
///标贯N </summary>
		public Nullable<double> DETL_BLOW {get;set;}
/// <summary>
///
///动探Nd </summary>
		public Nullable<double> DETL_DBLOW {get;set;}
/// <summary>
///
///细节描述 </summary>
		public string DETL_DESC {get;set;}
/// <summary>
///
///备注 </summary>
		public string DETL_REM {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}
using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_HYDW")]
	public class HYDW:DGObject
 	{ 
/// <summary>
///
///位置ID </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///水文孔（井）ID </summary>
		public string HYDW_ID {get;set;}
/// <summary>
///
///水文孔（井）类型 </summary>
		public string HYDW_TYPE {get;set;}
/// <summary>
///
///水文孔（井）孔径 </summary>
		public Nullable<double> HYDW_DIAM {get;set;}
/// <summary>
///
///孔（井）口标高 </summary>
		public Nullable<double> HYDW_TOP {get;set;}
/// <summary>
///
///孔（井）深 </summary>
		public Nullable<double> HYDW_DEPT {get;set;}
/// <summary>
///
///施工开始日 </summary>
		public string HYDW_STRT {get;set;}
/// <summary>
///
///施工结束日 </summary>
		public string HYDW_ENDT {get;set;}
/// <summary>
///
///腐蚀性描述 </summary>
		public string HYDW_CESC {get;set;}
/// <summary>
///
///位置描述 </summary>
		public string HYDW_LESC {get;set;}
	}
}
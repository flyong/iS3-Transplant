using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_MECP")]
	public class MECP:DGObject
 	{ 
/// <summary>
///
///粘聚力 </summary>
		public Nullable<double> MECP_COF {get;set;}
/// <summary>
///
///内摩擦角 </summary>
		public Nullable<double> MECP_AGF {get;set;}
/// <summary>
///
///单轴抗压强度 </summary>
		public Nullable<double> MECP_UCS {get;set;}
/// <summary>
///
///饱和状态下的单轴抗压强度 </summary>
		public Nullable<double> MECP_SUCS {get;set;}
/// <summary>
///
///烘干状态下的单轴抗压强度 </summary>
		public Nullable<double> MECP_DUCS {get;set;}
/// <summary>
///
///软化系数 </summary>
		public Nullable<double> MECP_SOFC {get;set;}
/// <summary>
///
///弹性模量 </summary>
		public Nullable<double> MECP_ELAM {get;set;}
/// <summary>
///
///泊松比 </summary>
		public Nullable<double> MECP_POIS {get;set;}
/// <summary>
///
///劈裂强度 </summary>
		public Nullable<double> MECP_SPLS {get;set;}
/// <summary>
///
///摩擦系数 </summary>
		public Nullable<double> MECP_COEF {get;set;}
/// <summary>
///
///凝聚力 </summary>
		public Nullable<double> MECP_COHE {get;set;}
/// <summary>
///
///点荷载强度指数 </summary>
		public Nullable<double> MECP_PLSI {get;set;}
/// <summary>
///
///点荷载强度 </summary>
		public Nullable<double> MECP_PLS {get;set;}
/// <summary>
///
///抗折强度 </summary>
		public Nullable<double> MECP_FLES {get;set;}
/// <summary>
///
///冻融系数 </summary>
		public Nullable<double> MECP_FTCO {get;set;}
/// <summary>
///
///坚固性试验质量损失率 </summary>
		public Nullable<double> MECP_RMLR {get;set;}
	}
}
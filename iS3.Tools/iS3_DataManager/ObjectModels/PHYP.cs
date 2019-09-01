using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PHYP")]
	public class PHYP:DGObject
 	{ 
/// <summary>
///
///岩矿含量 </summary>
		public string PHYP_ROCC {get;set;}
/// <summary>
///
///密度（颗粒密度） </summary>
		public Nullable<double> PHYP_PARD {get;set;}
/// <summary>
///
///天然密度 </summary>
		public Nullable<double> PHYP_NDEN {get;set;}
/// <summary>
///
///饱和密度 </summary>
		public Nullable<double> PHYP_SDEN {get;set;}
/// <summary>
///
///干密度 </summary>
		public Nullable<double> PHYP_DDEN {get;set;}
/// <summary>
///
///含水率 </summary>
		public Nullable<double> PHYP_MOIS {get;set;}
/// <summary>
///
///吸水率 </summary>
		public Nullable<double> PHYP_WAAR {get;set;}
/// <summary>
///
///饱和吸水率 </summary>
		public Nullable<double> PHYP_SWAR {get;set;}
/// <summary>
///
///饱水系数 </summary>
		public Nullable<double> PHYP_WSCR {get;set;}
/// <summary>
///
///轴向自由膨胀率 </summary>
		public Nullable<double> PHYP_AFER {get;set;}
/// <summary>
///
///径向自由膨胀率 </summary>
		public Nullable<double> PHYP_RFER {get;set;}
/// <summary>
///
///侧向约束膨胀率 </summary>
		public Nullable<double> PHYP_LCER {get;set;}
/// <summary>
///
///膨胀压力 </summary>
		public Nullable<double> PHYP_EXPP {get;set;}
/// <summary>
///
///耐崩解指数 </summary>
		public Nullable<double> PHYP_POEC {get;set;}
	}
}
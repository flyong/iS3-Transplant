using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SRIS")]
	public class SRIS:DGObject
 	{ 
/// <summary>
///
///围岩级别分段ID </summary>
		public string SRIS_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string SRIS_MILE {get;set;}
/// <summary>
///
///起始桩号 </summary>
		public string SRIS_QSZH {get;set;}
/// <summary>
///
///终止桩号 </summary>
		public string SRIS_ZZZH {get;set;}
/// <summary>
///
///长度 </summary>
		public Nullable<double> SRIS_LGTH {get;set;}
/// <summary>
///
///围岩级别 </summary>
		public string SRIS_SRLV {get;set;}
/// <summary>
///
///岩体完整性系数KV </summary>
		public string SRIS_RCLV {get;set;}
/// <summary>
///
///岩石单轴饱和抗压强度RC </summary>
		public string SRIS_SAEC {get;set;}
/// <summary>
///
///地下水影响修正系数K1 </summary>
		public string SRIS_UWCF {get;set;}
/// <summary>
///
///主要软弱结构面产状影响修正系数K2 </summary>
		public string SRIS_WFCF {get;set;}
/// <summary>
///
///初始应力状态影响修正系数K3 </summary>
		public string SRIS_ISCF {get;set;}
/// <summary>
///
///BQ1 </summary>
		public string SRIS_BQ1 {get;set;}
/// <summary>
///
///BQ2 </summary>
		public string SRIS_BQ2 {get;set;}
	}
}
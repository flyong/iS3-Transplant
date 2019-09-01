using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TFSI")]
	public class TFSI:DGObject
 	{ 
/// <summary>
///
///掌子面ID </summary>
		public string TFSI_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string TFSI_MILE {get;set;}
/// <summary>
///
///掌子面里程值 </summary>
		public Nullable<double> TFSI_TUFM {get;set;}
/// <summary>
///
///时间 </summary>
		public string TFSI_TIME {get;set;}
/// <summary>
///
///开挖宽度 </summary>
		public Nullable<double> TFSI_EXAW {get;set;}
/// <summary>
///
///开挖高度 </summary>
		public Nullable<double> TFSI_EXAH {get;set;}
/// <summary>
///
///开挖面积 </summary>
		public Nullable<double> TFSI_EXAA {get;set;}
/// <summary>
///
///开挖方式 </summary>
		public string TFSI_METH {get;set;}
/// <summary>
///
///岩土特征类别 </summary>
		public string TFSI_TYPE {get;set;}
/// <summary>
///
///素描成果数据 </summary>
		public string TFSR_ID {get;set;}
/// <summary>
///
///围岩基本分级 </summary>
		public string TFSI_SRG {get;set;}
/// <summary>
///
///渗水量 </summary>
		public Nullable<double> TFSI_WATS {get;set;}
/// <summary>
///
///地下水状态 </summary>
		public string TFSI_GROS {get;set;}
/// <summary>
///
///地质构造应力状态 </summary>
		public string TFSI_GTSS {get;set;}
/// <summary>
///
///初始地应力状态 </summary>
		public string TFSI_INGS {get;set;}
/// <summary>
///
///修正后围岩级别 </summary>
		public string TFSI_CSRG {get;set;}
/// <summary>
///
///毛洞稳定情况 </summary>
		public string TFSI_STAB {get;set;}
/// <summary>
///
///预报结论 </summary>
		public string TFSI_FORC {get;set;}
/// <summary>
///
///后续建议 </summary>
		public string TFSI_ADVC {get;set;}
/// <summary>
///
///实际采取措施 </summary>
		public string TFSI_ACME {get;set;}
/// <summary>
///
///断层 </summary>
		public string TFSI_FAUL {get;set;}
/// <summary>
///
///初始应力 </summary>
		public string TFSI_STRE {get;set;}
/// <summary>
///
///岩体出露状态 </summary>
		public string TFSI_LEAK {get;set;}
/// <summary>
///
///支护情况 </summary>
		public string TFSI_SUPP {get;set;}
/// <summary>
///
///备注 </summary>
		public string TFSI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
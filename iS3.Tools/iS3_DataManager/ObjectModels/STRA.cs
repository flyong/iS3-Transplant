using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_STRA")]
	public class STRA:DGObject
 	{ 
/// <summary>
///
///地层ID </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///层顶埋深范围 </summary>
		public Nullable<double> STRA_TOP {get;set;}
/// <summary>
///
///层底标高范围 </summary>
		public Nullable<double> STRA_BASE {get;set;}
/// <summary>
///
///地层厚度范围 </summary>
		public string STRA_HDFW {get;set;}
/// <summary>
///
///平均厚度 </summary>
		public Nullable<double> STRA_PJHD {get;set;}
/// <summary>
///
///岩体完整性 </summary>
		public string STRA_YTWZ {get;set;}
/// <summary>
///
///地层总体描述 </summary>
		public string STRA_DESC {get;set;}
/// <summary>
///
///地层年代 </summary>
		public string STRA_GEO1 {get;set;}
/// <summary>
///
///地层岩性 </summary>
		public string STRA_GEO2 {get;set;}
/// <summary>
///
///地层记录编号 </summary>
		public string STRA_STAT {get;set;}
/// <summary>
///
///地层分布范围 </summary>
		public string STRA_DSRG {get;set;}
/// <summary>
///
///倾向 </summary>
		public Nullable<double> STRA_DIP {get;set;}
/// <summary>
///
///倾角 </summary>
		public Nullable<double> STRA_DIR {get;set;}
/// <summary>
///
///颜色 </summary>
		public string STRA_COLO {get;set;}
/// <summary>
///
///成因类型 </summary>
		public string STRA_CAUS {get;set;}
/// <summary>
///
///成分 </summary>
		public string STRA_COMP {get;set;}
/// <summary>
///
///结构构造 </summary>
		public string STRA_STRU {get;set;}
/// <summary>
///
///风化程度 </summary>
		public string STRA_DEGW {get;set;}
/// <summary>
///
///物理参数 </summary>
		public string STRA_PHYP {get;set;}
/// <summary>
///
///力学参数 </summary>
		public string STRA_MECP {get;set;}
/// <summary>
///
///有限元 </summary>
		public string FILE_FSET {get;set;}
	}
}
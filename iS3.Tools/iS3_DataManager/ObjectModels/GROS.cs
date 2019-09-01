using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GROS")]
	public class GROS:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
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
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string GROS_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string GROS_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string GROS_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string GROS_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string GROS_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> GROS_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string GROS_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验类型 </summary>
		public string GROS_TYPE {get;set;}
/// <summary>
///
///试验顶埋深 </summary>
		public Nullable<double> GROS_TOP {get;set;}
/// <summary>
///
///测量部位 </summary>
		public string GROS_MEAP {get;set;}
/// <summary>
///
///特征点压力 </summary>
		public Nullable<double> GROS_CHPP {get;set;}
/// <summary>
///
///水压读数 </summary>
		public Nullable<double> GROS_WAPR {get;set;}
/// <summary>
///
///开裂方位 </summary>
		public Nullable<int> GROS_CRAO {get;set;}
/// <summary>
///
///初始压裂压力 </summary>
		public Nullable<double> GROS_INFP {get;set;}
/// <summary>
///
///稳定开裂压力 </summary>
		public Nullable<double> GROS_STCR {get;set;}
/// <summary>
///
///关闭压力 </summary>
		public Nullable<double> GROS_LCOP {get;set;}
/// <summary>
///
///开启压力 </summary>
		public Nullable<double> GROS_OPEP {get;set;}
/// <summary>
///
///孔隙水压力 </summary>
		public Nullable<double> GROS_POWP {get;set;}
/// <summary>
///
///最小主应力 </summary>
		public Nullable<double> GROS_MIPS {get;set;}
/// <summary>
///
///最大主应力 </summary>
		public Nullable<double> GROS_MAPS {get;set;}
/// <summary>
///
///最大主应力方向 </summary>
		public Nullable<double> GROS_DMAX {get;set;}
/// <summary>
///
///备注 </summary>
		public string GROS_REM {get;set;}
	}
}
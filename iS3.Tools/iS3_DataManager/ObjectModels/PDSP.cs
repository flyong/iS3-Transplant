using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PDSP")]
	public class PDSP:DGObject
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
		public string PDSP_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string PEOP_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string PDSP_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string PDSP_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string PDSP_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> PDSP_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string PDSP_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验类型 </summary>
		public string PDSP_TYPE {get;set;}
/// <summary>
///
///初始水平应力 </summary>
		public Nullable<double> PDSP_INHS {get;set;}
/// <summary>
///
///初始水平应力对应体积 </summary>
		public Nullable<double> PDSP_IHSV {get;set;}
/// <summary>
///
///屈服压力 </summary>
		public Nullable<double> PDSP_YIEP {get;set;}
/// <summary>
///
///屈服压力对应体积 </summary>
		public Nullable<double> PDSP_YPCV {get;set;}
/// <summary>
///
///旁压器量测腔初始固有体积 </summary>
		public Nullable<double> PDSP_PMCV {get;set;}
/// <summary>
///
///旁压曲线直线段的斜率 </summary>
		public Nullable<double> PDSP_SOPC {get;set;}
/// <summary>
///
///旁压模量 </summary>
		public Nullable<double> PDSP_SPM {get;set;}
/// <summary>
///
///承载力特征值 </summary>
		public Nullable<int> PDSP_BCCV {get;set;}
/// <summary>
///
///备注 </summary>
		public string PDSP_REM {get;set;}
	}
}
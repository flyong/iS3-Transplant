using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_WAVE")]
	public class WAVE:DGObject
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
		public string WAVE_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string WAVE_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string WAVE_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string WAVE_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string WAVE_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> WAVE_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string WAVE_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string WAVE_DESC {get;set;}
/// <summary>
///
///测点编号 </summary>
		public string WAVE_MPNM {get;set;}
/// <summary>
///
///测点位置 </summary>
		public string WAVE_MPPS {get;set;}
/// <summary>
///
///测点地质描述 </summary>
		public string WAVE_MPGD {get;set;}
/// <summary>
///
///测点间距 </summary>
		public Nullable<double> WAVE_SPAC {get;set;}
/// <summary>
///
///传播时间 </summary>
		public Nullable<int> WAVE_TIME {get;set;}
/// <summary>
///
///岩体纵波波速 </summary>
		public Nullable<int> WAVE_RLWV1 {get;set;}
/// <summary>
///
///岩块纵波波速 </summary>
		public Nullable<int> WAVE_RLWV2 {get;set;}
/// <summary>
///
///岩体完整性系数 </summary>
		public Nullable<double> WAVE_RMIF {get;set;}
/// <summary>
///
///备注 </summary>
		public string WAVE_REM {get;set;}
	}
}
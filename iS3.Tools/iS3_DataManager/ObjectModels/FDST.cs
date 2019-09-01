using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_FDST")]
	public class FDST:DGObject
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
///试样来源 </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string _DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string FDST_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string FDST_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string FDST_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string FDST_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> FDST_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string FDST_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///剪切面描述 </summary>
		public string FDST_CLSD {get;set;}
/// <summary>
///
///法向荷载 </summary>
		public Nullable<int> FDST_NORL {get;set;}
/// <summary>
///
///法向应力 </summary>
		public Nullable<double> FDST_NORS {get;set;}
/// <summary>
///
///剪切应力 </summary>
		public Nullable<double> FDST_SHES {get;set;}
/// <summary>
///
///剪切位移 </summary>
		public Nullable<double> FDST_SHED {get;set;}
/// <summary>
///
///垂直位移 </summary>
		public Nullable<double> FDST_VERD {get;set;}
/// <summary>
///
///剪胀强度 </summary>
		public Nullable<double> FDST_DILS {get;set;}
/// <summary>
///
///剪切面破坏形态描述 </summary>
		public string FDST_SSFMD {get;set;}
/// <summary>
///
///峰值抗剪强度 </summary>
		public Nullable<double> FDST_PESS {get;set;}
/// <summary>
///
///抗剪强度 </summary>
		public Nullable<double> FDST_SHS {get;set;}
/// <summary>
///
///残余抗剪强度 </summary>
		public Nullable<double> FDST_RSHS {get;set;}
/// <summary>
///
///粘聚力 </summary>
		public Nullable<double> FDST_COF {get;set;}
/// <summary>
///
///残余粘聚力 </summary>
		public Nullable<double> FDST_RCOF {get;set;}
/// <summary>
///
///内摩擦角 </summary>
		public Nullable<double> FDST_AGF {get;set;}
/// <summary>
///
///残余内摩擦角 </summary>
		public Nullable<double> FDST_RAGF {get;set;}
	}
}
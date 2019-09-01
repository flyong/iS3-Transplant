using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_FREZ")]
	public class FREZ:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string FREZ_LOCA {get;set;}
/// <summary>
///
///样本ID </summary>
		public string SPEC_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string FREZ_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string FREZ_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string FREZ_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string FREZ_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string FREZ_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string FREZ_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///岩性 </summary>
		public string FREZ_LITH {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string FREZ_DESC {get;set;}
/// <summary>
///
///试样描述 </summary>
		public string FREZ_SAMD {get;set;}
/// <summary>
///
///试样个数 </summary>
		public Nullable<int> FREZ_SAMN {get;set;}
/// <summary>
///
///冻融前烘干质量 </summary>
		public Nullable<double> FREZ_DQBF {get;set;}
/// <summary>
///
///冻融前试件描述 </summary>
		public string FREZ_DPBF {get;set;}
/// <summary>
///
///冻融前饱水质量 </summary>
		public Nullable<double> FREZ_WMBF {get;set;}
/// <summary>
///
///冻融前质量损失率 </summary>
		public Nullable<double> FREZ_MLBF {get;set;}
/// <summary>
///
///冻融前吸水率 </summary>
		public Nullable<double> FREZ_WABF {get;set;}
/// <summary>
///
///冻融前破坏最大荷载 </summary>
		public Nullable<double> FREZ_DLBF {get;set;}
/// <summary>
///
///冻融前饱水抗压强度 </summary>
		public Nullable<double> FREZ_SCSBF {get;set;}
/// <summary>
///
///冻融后烘干质量 </summary>
		public Nullable<double> FREZ_DMAF {get;set;}
/// <summary>
///
///冻融后试件描述 </summary>
		public string FREZ_DPAF {get;set;}
/// <summary>
///
///冻融后饱水质量 </summary>
		public Nullable<double> FREZ_WMAF {get;set;}
/// <summary>
///
///冻融后质量损失率 </summary>
		public Nullable<double> FREZ_MLAF {get;set;}
/// <summary>
///
///冻融后吸水率 </summary>
		public Nullable<double> FREZ_WAAF {get;set;}
/// <summary>
///
///冻融后破坏最大荷载 </summary>
		public Nullable<double> FREZ_DLAF {get;set;}
/// <summary>
///
///冻融后饱水抗压强度 </summary>
		public Nullable<double> FREZ_SCSAF {get;set;}
/// <summary>
///
///冻融系数 </summary>
		public Nullable<double> FREZ_FREC {get;set;}
/// <summary>
///
///备注 </summary>
		public string FREZ_REM {get;set;}
	}
}
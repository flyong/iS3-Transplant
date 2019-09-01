using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TFSR")]
	public class TFSR:DGObject
 	{ 
/// <summary>
///
///掌子面素描成果数据ID </summary>
		public string TFSR_ID {get;set;}
/// <summary>
///
///岩体类型（名称） </summary>
		public string TFSR_ROCN {get;set;}
/// <summary>
///
///岩层产状 </summary>
		public string ATTD_ID {get;set;}
/// <summary>
///
///黏聚力 </summary>
		public Nullable<int> TFSR_COH {get;set;}
/// <summary>
///
///内摩擦角 </summary>
		public Nullable<double> TFSR_AOF {get;set;}
/// <summary>
///
///单轴饱和抗压强度 </summary>
		public Nullable<double> TFSR_USCS {get;set;}
/// <summary>
///
///点荷载强度极限 </summary>
		public Nullable<double> TFSR_PLSL {get;set;}
/// <summary>
///
///变形模量 </summary>
		public Nullable<double> TFSR_DEFM {get;set;}
/// <summary>
///
///泊松比 </summary>
		public Nullable<double> TFSR_POIS {get;set;}
/// <summary>
///
///天然重度 </summary>
		public Nullable<double> TFSR_NATS {get;set;}
/// <summary>
///
///岩性其他指标描述 </summary>
		public string TFSR_OTID {get;set;}
/// <summary>
///
///岩性硬度 </summary>
		public string TFSR_LIHS {get;set;}
/// <summary>
///
///地质构造影响程度 </summary>
		public string TFSR_GTID {get;set;}
/// <summary>
///
///结构面组数 </summary>
		public Nullable<int> TFSR_NUSQ {get;set;}
/// <summary>
///
///平均间距 </summary>
		public Nullable<double> TFSR_AVES {get;set;}
/// <summary>
///
///主结构面走向与洞轴线夹角 </summary>
		public Nullable<double> TFSR_ABSA {get;set;}
/// <summary>
///
///主要结构面产状 </summary>
		public string ATTD_ID1 {get;set;}
/// <summary>
///
///其他结构面产状 </summary>
		public string ATTD_ID2 {get;set;}
/// <summary>
///
///延伸性 </summary>
		public string TFSR_EXTE {get;set;}
/// <summary>
///
///粗糙度 </summary>
		public string TFSR_ROUG {get;set;}
/// <summary>
///
///张开度 </summary>
		public Nullable<int> TFSR_OPED {get;set;}
/// <summary>
///
///填充物 </summary>
		public string TFSR_FILL {get;set;}
/// <summary>
///
///风化程度 </summary>
		public string TFSR_DEGW {get;set;}
/// <summary>
///
///体积裂隙数J  </summary>
		public string TFSR_VOCN {get;set;}
/// <summary>
///
///岩体完整性系数Kv </summary>
		public string TFSR_RKV {get;set;}
/// <summary>
///
///岩体完整性 </summary>
		public string TFSR_ROCI {get;set;}
/// <summary>
///
///土名称 </summary>
		public string TFSR_SOIN {get;set;}
/// <summary>
///
///地质年代 </summary>
		public string TFSR_SAGE {get;set;}
/// <summary>
///
///地质成因 </summary>
		public string TFSR_GEOO {get;set;}
/// <summary>
///
///土体其他信息 </summary>
		public string TFSR_OSI {get;set;}
/// <summary>
///
///状态 </summary>
		public string TFSR_STAT {get;set;}
/// <summary>
///
///湿度 </summary>
		public string TFSR_HUMI {get;set;}
/// <summary>
///
///密实度 </summary>
		public string TFSR_COMP {get;set;}
/// <summary>
///
///级配 </summary>
		public string TFSR_GRAD {get;set;}
/// <summary>
///
///密度 </summary>
		public Nullable<double> TFSR_DENS {get;set;}
/// <summary>
///
///含水量 </summary>
		public Nullable<double> TFSR_WATC {get;set;}
/// <summary>
///
///压缩模量 </summary>
		public Nullable<double> TFSR_COMM {get;set;}
/// <summary>
///
///纵波波速 </summary>
		public Nullable<double> TFSR_LWV {get;set;}
/// <summary>
///
///备注 </summary>
		public string TFSR_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
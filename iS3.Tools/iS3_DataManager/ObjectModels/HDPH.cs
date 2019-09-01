using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_HDPH")]
	public class HDPH:DGObject
 	{ 
/// <summary>
///
///钻孔位置 </summary>
		public string LOCA_ID {get;set;}
/// <summary>
///
///钻孔ID </summary>
		public string HDPH_ID {get;set;}
/// <summary>
///
///钻孔类型 </summary>
		public string HDPH_TYPE {get;set;}
/// <summary>
///
///钻进方法 </summary>
		public string HDPH_METH {get;set;}
/// <summary>
///
///目的 </summary>
		public string HDPH_ZKMD {get;set;}
/// <summary>
///
///孔口标高 </summary>
		public Nullable<double> HDPH_TOP {get;set;}
/// <summary>
///
///终孔深度 </summary>
		public string HDPH_ENDD {get;set;}
/// <summary>
///
///孔径 </summary>
		public Nullable<double> PEOP_DIAM {get;set;}
/// <summary>
///
///钻孔偏斜角 </summary>
		public Nullable<int> HDPH_BDA {get;set;}
/// <summary>
///
///测斜深度 </summary>
		public Nullable<double> HDPH_SHOR {get;set;}
/// <summary>
///
///含水层初见水位  </summary>
		public Nullable<double> HDPH_STAB {get;set;}
/// <summary>
///
///地层信息 </summary>
		public string HDPH_STRA {get;set;}
/// <summary>
///
///取芯率 </summary>
		public Nullable<double> HDPH_QXL {get;set;}
/// <summary>
///
///含水层初见水位 </summary>
		public Nullable<double> HDPH_CJSW {get;set;}
/// <summary>
///
///含水层稳定水位 </summary>
		public Nullable<double> HDPH_WDSW {get;set;}
/// <summary>
///
///含水段个数 </summary>
		public Nullable<int> HDPH_HSGS {get;set;}
/// <summary>
///
///含水段起止深度 </summary>
		public string HDPH_QZSD {get;set;}
/// <summary>
///
///地下水类型 </summary>
		public string HDPH_WTYP {get;set;}
/// <summary>
///
///地下水水质描述 </summary>
		public string HDPH_WDES {get;set;}
/// <summary>
///
///开始时间 </summary>
		public string HDPH_STAT {get;set;}
/// <summary>
///
///结束时间 </summary>
		public string FILE_ENDT {get;set;}
/// <summary>
///
///人员信息 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///机器类型 </summary>
		public string HDPH_JQLX {get;set;}
/// <summary>
///
///稳定性 </summary>
		public string HDPH_WDX {get;set;}
/// <summary>
///
///所用钻头 </summary>
		public string HDPH_ZTLX {get;set;}
/// <summary>
///
///钻头环境 </summary>
		public string HDPH_ZKHJ {get;set;}
/// <summary>
///
///套筒类型 </summary>
		public string HDPH_TTLX {get;set;}
/// <summary>
///
///套筒长度 </summary>
		public Nullable<double> HDPH_TTCD {get;set;}
/// <summary>
///
///备注 </summary>
		public string HDPH_REM {get;set;}
/// <summary>
///
///掘进期间天气和环境条件的详细情况 </summary>
		public string HDPH_DESC {get;set;}
/// <summary>
///
///掘进单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///回填方法 </summary>
		public string HDPH_HTFF {get;set;}
/// <summary>
///
///回填材料 </summary>
		public string HDPH_HTCL {get;set;}
/// <summary>
///
///引用标准 </summary>
		public string HDPH_YYBZ {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
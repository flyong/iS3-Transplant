using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_PUMP")]
	public class PUMP:DGObject
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
///水文钻孔（井）ID </summary>
		public string HYDW_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string PUMP_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string PUMP_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string PUMP_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string PUMP_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string PUMP_METH {get;set;}
/// <summary>
///
///试验深度 </summary>
		public Nullable<double> PUMP_DPTH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string PUMP_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试验描述 </summary>
		public string PUMP_DESC {get;set;}
/// <summary>
///
///抽水水位 </summary>
		public Nullable<double> PUMP_PUWL {get;set;}
/// <summary>
///
///静止水位 </summary>
		public Nullable<double> PUMP_STWL {get;set;}
/// <summary>
///
///抽水量 </summary>
		public Nullable<double> PUMP_PUMC {get;set;}
/// <summary>
///
///单位出水量 </summary>
		public Nullable<double> PUMP_SPEY {get;set;}
/// <summary>
///
///含水层厚度 </summary>
		public Nullable<double> PUMP_AQUT {get;set;}
/// <summary>
///
///水文钻孔（井）孔径 </summary>
		public Nullable<double> PUMP_HYDD {get;set;}
/// <summary>
///
///降深次序 </summary>
		public string PUMP_DEPO {get;set;}
/// <summary>
///
///主钻孔降深 </summary>
		public Nullable<double> PUMP_MABD {get;set;}
/// <summary>
///
///对应方向孔号 </summary>
		public string PUMP_CDHN {get;set;}
/// <summary>
///
///影响半径 </summary>
		public Nullable<double> PUMP_INFR {get;set;}
/// <summary>
///
///涌水量 </summary>
		public Nullable<double> PUMP_WATI {get;set;}
/// <summary>
///
///渗透系数 </summary>
		public Nullable<double> PUMP_PERC {get;set;}
/// <summary>
///
///导水系数 </summary>
		public Nullable<double> PUMP_WACC {get;set;}
/// <summary>
///
///贮水系数 </summary>
		public Nullable<double> PUMP_WASC {get;set;}
/// <summary>
///
///备注 </summary>
		public string PUMP_REM {get;set;}
	}
}
using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GEPR")]
	public class GEPR:DGObject
 	{ 
/// <summary>
///
///物探成果ID </summary>
		public string GEPR_ID {get;set;}
/// <summary>
///
///设备名称 </summary>
		public string GEPR_DEVN {get;set;}
/// <summary>
///
///激发孔个数 </summary>
		public Nullable<int> GEPR_NOEH {get;set;}
/// <summary>
///
///激发孔平均深度 </summary>
		public Nullable<double> GEPR_ADEH {get;set;}
/// <summary>
///
///激发孔平均直径 </summary>
		public Nullable<double> GEPR_ADEH2 {get;set;}
/// <summary>
///
///激发孔距底面平均高度 </summary>
		public Nullable<double> GEPR_AHEH {get;set;}
/// <summary>
///
///激发孔间距 </summary>
		public Nullable<double> GEPR_SPEH {get;set;}
/// <summary>
///
///接收孔个数 </summary>
		public Nullable<int> GEPR_NORH {get;set;}
/// <summary>
///
///接收孔平均深度 </summary>
		public Nullable<double> GEPR_ADRH {get;set;}
/// <summary>
///
///接收孔平均直径 </summary>
		public Nullable<double> GEPR_ADRH2 {get;set;}
/// <summary>
///
///接收孔距底面平均高度 </summary>
		public Nullable<double> GEPR_AHRH {get;set;}
/// <summary>
///
///检波器名称或编 </summary>
		public string GEPR_DETN {get;set;}
/// <summary>
///
///检波器序号 </summary>
		public string GEPR_DESN {get;set;}
/// <summary>
///
///波型 </summary>
		public string GEPR_WAVP {get;set;}
/// <summary>
///
///检波器所在里程值 </summary>
		public Nullable<double> GEPR_DEMV {get;set;}
/// <summary>
///
///速度 </summary>
		public Nullable<double> GEPR_SPED {get;set;}
/// <summary>
///
///Vp/Vs </summary>
		public Nullable<double> GEPR_VPVS {get;set;}
/// <summary>
///
///泊松比 </summary>
		public Nullable<double> GEPR_POIS {get;set;}
/// <summary>
///
///密度 </summary>
		public Nullable<double> GEPR_DENS {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///测区数量 </summary>
		public Nullable<int> GEPR_NOSR {get;set;}
/// <summary>
///
///测区测点数量 </summary>
		public Nullable<int> GEPR_NOMP {get;set;}
/// <summary>
///
///接收方式 </summary>
		public string GEPR_RECM {get;set;}
/// <summary>
///
///测线条数 </summary>
		public Nullable<int> GEPR_MENL {get;set;}
/// <summary>
///
///测点序号 </summary>
		public string GEPR_MEPN {get;set;}
/// <summary>
///
///距拱顶距离 </summary>
		public Nullable<double> GEPR_DFTV {get;set;}
/// <summary>
///
///距左线距离 </summary>
		public Nullable<double> GEPR_DFTL {get;set;}
/// <summary>
///
///测线数量 </summary>
		public Nullable<int> GEPR_NUML {get;set;}
/// <summary>
///
///测线名称 </summary>
		public string GEPR_LINN {get;set;}
/// <summary>
///
///设备型号 </summary>
		public string GEPR_EQUM {get;set;}
/// <summary>
///
///天线工作频率 </summary>
		public Nullable<int> GEPR_ANOF {get;set;}
/// <summary>
///
///测线序号 </summary>
		public string GEPR_LINN2 {get;set;}
/// <summary>
///
///起点X坐标 </summary>
		public string GEPR_SPCX {get;set;}
/// <summary>
///
///起点Y坐标 </summary>
		public string GEPR_SPCY {get;set;}
/// <summary>
///
///终点X坐标 </summary>
		public string GEPR_EPCX {get;set;}
/// <summary>
///
///终点Y坐标 </summary>
		public string GEPR_EPCY {get;set;}
/// <summary>
///
///供电电极数量 </summary>
		public Nullable<int> GEPR_NPSE {get;set;}
/// <summary>
///
///测量电极测点数量 </summary>
		public Nullable<int> GEPR_MNEP {get;set;}
/// <summary>
///
///供电电压 </summary>
		public Nullable<int> GEPR_SUPV {get;set;}
/// <summary>
///
///供电电流 </summary>
		public Nullable<int> GEPR_SUPC {get;set;}
/// <summary>
///
///电极序号 </summary>
		public string GEPR_ELEN {get;set;}
/// <summary>
///
///类型 </summary>
		public string GEPR_TYPE {get;set;}
/// <summary>
///
///距掌子面距离 </summary>
		public Nullable<double> GEPR_DFTF {get;set;}
/// <summary>
///
///采集装置类型 </summary>
		public string GEPR_ACDT {get;set;}
/// <summary>
///
///发射框位置里程 </summary>
		public Nullable<double> GEPR_LFLM {get;set;}
/// <summary>
///
///发射框长 </summary>
		public Nullable<double> GEPR_LAFL {get;set;}
/// <summary>
///
///发射框宽 </summary>
		public Nullable<double> GEPR_EMFW {get;set;}
/// <summary>
///
///激发线圈匝数 </summary>
		public Nullable<int> GEPR_EXCT {get;set;}
/// <summary>
///
///接收框长 </summary>
		public Nullable<double> GEPR_REFL {get;set;}
/// <summary>
///
///接收框宽 </summary>
		public Nullable<double> GEPR_REFW {get;set;}
/// <summary>
///
///接收框匝数 </summary>
		public Nullable<int> GEPR_REFN {get;set;}
/// <summary>
///
///接收线圈等效面积 </summary>
		public Nullable<double> GEPR_RCEA {get;set;}
/// <summary>
///
///收发距 </summary>
		public Nullable<double> GEPR_TRAD {get;set;}
/// <summary>
///
///发射频率 </summary>
		public Nullable<int> GEPR_TRAF {get;set;}
/// <summary>
///
///测量时间 </summary>
		public Nullable<int> GEPR_MEAT {get;set;}
/// <summary>
///
///盲区范围 </summary>
		public Nullable<double> GEPR_BLIZ {get;set;}
/// <summary>
///
///测线布置描述 </summary>
		public string GEPR_LILD {get;set;}
	}
}
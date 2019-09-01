using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_DFRA")]
	public class DFRA:DGObject
 	{ 
/// <summary>
///
///里程冠号 </summary>
		public string DFBI_MILE {get;set;}
/// <summary>
///
///掌子面里程值 </summary>
		public Nullable<double> DFBI_TUFM {get;set;}
/// <summary>
///
///孔位ID </summary>
		public string DFRA_ID {get;set;}
/// <summary>
///
///距拱顶距离 </summary>
		public Nullable<double> DFRA_DISD {get;set;}
/// <summary>
///
///距中心线距离 </summary>
		public Nullable<double> DFRA_DISC {get;set;}
/// <summary>
///
///开孔立角角度 </summary>
		public Nullable<int> DFRA_ANG1 {get;set;}
/// <summary>
///
///开孔偏角角度 </summary>
		public Nullable<int> DFRA_ANG2 {get;set;}
/// <summary>
///
///孔径/坑道边长 </summary>
		public Nullable<double> DFRA_APER {get;set;}
/// <summary>
///
///钻机型号 </summary>
		public string DFRA_RIGM {get;set;}
/// <summary>
///
///开始时间 </summary>
		public string DFRA_STIM {get;set;}
/// <summary>
///
///结束时间 </summary>
		public string DFRA_ETIM {get;set;}
/// <summary>
///
///是否取芯 </summary>
		public Nullable<bool> DFRA_WHTC {get;set;}
/// <summary>
///
///钻探深度 </summary>
		public Nullable<double> DFRA_DRID {get;set;}
/// <summary>
///
///钻探压力 </summary>
		public Nullable<double> DFRA_DRIP {get;set;}
/// <summary>
///
///钻速 </summary>
		public Nullable<int> DFRA_PENR {get;set;}
/// <summary>
///
///孔内水压 </summary>
		public Nullable<double> DFRA_HWP {get;set;}
/// <summary>
///
///孔内水量 </summary>
		public Nullable<double> DFRA_HWV {get;set;}
/// <summary>
///
///钻进特征及地质情况简述 </summary>
		public string DFRA_DCGC {get;set;}
/// <summary>
///
///备注 </summary>
		public string DFRA_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}
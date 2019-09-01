using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    [Table("Project_ProjectList")]
    public class ProjectList:iS3Entity
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 工程代号
        /// </summary>
        public string CODE { get; set; }
        /// <summary>
        /// 工程标题
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 工程数据库ID
        /// </summary>
        public Nullable<int> DBID { get; set; }
        /// <summary>
        /// 文件服务地址
        /// </summary>
        public string FileService { get; set; }
        /// <summary>
        /// 地图服务地址
        /// </summary>
        public string GeoService { get; set; }
        /// <summary>
        /// 分析服务地址
        /// </summary>
        public string AnalysisService { get; set; }
        /// <summary>
        /// 默认地图ID
        /// </summary>
        public Nullable<int> DefaultMapID { get; set; }
        /// <summary>
        /// 工程X坐标
        /// </summary>
        public Nullable<Decimal> X { get; set; }
        /// <summary>
        /// 工程Y坐标
        /// </summary>
        public Nullable<Decimal> Y { get; set; }
        /// <summary>
        /// 模块列表
        /// </summary>
        public string ModuleIDs { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}

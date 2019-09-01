using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Monitoring.Model
{
    /// <summary>
    /// 监测仪器信息表
    /// </summary>
    [Table("Monitoring_MonEquipment")]
    public class MonEquipment:DGObject
    {
        //仪器名称
        public string Name { get; set; }
        //所属单位
        public int UnitID { get; set; }
        //备注
        public string Remark { get; set; }
    }
}

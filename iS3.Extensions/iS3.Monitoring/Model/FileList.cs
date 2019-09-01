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
    /// 文档信息
    /// </summary>
    [Table("Monitoring_FileList")]
    public class FileList:DGObject
    {
        //文件名称
        public string FileName { get; set; }
        //文件路径
        public string FilePath { get; set; }
        //上传人员
        public int UserID { get; set; }
        //上传时间
        public DateTime UpLoadTime { get; set; }
        //修改时间
        public DateTime ModifyTime { get; set; }
        //备注
        public string Remark { get; set; }
    }
}

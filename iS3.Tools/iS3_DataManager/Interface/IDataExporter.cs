using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.Models;

namespace iS3_DataManager.Interface
{
    /// <summary>
    /// generate a templete for data input,default path is destop
    /// </summary>
    public interface IDataExporter
    {
        /// <summary>
        /// generate a templete for data input
        /// </summary>
        /// <param name="path"></param>
        /// <returns>return exprot result:Success of fail</returns>
       bool Export(StandardDef standard, string path=null);
       bool Export(StageDef domain, string path=null);
    }
}

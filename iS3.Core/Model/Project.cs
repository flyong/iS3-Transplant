using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    public partial class Project
    {
        /// <summary>
        /// 工程ID
        /// </summary>
        public string projectID { get; set; }
        /// <summary>
        /// 工程定义信息
        /// </summary>
        public ProjectInfo projectInfo { get; set; }
        /// <summary>
        /// 工程对应的Domain域
        /// </summary>
        public List<Domain> domains { get; set; }

        public  List<EngineeringMap> emaps { get; set; }
        public Project()
        {
            objsDefIndex = new Dictionary<string, DGObjects>();
        }
        /// <summary>
        /// 根据域名获取对应的Domain实例
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public Domain getDomain(string domainName)
        {
            return domains.Where(x => x.name == domainName).FirstOrDefault();
        }

        //Summary:
        //      Objs Def index class
        //Reamrk:
        //      DGObjects can be access with its name which is specified
        /// <summary>
        /// 工程对象组索引
        /// </summary>
        [NotMapped]
        public Dictionary<string, DGObjects> objsDefIndex { get; set; }

        //Summary:
        //      Objs def index to 2D layer
        //Remark:
        //      DGObjects can be access with related gis layer name
        public List<DGObjects> Get2dRelatedObjs(string layerName)
        {
            return objsDefIndex.Values.Where(x => x.definition.GISLayerName == layerName).ToList();
        }
        public List<DGObjects> Get3dRelatedObjs(string layerName)
        {
            return objsDefIndex.Values.Where(x => x.definition.Layer3DName == layerName).ToList();
        }
        // Summary:
        //     Find objects with given layer ID
        //     python is3.py use this function
        //
        public DGObjects findObjects(string layerID)
        {
            return Get2dRelatedObjs(layerID).FirstOrDefault();
        }

    }

}

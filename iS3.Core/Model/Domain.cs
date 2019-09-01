using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    public class Domain
    {
        /// <summary>
        /// Domain名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Domain下属的所有对象组
        /// </summary>
        public List<DGObjects> DGObjectsList { get; set; }

        /// <summary>
        /// 父对象Project
        /// </summary>
        [NotMapped]
        public Project parent { get; set; }
        /// <summary>
        /// Domain下的对象组定义
        /// </summary>
        [NotMapped]
        public List<ObjectsDefinition> objectsDefinitions { get; set; }

        [NotMapped]
        public TreeDefinition root { get; set; }
        /// <summary>
        /// 根据对象组ID获取对应的DGObjects实例
        /// </summary>
        /// <param name="objID"></param>
        /// <returns></returns>
        public DGObjects GetDGObjects(int objID)
        {
            return DGObjectsList.Where(x => x.definition.ID == objID).FirstOrDefault();
        }
        public ObjectsDefinition GetObjectsDefinition(int objID)
        {
            return objectsDefinitions.Where(x => x.ID == objID).FirstOrDefault();
        }
    }
}

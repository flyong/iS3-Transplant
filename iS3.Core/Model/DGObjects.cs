using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Model
{
    public partial class DGObjects
    {
        /// <summary>
        /// 父节点Domain
        /// </summary>
        [NotMapped]
        public Domain parent { get; set; }

        /// <summary>
        /// 对象组定义
        /// </summary>
        [NotMapped]
        public ObjectsDefinition definition { get; set; }

        /// <summary>
        /// 对象组内包含的所有对象
        /// </summary>
        [NotMapped]
        public List<DGObject> objContainer { get; set; }

        /// <summary>   
        /// 对象组筛选
        /// </summary>
        public string filter { get; set; }

        public string GetFilter()
        {
            string result = filter == null ? "" : filter;
            result += ((filter != null) && (filter.Length > 0) && (definition.ConditionSQL != null) && (definition.ConditionSQL.Length > 0)) ? "and" + definition.ConditionSQL : definition.ConditionSQL;
            return result;
        }
    }
}

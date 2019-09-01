using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3_DataManager.ViewManager
{
    public class TreeNode
    {
        public int NodeID { get; set; }
        public int Level { get; set; }
        public string Context { get; set; }
        public string Code { get; set; }
        public string Parent { get; set; }
        public bool isExpanded { get; set; }
        public bool isSelected { get; set; }
        public List<TreeNode> ChildNodes { get; set; }
        public TreeNode()
        {
            isExpanded = false;
            ChildNodes = new List<TreeNode>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3_DataManager.StandardManager;
using iS3_DataManager.Models;
using System.ComponentModel;

namespace iS3_DataManager.ViewManager
{
    public class TreeViewData : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<TreeNode> treeNodes { get; set; }
        public List<TreeNode> TreeNodes
        {
            get { return treeNodes; }
            set
            {
                treeNodes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TreeNodes"));
            }
        }
        public TreeViewData(StandardDef Standard)
        {

            GenerateNodes(Standard);
            treeNodes = TreeNodes;
        }
        public TreeViewData()
        {
            treeNodes = new List<TreeNode>();
            TreeNodes = new List<TreeNode>();
        }


        private void GenerateNodes(StandardDef standardDef)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            int index = 0;
            if (standardDef == null)
                return;
            foreach (StageDef domain in standardDef.StageContainer)
            {
                TreeNode stageTreeNode = new TreeNode()
                {
                    NodeID = index++,
                    Level = 1,
                    Code=domain.Code,
                    Context = domain.LangStr,
                    isExpanded = true,
                    isSelected = false
                };
                foreach (DGObjectDef dG in domain.DGObjectContainer)
                {
                    TreeNode categoryTreeNode = new TreeNode()
                    {
                        NodeID = index++,
                        Level = 2,
                        Code = dG.Code,
                        Context = dG.LangStr,
                        Parent = domain.Code,
                        isExpanded = false,
                        isSelected = false
                    };
                    stageTreeNode.ChildNodes.Add(categoryTreeNode);
                }
                nodes.Add(stageTreeNode);
            }
            TreeNodes = nodes;
        }

    }
}

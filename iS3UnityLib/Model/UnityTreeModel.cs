using UnityEngine;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace iS3UnityLib.Model.ObjModel
{
    [Serializable]
    public class UnityTreeModel:INotifyPropertyChanged
    {
        private LayerTreeNode _layerTreeNode;
        //Unity对象的树状结构
        public LayerTreeNode layerTreeNode {
            get { return _layerTreeNode; }
            set {
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("layerTreeNode"));
                }
                _layerTreeNode = value;
            }
        }

        public UnityTreeModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    [Serializable]
    public class LayerTreeNode : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string path { get; set; }

        private bool visibility;

        public bool Visibility
        {
            get { return visibility; }
            set
            {
                if (visibility != value)
                {
                    visibility = value;
                    if (this.PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Visibility"));
                }
            }
        }
        private bool transparent;

        public bool Transparent
        {
            get { return transparent; }
            set
            {
                if (transparent != value)
                {
                    transparent = value;
                    if (this.PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Transparent"));
                }
            }
        }
        //public  UnityObjModel model { get; set; }
        public List<LayerTreeNode> childNodes { get; set; }

        public LayerTreeNode(string _name)
        {
            name = _name;
            visibility = true;
            transparent = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


    //
    //class UnityLayerModel   Unity 图层
    //tree   平状
    //iS3Project
    //------Project1
    public class UnityLayerModel
    {
        public List<LayerTreeNode> childNodes { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace iS3UnityLib.Model.Event
{
    public class AddSchemeModelEvent : UnityEvent
    {
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.AddTransparentEvent;

        public ModelPrefabDef definition { get; set; }
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public AddSchemeModelEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {
        }
    }

    public class ModelPrefabDef : INotifyPropertyChanged
    {
        private bool isChecked = false;

        public bool IsChecked
        {

            get { return isChecked; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
                }
                isChecked = value;
            }
        }
        private string chName;
        // 预设体名称
        public string ChName
        {

            get { return chName; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ChName"));
                }
                chName = value;
            }
        }
        private string prefabName;
        // 预设体名称
        public string PrefabName
        {

            get { return prefabName; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PrefabName"));
                }
                prefabName = value;
            }
        }
        private string fullName;
        //模型别名
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                }
                fullName = value;
            }
        }
        public bool IsSelected { get; set; }
        private ModelPrefabType modelType;
        public ModelPrefabType ModelType
        {
            get { return modelType; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ModelType"));
                }
                modelType = value;
            }
        }
        public ObservableCollection<Pos> Position { get; set; } = new ObservableCollection<Pos>();

        public ModelPrefabDef()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public enum ModelPrefabType
    {
        ModelWithOnePos,
        ModelWithPosList,
    }
}

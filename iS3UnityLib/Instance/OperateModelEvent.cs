using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class OperateModelEvent : UnityEvent
    {
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.AddTransparentEvent;

        public ModelPrefabDef definition { get; set; }
        public bool iSContinue { get; set; }
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public OperateModelEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {
        }
    }
}

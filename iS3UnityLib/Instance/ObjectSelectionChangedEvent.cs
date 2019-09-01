using UnityEngine;
using System.Collections.Generic;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class ObjectSelectionChangedEvent : UnityEvent
    {
        public List<UnityObjModel> addSelectionList { get; set; }
        public List<UnityObjModel> removeSelectionList { get; set; }

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.ObjectSelectionChangedEvent;
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public ObjectSelectionChangedEvent(UnityEventType aEventType) : base(aEventType)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class SetObjShowEvent : UnityEvent
    {
        public string ObjName;
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SetObjShowEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SetObjShowEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {

        }
    }
}

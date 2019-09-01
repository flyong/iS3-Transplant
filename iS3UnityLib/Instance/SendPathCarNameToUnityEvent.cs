using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class SendPathCarNameToUnityEvent : UnityEvent
    {
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SendPathCarNameToUnityEvent;

        public string PathName { get; set; }
        public string CarName { get; set; }

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SendPathCarNameToUnityEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {

        }
    }
}



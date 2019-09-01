using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class QueryCameraPosEvent : UnityEvent
    {
        public int cameraID { get; set; }
        public float px { get; set; }
        public float py { get; set; }
        public float pz { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
        public float rw { get; set; }
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.QueryCameraPosEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public QueryCameraPosEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
         
        }
    }
}
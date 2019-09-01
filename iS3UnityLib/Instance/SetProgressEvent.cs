using System;
using System.Collections.Generic;
using UnityEngine;

namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class SetProgressEvent : UnityEvent
    {
        public List<TunnelSection> TunnelSectionList;
        public List<string> TunnelPointList;
        public bool state { get; set; }
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SetProgressEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SetProgressEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
        }
    }
    public class TunnelSection
    {
        public string startM { get; set; }
        public string endM { get; set; }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class SetPointEvent : UnityEvent
    {
        public string Domain { get; set; }
        public string ObjType { get; set; }
        public List<string> TunnelPointList;     //mileage.id
        public List<string> ImageList { get; set; }
        public bool state { get; set; }
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SetPointEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SetPointEvent(UnityEventType aEventType) : base(aEventType)
        {
            TunnelPointList = new List<string>();
            ImageList = new List<string>();
        }
        public override void UnityAction()
        {
           
        }
    }
}

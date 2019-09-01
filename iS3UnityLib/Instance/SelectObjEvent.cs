using System.Collections.Generic;
using UnityEngine;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class SelectObjEvent : UnityEvent
    {

        public string layerName;
        public string ID;
        public bool isSelected;
        public Dictionary<string, string> infos;
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SelectObjEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SelectObjEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
      
    }
}

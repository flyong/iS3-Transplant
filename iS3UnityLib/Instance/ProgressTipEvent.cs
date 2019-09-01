
using System;
using System.Collections.Generic;


namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class ProgressTipEvent : UnityEvent
    {

        public List<string> mList;
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.ProgressTipEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public ProgressTipEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
      
    }
}

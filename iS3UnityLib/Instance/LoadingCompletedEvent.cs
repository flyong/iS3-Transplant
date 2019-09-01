using UnityEngine;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class LoadingCompletedEvent : UnityEvent
    {

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        /// 
        public static UnityEventType MyEventType = UnityEventType.LoadingCompletedEvent;
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public LoadingCompletedEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
    }
}
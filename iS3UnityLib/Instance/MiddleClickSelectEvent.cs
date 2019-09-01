using UnityEngine;

namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class MiddleClickSelectEvent : UnityEvent
    {
        // GETTER / SETTER  
        /// <summary>  
        /// An example of event-specific data you can add in.  
        /// </summary>  
        private RaycastHit _hitInfo;
        public RaycastHit hitInfo
        {
            get
            {
                return _hitInfo;
            }
            set
            {
                _hitInfo = value;
            }
        }

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.MiddleClickSelectEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public MiddleClickSelectEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
    }
}
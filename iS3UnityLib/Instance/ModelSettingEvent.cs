using UnityEngine;
using iS3UnityLib.Model.ObjModel;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    public class ModelSettingEvent : UnityEvent
    {
        public string path;
        public ProgressModel progress;
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.ModelSettingEvent;

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public ModelSettingEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
          
        }
    }
}
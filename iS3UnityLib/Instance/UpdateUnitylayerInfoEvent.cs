using UnityEngine;
using iS3UnityLib.Model.ObjModel;
using Newtonsoft.Json;
namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// Obj Select event.  
    /// </summary>  
    [JsonObject(MemberSerialization.OptOut)]
    public class UpdateUnitylayerInfoEvent : UnityEvent
    {

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.UpdateUnitylayerInfoEvent;
        public UnityTreeModel MyUnitylayerModel
        {
            get;set;
        }
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public UpdateUnitylayerInfoEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
    }
}
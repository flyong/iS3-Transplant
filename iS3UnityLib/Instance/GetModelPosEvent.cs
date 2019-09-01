using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;
using System.Collections.ObjectModel;

namespace iS3UnityLib.Model.Event
{
    public class GetModelPosEvent : UnityEvent
    {
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.AddTransparentEvent;


        public ObservableCollection<Pos> PositionList { get; set; }
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public GetModelPosEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {
        }
    }
    public class Pos
    {

        public float px { get; set; }
        public float py { get; set; }
        public float pz { get; set; }
        public float rx { get; set; }
        public float ry { get; set; }
        public float rz { get; set; }
        public float rw { get; set; }
    }
}

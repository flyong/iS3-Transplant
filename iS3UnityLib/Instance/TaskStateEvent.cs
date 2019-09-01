using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class TaskStateEvent : UnityEvent
    {
        public UnityEventType MyEventType = UnityEventType.TaskStateEvent;

        public string path { get; set; }

        public bool state { get; set; } //true表示完成，false表示滞后

        public TaskStateEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
           
        }
    }



}

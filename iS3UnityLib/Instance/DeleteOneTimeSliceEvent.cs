using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class DeleteOneTimeSliceEvent : UnityEvent
    {
        public UnityEventType MyEventType = UnityEventType.DeleteOneTimeSliceEvent;

        public DeleteOneTimeSliceEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
        }

    }
}

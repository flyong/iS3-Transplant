using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class DeleteTaskStateEvent : UnityEvent
    {

        public UnityEventType MyEventType = UnityEventType.DeleteTaskStateEvent;

        public DeleteTaskStateEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
        }
    }


}

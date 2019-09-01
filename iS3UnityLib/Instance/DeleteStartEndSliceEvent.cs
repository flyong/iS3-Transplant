using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class DeleteStartEndSliceEvent : UnityEvent
    {

        public UnityEventType MyEventType = UnityEventType.DeleteStartEndSliceEvent;


        public DeleteStartEndSliceEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {
        }
    }

}

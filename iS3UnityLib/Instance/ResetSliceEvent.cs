using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class ResetSliceEvent : UnityEvent
    {
        public bool isReset;
        public static UnityEventType MyEventType = UnityEventType.ResetSliceEvent;
        public ResetSliceEvent(UnityEventType aEventType) : base(aEventType)
        {

        }
        public override void UnityAction()
        {

        }
    }
}

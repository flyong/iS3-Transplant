using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class PauseSliceEvent : UnityEvent
    {

        public static UnityEventType MyEventType = UnityEventType.PauseSliceEvent;

        //暂停或者回复
        public bool isPause;

        //地址
        public string path;

        public PauseSliceEvent(UnityEventType aEventType) : base(aEventType)
        {

        }


        public override void UnityAction()
        {
            //根据物体进行设置暂停或取消暂停

        }
    }
}

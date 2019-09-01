using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class SetObjHighlightEvent : UnityEvent
    {

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SetColorAlphaEvent;

        public string path = string.Empty;   //"/a/b/c"


        public bool isHighlight = false;

        public SetObjHighlightEvent(UnityEventType aEventType) : base(aEventType)
        {

        }


        public override void UnityAction()
        {
         
        }
    }
}

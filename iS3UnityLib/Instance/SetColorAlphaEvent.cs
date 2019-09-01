using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public enum ColorEnum
    {
        Red,
        Blue,
        White
    }
    public class SetColorAlphaEvent : UnityEvent
    {

        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.SetColorAlphaEvent;

        public string path = string.Empty;   //"/a/b/c"

        public ColorEnum colorEnum;

        public float transparent;

        public SetColorAlphaEvent(UnityEventType aEventType) : base(aEventType)
        {

        }


        public override void UnityAction()
        {
            


        }
    }
}

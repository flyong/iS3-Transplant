using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class QuerySelectObjEvent : UnityEvent
    {
        public List<string> paths { get; set; }

        public static UnityEventType MyEventType = UnityEventType.QuerySelectObjEvent;

        public QuerySelectObjEvent(UnityEventType aEventType) : base(aEventType)
        {

        }

        public override void UnityAction()
        {
         
        }
    }
}

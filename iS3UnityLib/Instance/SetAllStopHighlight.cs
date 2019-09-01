﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;

namespace iS3UnityLib.Model.Event
{
    public class SetAllStopHighlight : UnityEvent
    {
        public static UnityEventType MyEventType = UnityEventType.SetAllStopHighlight;
        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public SetAllStopHighlight(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {
        }
    }
}
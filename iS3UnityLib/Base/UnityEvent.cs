namespace iS3UnityLib.Model.Event
{
    /// <summary>  
    /// 事件事件接口  
    /// </summary>  
    public class UnityEvent : IEvent
    {
        // GETTER / SETTER  
        /// <summary>  
        /// The _type_string.  
        /// </summary>  
        private UnityEventType _eventType;
        public  UnityEventType type
        {
            get
            {
                return _eventType;
            }
            set
            {
                _eventType = value;

            }
        }

        /// <summary>  
        /// The _target_object.  
        /// </summary>  
        private object _target_object;
        object IEvent.target
        {
            get
            {
                return _target_object;
            }
            set
            {
                _target_object = value;

            }
        }

        ///<summary>  
        ///  Constructor  
        ///</summary>  
        public UnityEvent(UnityEventType aEventType)
        {
            //  
            _eventType = aEventType;
        }

        public virtual void UnityAction()
        {

        }
        /// <summary>  
        /// Deconstructor  
        /// </summary>  
        //~Event ( )  
        //{  
        //  Debug.Log ("Event.deconstructor()");  
        //}  
    }
}
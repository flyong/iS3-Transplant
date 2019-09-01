using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iS3UnityLib.Model.ObjModel;
using System.ComponentModel;

namespace iS3UnityLib.Model.Event
{
    public class StorePathCarHouseInfoEvent : UnityEvent
    {
        /// <summary>  
        /// The Event Type Name  
        /// </summary>  
        public static UnityEventType MyEventType = UnityEventType.StorePathCarHouseInfoEvent;

        public List<PathCarHouseInfo> PathCarHousePosList { get; set; }

        /// <summary>  
        /// Initializes a new instance of the <see cref="com.rmc.projects.event_dispatcher.SampleEvent"/> class.  
        /// </summary>  
        /// <param name="aType_str">A type_str.</param>  
        public StorePathCarHouseInfoEvent(UnityEventType aEventType) : base(aEventType)
        {
        }
        public override void UnityAction()
        {


        }
    }

    public class PathCarHouseInfo : INotifyPropertyChanged
    {
        private string pathname;
        public string Pathname
        {

            get { return pathname; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pathname"));
                }
                pathname = value;
            }
        }
        private string carname;
        public string Carname
        {

            get { return carname; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Carname"));
                }
                carname = value;
            }
        }
        private string housename;
        public string Housename
        {

            get { return housename; }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Housename"));
                }
                housename = value;
            }
        }
        public Pos HousePos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}

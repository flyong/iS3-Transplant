using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public abstract class Segment
    {
        private List<Point> _points = new List<Point>();

        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public abstract void GetPoints(DigitalParam dp);
    }
}

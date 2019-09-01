using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    interface ISegment
    {
        List<Point> Points { get; set; }

        void GetPoints();
    }
}

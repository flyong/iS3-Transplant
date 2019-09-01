using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class DownColonSegment : Segment
    {
        public DownColonSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.DigitalWidth / 2, 3 * dp.DigitalHeight / 4 - dp.SegmentThickness / 4));
        }
    }
}

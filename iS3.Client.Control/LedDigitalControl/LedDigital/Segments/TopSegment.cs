using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class TopSegment : Segment
    {
        public TopSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.BevelWidth * 2 + dp.SegmentInterval, 0));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth * 2 - dp.SegmentInterval, 0));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth - dp.SegmentInterval, dp.BevelWidth));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentInterval - dp.SegmentThickness, dp.SegmentThickness));
            Points.Add(new Point(dp.SegmentThickness + dp.SegmentInterval, dp.SegmentThickness));
            Points.Add(new Point(dp.BevelWidth + dp.SegmentInterval, dp.BevelWidth));
        }
    }
}

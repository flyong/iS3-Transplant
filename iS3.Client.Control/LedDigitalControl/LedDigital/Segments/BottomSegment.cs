using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class BottomSegment : Segment
    {
        public BottomSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.SegmentThickness + dp.SegmentInterval, dp.DigitalHeight - dp.SegmentThickness));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness - dp.SegmentInterval, dp.DigitalHeight - dp.SegmentThickness));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth - dp.SegmentInterval, dp.DigitalHeight - dp.BevelWidth));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth * 2 - dp.SegmentInterval, dp.DigitalHeight));
            Points.Add(new Point(dp.BevelWidth * 2 + dp.SegmentInterval, dp.DigitalHeight));
            Points.Add(new Point(dp.BevelWidth + dp.SegmentInterval, dp.DigitalHeight - dp.BevelWidth));
        }
    }
}

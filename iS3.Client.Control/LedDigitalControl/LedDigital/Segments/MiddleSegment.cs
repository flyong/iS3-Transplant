using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class MiddleSegment : Segment
    {
        public MiddleSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.SegmentThickness + dp.SegmentInterval, dp.DigitalHeight / 2 - dp.SegmentThickness / 2));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness - dp.SegmentInterval, dp.DigitalHeight / 2 - dp.SegmentThickness / 2));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentInterval - dp.SegmentThickness / 2, dp.DigitalHeight / 2));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness - dp.SegmentInterval, dp.DigitalHeight / 2 + dp.SegmentThickness / 2));
            Points.Add(new Point(dp.SegmentThickness + dp.SegmentInterval, dp.DigitalHeight / 2 + dp.SegmentThickness / 2));
            Points.Add(new Point(dp.SegmentThickness / 2 + dp.SegmentInterval, dp.DigitalHeight / 2));
        }
    }
}

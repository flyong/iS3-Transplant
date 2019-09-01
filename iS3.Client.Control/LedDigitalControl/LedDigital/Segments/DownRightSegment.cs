using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class DownRightSegment : Segment
    {
        public DownRightSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.DigitalWidth, dp.DigitalHeight - dp.BevelWidth * 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth, dp.DigitalHeight / 2 + dp.SegmentInterval + dp.SegmentThickness / 2));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness / 2, dp.DigitalHeight / 2 + dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness, dp.DigitalHeight / 2 + dp.SegmentThickness / 2 + dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness, dp.DigitalHeight - dp.SegmentThickness - dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth, dp.DigitalHeight - dp.BevelWidth - dp.SegmentInterval));
        }
    }
}

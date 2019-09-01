using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class UpRightSegment : Segment
    {
        public UpRightSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(dp.DigitalWidth, dp.BevelWidth * 2 + dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth, dp.DigitalHeight / 2 - dp.SegmentThickness / 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness / 2, dp.DigitalHeight / 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness, dp.DigitalHeight / 2 - dp.SegmentThickness / 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.SegmentThickness, dp.SegmentThickness + dp.SegmentInterval));
            Points.Add(new Point(dp.DigitalWidth - dp.BevelWidth, dp.BevelWidth + dp.SegmentInterval));
        }
    }
}

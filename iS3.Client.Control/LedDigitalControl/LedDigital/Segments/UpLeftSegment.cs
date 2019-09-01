using iS3.Client.Controls.LedDigitalControl.LedDigital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace iS3.Client.Controls.LedDigitalControl.LedDigital.Segments
{
    public class UpLeftSegment : Segment
    {
        public UpLeftSegment(DigitalParam dp)
        {
            GetPoints(dp);
        }

        public override void GetPoints(DigitalParam dp)
        {
            Points.Add(new Point(0, dp.BevelWidth * 2 + dp.SegmentInterval));
            Points.Add(new Point(0, dp.DigitalHeight / 2 - dp.SegmentInterval - dp.SegmentThickness / 2));
            Points.Add(new Point(dp.SegmentThickness / 2, dp.DigitalHeight / 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.SegmentThickness, dp.DigitalHeight / 2 - dp.SegmentThickness / 2 - dp.SegmentInterval));
            Points.Add(new Point(dp.SegmentThickness, dp.SegmentThickness + dp.SegmentInterval));
            Points.Add(new Point(dp.BevelWidth, dp.BevelWidth + dp.SegmentInterval));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;

namespace iS3.Client.Controls.PromptableButtonControl
{
    internal class PromptChrome : Control
    {
        static PromptChrome()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PromptChrome), new FrameworkPropertyMetadata(typeof(PromptChrome)));
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {

            this.Width = 15;
            this.Height = 15;

            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            TranslateTransform tt = new TranslateTransform();
            tt.X =6;
            tt.Y = -6;
            this.RenderTransform = tt;

            return base.ArrangeOverride(arrangeBounds);
        }
    }
}

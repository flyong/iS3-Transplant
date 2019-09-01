using System.Windows;
using System.Windows.Controls;
namespace iS3.Client.Controls.MoveResizeFrame
{
    public class ResizeRotateChrome :System.Windows.Controls.Control
    {
        static ResizeRotateChrome()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeRotateChrome), new FrameworkPropertyMetadata(typeof(ResizeRotateChrome)));
        }
    }
}

#pragma checksum "..\..\TunnelFace.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "012FD78D3F6998F989D177F87F341CCD"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using iS3.Client.Controls;


namespace iS3.Client.Controls
{


    /// <summary>
    /// RiskAssessment
    /// </summary>
    public partial class RiskAssessment : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 17 "..\..\TunnelFace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid container;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/iS3.Client.Controls;component/tunnelface.xaml", System.UriKind.Relative);

#line 1 "..\..\TunnelFace.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.container = ((System.Windows.Controls.Grid)(target));
                    return;
                case 2:
                    this.sect1 = ((System.Windows.Controls.ComboBox)(target));

#line 21 "..\..\TunnelFace.xaml"
                    this.sect1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);

#line default
#line hidden
                    return;
                case 3:
                    this.mileage = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.grade = ((System.Windows.Controls.Label)(target));
                    return;
                case 5:
                    this.advice = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.g1 = ((System.Windows.Controls.Label)(target));
                    return;
                case 7:
                    this.g2 = ((System.Windows.Controls.Label)(target));
                    return;
                case 8:
                    this.g3 = ((System.Windows.Controls.Label)(target));
                    return;
                case 9:
                    this.g4 = ((System.Windows.Controls.Label)(target));
                    return;
                case 10:
                    this.g5 = ((System.Windows.Controls.Label)(target));
                    return;
                case 11:
                    this.g6 = ((System.Windows.Controls.Label)(target));
                    return;
                case 12:
                    this.g7 = ((System.Windows.Controls.Label)(target));
                    return;
                case 13:
                    this.g8 = ((System.Windows.Controls.Label)(target));
                    return;
                case 14:
                    this.g9 = ((System.Windows.Controls.Label)(target));
                    return;
                case 15:
                    this.g10 = ((System.Windows.Controls.Label)(target));
                    return;
                case 16:

#line 52 "..\..\TunnelFace.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.start);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}


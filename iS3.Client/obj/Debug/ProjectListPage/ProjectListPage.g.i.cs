﻿#pragma checksum "..\..\..\ProjectListPage\ProjectListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14A188A17F4B33ED759E18AEABEDAC792AF1C5E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Symbology;
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
using iS3.Client;
using iS3.Client.Controls.LedDigitalControl.LedDigital;
using iS3.Client.Controls.PromptableButtonControl;


namespace iS3.Client {
    
    
    /// <summary>
    /// ProjectListPage
    /// </summary>
    public partial class ProjectListPageForMon : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 58 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Esri.ArcGISRuntime.Controls.MapView MyMapView;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Esri.ArcGISRuntime.Controls.Map Map;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Esri.ArcGISRuntime.Layers.GraphicsLayer ProjectGraphicsLayer;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border mapTip;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ledHolder;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal iS3.Client.Controls.LedDigitalControl.LedDigital.DigitalPanelControl ledTest1;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserTB;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal iS3.Client.Controls.PromptableButtonControl.PromptableButton RemindBtn;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal iS3.Client.Controls.PromptableButtonControl.PromptableButton MessageBtn;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SignoutTB;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listBtn;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addProjectBtn;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox projectListLB;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ProjectDetailHolder;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\ProjectListPage\ProjectListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DetailView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/iS3.Client;component/projectlistpage/projectlistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ProjectListPage\ProjectListPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.MyMapView = ((Esri.ArcGISRuntime.Controls.MapView)(target));
            return;
            case 3:
            this.Map = ((Esri.ArcGISRuntime.Controls.Map)(target));
            return;
            case 4:
            this.ProjectGraphicsLayer = ((Esri.ArcGISRuntime.Layers.GraphicsLayer)(target));
            return;
            case 5:
            this.mapTip = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.ledHolder = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.ledTest1 = ((iS3.Client.Controls.LedDigitalControl.LedDigital.DigitalPanelControl)(target));
            return;
            case 8:
            this.UserTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.RemindBtn = ((iS3.Client.Controls.PromptableButtonControl.PromptableButton)(target));
            return;
            case 10:
            this.MessageBtn = ((iS3.Client.Controls.PromptableButtonControl.PromptableButton)(target));
            return;
            case 11:
            this.SignoutTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.listBtn = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            this.listBtn.Click += new System.Windows.RoutedEventHandler(this.listBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.addProjectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            this.addProjectBtn.Click += new System.Windows.RoutedEventHandler(this.addProjectBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.projectListLB = ((System.Windows.Controls.ListBox)(target));
            
            #line 181 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            this.projectListLB.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.projectListLB_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 17:
            this.ProjectDetailHolder = ((System.Windows.Controls.Border)(target));
            return;
            case 18:
            this.DetailView = ((System.Windows.Controls.Button)(target));
            
            #line 233 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            this.DetailView.Click += new System.Windows.RoutedEventHandler(this.DetailView_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 15:
            
            #line 186 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditorBtn_Click);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 187 "..\..\..\ProjectListPage\ProjectListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


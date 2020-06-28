﻿#pragma checksum "..\..\..\UserControls\NewOrderPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B7F0E0BE62EE90292CCEE1E97D9BFEE25FE151412D040BE59779532CCD532429"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Blueberry.WPF.UserControls;
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


namespace Blueberry.WPF.UserControls {
    
    
    /// <summary>
    /// NewOrderPanel
    /// </summary>
    public partial class NewOrderPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Customers;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PriorityComboBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar InCalendar;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar OutCalendar;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\UserControls\NewOrderPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Info;
        
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
            System.Uri resourceLocater = new System.Uri("/Blueberry.WPF;component/usercontrols/neworderpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\NewOrderPanel.xaml"
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
            
            #line 9 "..\..\..\UserControls\NewOrderPanel.xaml"
            ((Blueberry.WPF.UserControls.NewOrderPanel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.NewOrderPanel_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Customers = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Amount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PriorityComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.InCalendar = ((System.Windows.Controls.Calendar)(target));
            return;
            case 6:
            this.OutCalendar = ((System.Windows.Controls.Calendar)(target));
            return;
            case 7:
            
            #line 81 "..\..\..\UserControls\NewOrderPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitOnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 83 "..\..\..\UserControls\NewOrderPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DismissOnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Info = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


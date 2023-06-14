﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D7C53538824DC546202A40A5340A96D4C8DAD05"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCGroupKennis;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace HCGroupKennis {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MainGroupComboBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetMainGroupFilter;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SubGroupComboBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetSubGroupFilter;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YearTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CvDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HCGroupKennis;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainGroupComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\..\MainWindow.xaml"
            this.MainGroupComboBox.DropDownClosed += new System.EventHandler(this.GroupsFilter_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ResetMainGroupFilter = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.ResetMainGroupFilter.Click += new System.Windows.RoutedEventHandler(this.ResetMainGroupFilter_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SubGroupComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\MainWindow.xaml"
            this.SubGroupComboBox.DropDownClosed += new System.EventHandler(this.GroupsFilter_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ResetSubGroupFilter = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.ResetSubGroupFilter.Click += new System.Windows.RoutedEventHandler(this.ResetSubGroupFilter_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.YearTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.YearTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.YearTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.YearTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.YearTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.YearTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.YearFilter_OnTextChanged);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.YearTextBox.AddHandler(System.Windows.Input.CommandManager.PreviewCanExecuteEvent, new System.Windows.Input.CanExecuteRoutedEventHandler(this.HandleCanExecute));
            
            #line default
            #line hidden
            return;
            case 6:
            this.CvDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


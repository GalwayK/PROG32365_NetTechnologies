﻿#pragma checksum "..\..\..\..\AddWindows\AddCountryWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06A8A34CFFB18FD01F3581726E733BE08006DCBE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using A3KyleGalway;
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


namespace A3KyleGalway {
    
    
    /// <summary>
    /// AddCountryWindow
    /// </summary>
    public partial class AddCountryWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStatus;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox listAddCountryContinent;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddCountryName;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddCountryLanguage;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAddCountryCurrency;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddCountry;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseWindow;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/A3KyleGalway;component/addwindows/addcountrywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
            ((A3KyleGalway.AddCountryWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.IntializeControls);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.listAddCountryContinent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtAddCountryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtAddCountryLanguage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtAddCountryCurrency = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAddCountry = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
            this.btnAddCountry.Click += new System.Windows.RoutedEventHandler(this.AddCountry);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCloseWindow = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\AddWindows\AddCountryWindow.xaml"
            this.btnCloseWindow.Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


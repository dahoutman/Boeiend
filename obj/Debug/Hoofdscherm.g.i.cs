﻿#pragma checksum "..\..\Hoofdscherm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3FE84E40288032DD256B158A1FB95359"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Boeiend;
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


namespace Boeiend {
    
    
    /// <summary>
    /// Hoofdscherm
    /// </summary>
    public partial class Hoofdscherm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\Hoofdscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tcTabs;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Hoofdscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Boeiend.Markeringsscherm Markeringsscherm;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Hoofdscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Boeiend.Instellingenscherm Instellingenscherm;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Hoofdscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tiLoggingscherm;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Hoofdscherm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Boeiend.Loggingscherm Loggingscherm;
        
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
            System.Uri resourceLocater = new System.Uri("/Boeiend;component/hoofdscherm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Hoofdscherm.xaml"
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
            
            #line 23 "..\..\Hoofdscherm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miOpenClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 32 "..\..\Hoofdscherm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miImportClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 35 "..\..\Hoofdscherm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miExportClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 41 "..\..\Hoofdscherm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miExitClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 54 "..\..\Hoofdscherm.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miAboutClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tcTabs = ((System.Windows.Controls.TabControl)(target));
            return;
            case 7:
            this.Markeringsscherm = ((Boeiend.Markeringsscherm)(target));
            return;
            case 8:
            this.Instellingenscherm = ((Boeiend.Instellingenscherm)(target));
            return;
            case 9:
            this.tiLoggingscherm = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.Loggingscherm = ((Boeiend.Loggingscherm)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "D:\Workspace\bacain\baru\BacaIN\BacaIN\UserControls\Loader.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2AC9B30820375AE033C2303A84552205"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace BacaIN.UserControls {
    
    
    public partial class Loader : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.UserControl phonePage;
        
        internal System.Windows.Media.Animation.Storyboard LoaderAnimation;
        
        internal System.Windows.Controls.Viewbox LayoutRoot;
        
        internal System.Windows.Controls.Canvas canvas;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/BacaIN;component/UserControls/Loader.xaml", System.UriKind.Relative));
            this.phonePage = ((System.Windows.Controls.UserControl)(this.FindName("phonePage")));
            this.LoaderAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("LoaderAnimation")));
            this.LayoutRoot = ((System.Windows.Controls.Viewbox)(this.FindName("LayoutRoot")));
            this.canvas = ((System.Windows.Controls.Canvas)(this.FindName("canvas")));
        }
    }
}


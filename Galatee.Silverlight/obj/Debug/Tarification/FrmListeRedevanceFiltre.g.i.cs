﻿#pragma checksum "D:\TFS_SOURCE_EDM\iWEBS_EDMSA\Galatee.Silverlight\Tarification\FrmListeRedevanceFiltre.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0E862D062757841AA3ECBBD44D6E2EEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace Galatee.Silverlight.Tarification {
    
    
    public partial class FrmListeRedevanceFiltre : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button NewButton;
        
        internal System.Windows.Controls.Button ViewButton;
        
        internal System.Windows.Controls.Button UpdateButton;
        
        internal System.Windows.Controls.DataGrid dgListeRedevence;
        
        internal System.Windows.Controls.DataPager datapager;
        
        internal System.Windows.Controls.Button DeleteButton;
        
        internal System.Windows.Controls.ComboBox cbo_produit;
        
        internal System.Windows.Controls.ComboBox cbo_redevence;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Tarification/FrmListeRedevanceFiltre.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.NewButton = ((System.Windows.Controls.Button)(this.FindName("NewButton")));
            this.ViewButton = ((System.Windows.Controls.Button)(this.FindName("ViewButton")));
            this.UpdateButton = ((System.Windows.Controls.Button)(this.FindName("UpdateButton")));
            this.dgListeRedevence = ((System.Windows.Controls.DataGrid)(this.FindName("dgListeRedevence")));
            this.datapager = ((System.Windows.Controls.DataPager)(this.FindName("datapager")));
            this.DeleteButton = ((System.Windows.Controls.Button)(this.FindName("DeleteButton")));
            this.cbo_produit = ((System.Windows.Controls.ComboBox)(this.FindName("cbo_produit")));
            this.cbo_redevence = ((System.Windows.Controls.ComboBox)(this.FindName("cbo_redevence")));
        }
    }
}


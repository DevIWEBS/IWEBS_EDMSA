﻿#pragma checksum "D:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Caisse\frmEtatCaisse.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8C7A7DF8C4CE9DF0E8C8BFCA1931ED00"
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


namespace Galatee.Silverlight.Caisse {
    
    
    public partial class frmEtatCaisse : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Label lbl_numCaisse;
        
        internal System.Windows.Controls.DataGrid dtg_EtatCaisse;
        
        internal System.Windows.Controls.TextBox Txt_NumCaissiere;
        
        internal System.Windows.Controls.Label lbl_numCaisse_Copy;
        
        internal System.Windows.Controls.TextBox Txt_TotalEnCaise;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Caisse/frmEtatCaisse.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.lbl_numCaisse = ((System.Windows.Controls.Label)(this.FindName("lbl_numCaisse")));
            this.dtg_EtatCaisse = ((System.Windows.Controls.DataGrid)(this.FindName("dtg_EtatCaisse")));
            this.Txt_NumCaissiere = ((System.Windows.Controls.TextBox)(this.FindName("Txt_NumCaissiere")));
            this.lbl_numCaisse_Copy = ((System.Windows.Controls.Label)(this.FindName("lbl_numCaisse_Copy")));
            this.Txt_TotalEnCaise = ((System.Windows.Controls.TextBox)(this.FindName("Txt_TotalEnCaise")));
        }
    }
}


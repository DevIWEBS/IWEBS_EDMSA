﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Caisse\FrmValidationDemandeAnnulation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "294F90ABF04B8CF85ECF0CFFA4CD4685"
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
    
    
    public partial class FrmValidationDemandeAnnulation : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Label lbl_Recu;
        
        internal System.Windows.Controls.Button btn_Rechercher;
        
        internal System.Windows.Controls.TextBox txt_Caissiere;
        
        internal System.Windows.Controls.DataGrid dtg_FactureAnnule;
        
        internal System.Windows.Controls.DataGrid dtg_FactureDetail;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Caisse/FrmValidationDemandeAnnulation.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.lbl_Recu = ((System.Windows.Controls.Label)(this.FindName("lbl_Recu")));
            this.btn_Rechercher = ((System.Windows.Controls.Button)(this.FindName("btn_Rechercher")));
            this.txt_Caissiere = ((System.Windows.Controls.TextBox)(this.FindName("txt_Caissiere")));
            this.dtg_FactureAnnule = ((System.Windows.Controls.DataGrid)(this.FindName("dtg_FactureAnnule")));
            this.dtg_FactureDetail = ((System.Windows.Controls.DataGrid)(this.FindName("dtg_FactureDetail")));
        }
    }
}


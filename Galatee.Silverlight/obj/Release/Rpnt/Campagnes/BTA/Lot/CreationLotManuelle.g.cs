﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Rpnt\Campagnes\BTA\Lot\CreationLotManuelle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "512FBD4BA4DF4C1038EDF16EF0A5DFE7"
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


namespace Galatee.Silverlight.Recouvrement {
    
    
    public partial class CreationLotManuelle : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.TextBox tbx_lib_lot;
        
        internal System.Windows.Controls.TextBox tbx_date_creat_lot;
        
        internal System.Windows.Controls.TextBox tbx_libele_Camp;
        
        internal System.Windows.Controls.TextBox tbx_statu;
        
        internal System.Windows.Controls.TextBox tbx_createur;
        
        internal System.Windows.Controls.DataGrid dg_pop_non_affecte;
        
        internal System.Windows.Controls.DataGrid dg_population_lot;
        
        internal System.Windows.Controls.ComboBox cbxtypeclient;
        
        internal System.Windows.Controls.ComboBox cbxtarif;
        
        internal System.Windows.Controls.ComboBox cbxcompteur;
        
        internal System.Windows.Controls.ComboBox cbxgropfacture;
        
        internal System.Windows.Controls.ComboBox cbxtournee;
        
        internal System.Windows.Controls.Button btn_load_brt_in_lot;
        
        internal System.Windows.Controls.Button btn_AgtRecepteur;
        
        internal System.Windows.Controls.TextBox txtAgt_Recepteur;
        
        internal System.Windows.Controls.TextBox txt_LibelleAgentRecepteur;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Rpnt/Campagnes/BTA/Lot/CreationLotManuelle.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.tbx_lib_lot = ((System.Windows.Controls.TextBox)(this.FindName("tbx_lib_lot")));
            this.tbx_date_creat_lot = ((System.Windows.Controls.TextBox)(this.FindName("tbx_date_creat_lot")));
            this.tbx_libele_Camp = ((System.Windows.Controls.TextBox)(this.FindName("tbx_libele_Camp")));
            this.tbx_statu = ((System.Windows.Controls.TextBox)(this.FindName("tbx_statu")));
            this.tbx_createur = ((System.Windows.Controls.TextBox)(this.FindName("tbx_createur")));
            this.dg_pop_non_affecte = ((System.Windows.Controls.DataGrid)(this.FindName("dg_pop_non_affecte")));
            this.dg_population_lot = ((System.Windows.Controls.DataGrid)(this.FindName("dg_population_lot")));
            this.cbxtypeclient = ((System.Windows.Controls.ComboBox)(this.FindName("cbxtypeclient")));
            this.cbxtarif = ((System.Windows.Controls.ComboBox)(this.FindName("cbxtarif")));
            this.cbxcompteur = ((System.Windows.Controls.ComboBox)(this.FindName("cbxcompteur")));
            this.cbxgropfacture = ((System.Windows.Controls.ComboBox)(this.FindName("cbxgropfacture")));
            this.cbxtournee = ((System.Windows.Controls.ComboBox)(this.FindName("cbxtournee")));
            this.btn_load_brt_in_lot = ((System.Windows.Controls.Button)(this.FindName("btn_load_brt_in_lot")));
            this.btn_AgtRecepteur = ((System.Windows.Controls.Button)(this.FindName("btn_AgtRecepteur")));
            this.txtAgt_Recepteur = ((System.Windows.Controls.TextBox)(this.FindName("txtAgt_Recepteur")));
            this.txt_LibelleAgentRecepteur = ((System.Windows.Controls.TextBox)(this.FindName("txt_LibelleAgentRecepteur")));
        }
    }
}


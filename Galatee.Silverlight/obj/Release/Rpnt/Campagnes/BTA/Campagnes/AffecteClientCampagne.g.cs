﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Rpnt\Campagnes\BTA\Campagnes\AffecteClientCampagne.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B226EB64801108D4E5EB17A3DC3A0829"
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
    
    
    public partial class AffecteClientCampagne : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ComboBox cbxmethrech;
        
        internal System.Windows.Controls.Label lblmethrech;
        
        internal System.Windows.Controls.DataGrid dgparam;
        
        internal System.Windows.Controls.ComboBox cbxtypeclient;
        
        internal System.Windows.Controls.ComboBox cbxcompteur;
        
        internal System.Windows.Controls.ComboBox cbxtarif;
        
        internal System.Windows.Controls.ComboBox cbxagetzone;
        
        internal System.Windows.Controls.Label lbl_Periode;
        
        internal System.Windows.Controls.Button bntLoadClient;
        
        internal System.Windows.Controls.DataGrid dgclientselectionne;
        
        internal System.Windows.Controls.DataGrid dgClientEligible;
        
        internal System.Windows.Controls.Button Decharger;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button OKButton;
        
        internal System.Windows.Controls.Label label3;
        
        internal System.Windows.Controls.TextBox txtCentre;
        
        internal System.Windows.Controls.ComboBox Cbo_Centre;
        
        internal System.Windows.Controls.TextBox txt_Periode;
        
        internal System.Windows.Controls.Label lbl_comparaison_periode1;
        
        internal System.Windows.Controls.TextBox txt_comparaison_periode1;
        
        internal System.Windows.Controls.Label lbl_comparaison_periode2;
        
        internal System.Windows.Controls.TextBox txt_comparaison_periode2;
        
        internal System.Windows.Controls.Label lbl_Cas;
        
        internal System.Windows.Controls.TextBox txt_Code_Cas;
        
        internal System.Windows.Controls.Label lbl_Nombre_Recurence;
        
        internal System.Windows.Controls.NumericUpDown NumUpD_Nombre_Recurence;
        
        internal System.Windows.Controls.ComboBox cbxcas;
        
        internal System.Windows.Controls.NumericUpDown NumUpD_Pourcentatge;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Rpnt/Campagnes/BTA/Campagnes/AffecteClientCampagne" +
                        ".xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.cbxmethrech = ((System.Windows.Controls.ComboBox)(this.FindName("cbxmethrech")));
            this.lblmethrech = ((System.Windows.Controls.Label)(this.FindName("lblmethrech")));
            this.dgparam = ((System.Windows.Controls.DataGrid)(this.FindName("dgparam")));
            this.cbxtypeclient = ((System.Windows.Controls.ComboBox)(this.FindName("cbxtypeclient")));
            this.cbxcompteur = ((System.Windows.Controls.ComboBox)(this.FindName("cbxcompteur")));
            this.cbxtarif = ((System.Windows.Controls.ComboBox)(this.FindName("cbxtarif")));
            this.cbxagetzone = ((System.Windows.Controls.ComboBox)(this.FindName("cbxagetzone")));
            this.lbl_Periode = ((System.Windows.Controls.Label)(this.FindName("lbl_Periode")));
            this.bntLoadClient = ((System.Windows.Controls.Button)(this.FindName("bntLoadClient")));
            this.dgclientselectionne = ((System.Windows.Controls.DataGrid)(this.FindName("dgclientselectionne")));
            this.dgClientEligible = ((System.Windows.Controls.DataGrid)(this.FindName("dgClientEligible")));
            this.Decharger = ((System.Windows.Controls.Button)(this.FindName("Decharger")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
            this.label3 = ((System.Windows.Controls.Label)(this.FindName("label3")));
            this.txtCentre = ((System.Windows.Controls.TextBox)(this.FindName("txtCentre")));
            this.Cbo_Centre = ((System.Windows.Controls.ComboBox)(this.FindName("Cbo_Centre")));
            this.txt_Periode = ((System.Windows.Controls.TextBox)(this.FindName("txt_Periode")));
            this.lbl_comparaison_periode1 = ((System.Windows.Controls.Label)(this.FindName("lbl_comparaison_periode1")));
            this.txt_comparaison_periode1 = ((System.Windows.Controls.TextBox)(this.FindName("txt_comparaison_periode1")));
            this.lbl_comparaison_periode2 = ((System.Windows.Controls.Label)(this.FindName("lbl_comparaison_periode2")));
            this.txt_comparaison_periode2 = ((System.Windows.Controls.TextBox)(this.FindName("txt_comparaison_periode2")));
            this.lbl_Cas = ((System.Windows.Controls.Label)(this.FindName("lbl_Cas")));
            this.txt_Code_Cas = ((System.Windows.Controls.TextBox)(this.FindName("txt_Code_Cas")));
            this.lbl_Nombre_Recurence = ((System.Windows.Controls.Label)(this.FindName("lbl_Nombre_Recurence")));
            this.NumUpD_Nombre_Recurence = ((System.Windows.Controls.NumericUpDown)(this.FindName("NumUpD_Nombre_Recurence")));
            this.cbxcas = ((System.Windows.Controls.ComboBox)(this.FindName("cbxcas")));
            this.NumUpD_Pourcentatge = ((System.Windows.Controls.NumericUpDown)(this.FindName("NumUpD_Pourcentatge")));
        }
    }
}


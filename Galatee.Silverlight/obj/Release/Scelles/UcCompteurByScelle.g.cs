﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Scelles\UcCompteurByScelle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F3B2FC2974D52841C78F123A510C2139"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SilverlightContrib.Controls;
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


namespace Galatee.Silverlight.Scelles {
    
    
    public partial class UcCompteurByScelle : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal SilverlightContrib.Controls.GroupBox Gbo_InformationDevis;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Label labe_Num;
        
        internal System.Windows.Controls.TextBox txt_NumCpteur;
        
        internal System.Windows.Controls.DataGrid dtg_CompteurSaisie;
        
        internal System.Windows.Controls.Button btn_Modifier;
        
        internal System.Windows.Controls.RadioButton Rdb_NumCompt;
        
        internal System.Windows.Controls.RadioButton Rdb_NumScelle;
        
        internal System.Windows.Controls.Button btn_Recherche;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Scelles/UcCompteurByScelle.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Gbo_InformationDevis = ((SilverlightContrib.Controls.GroupBox)(this.FindName("Gbo_InformationDevis")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.labe_Num = ((System.Windows.Controls.Label)(this.FindName("labe_Num")));
            this.txt_NumCpteur = ((System.Windows.Controls.TextBox)(this.FindName("txt_NumCpteur")));
            this.dtg_CompteurSaisie = ((System.Windows.Controls.DataGrid)(this.FindName("dtg_CompteurSaisie")));
            this.btn_Modifier = ((System.Windows.Controls.Button)(this.FindName("btn_Modifier")));
            this.Rdb_NumCompt = ((System.Windows.Controls.RadioButton)(this.FindName("Rdb_NumCompt")));
            this.Rdb_NumScelle = ((System.Windows.Controls.RadioButton)(this.FindName("Rdb_NumScelle")));
            this.btn_Recherche = ((System.Windows.Controls.Button)(this.FindName("btn_Recherche")));
        }
    }
}


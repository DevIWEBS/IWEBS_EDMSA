﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Caisse\FrmDemandeTimbreVerification.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F9F39D464B651D180EC2C6482AEE8193"
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


namespace Galatee.Silverlight.Caisse {
    
    
    public partial class FrmDemandeTimbreVerification : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox Txt_NumDemande;
        
        internal System.Windows.Controls.TextBox Txt_UserCreat;
        
        internal System.Windows.Controls.DataGrid dtg_EtatCaisse;
        
        internal SilverlightContrib.Controls.GroupBox groupBox1_Copy1;
        
        internal SilverlightContrib.Controls.GroupBox Gbo_PieceJointe;
        
        internal System.Windows.Controls.DataGrid dgListePiece;
        
        internal System.Windows.Controls.Button btn_ajoutpiece;
        
        internal System.Windows.Controls.Button btn_supprimerpiece;
        
        internal System.Windows.Controls.ComboBox cbo_typedoc;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Caisse/FrmDemandeTimbreVerification.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Txt_NumDemande = ((System.Windows.Controls.TextBox)(this.FindName("Txt_NumDemande")));
            this.Txt_UserCreat = ((System.Windows.Controls.TextBox)(this.FindName("Txt_UserCreat")));
            this.dtg_EtatCaisse = ((System.Windows.Controls.DataGrid)(this.FindName("dtg_EtatCaisse")));
            this.groupBox1_Copy1 = ((SilverlightContrib.Controls.GroupBox)(this.FindName("groupBox1_Copy1")));
            this.Gbo_PieceJointe = ((SilverlightContrib.Controls.GroupBox)(this.FindName("Gbo_PieceJointe")));
            this.dgListePiece = ((System.Windows.Controls.DataGrid)(this.FindName("dgListePiece")));
            this.btn_ajoutpiece = ((System.Windows.Controls.Button)(this.FindName("btn_ajoutpiece")));
            this.btn_supprimerpiece = ((System.Windows.Controls.Button)(this.FindName("btn_supprimerpiece")));
            this.cbo_typedoc = ((System.Windows.Controls.ComboBox)(this.FindName("cbo_typedoc")));
        }
    }
}


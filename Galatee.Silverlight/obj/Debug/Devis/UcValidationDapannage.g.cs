﻿#pragma checksum "D:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Devis\UcValidationDapannage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ED07E9E800114A5FF347964707A809C0"
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


namespace Galatee.Silverlight.Devis {
    
    
    public partial class UcValidationDapannage : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.TabControl tabControl_Consultation;
        
        internal System.Windows.Controls.TabItem tabItemDevis;
        
        internal SilverlightContrib.Controls.GroupBox Gbo_InformationDevis;
        
        internal System.Windows.Controls.TextBox Txt_NumeroDevis;
        
        internal System.Windows.Controls.Label lbl_Devis;
        
        internal System.Windows.Controls.TextBox Txt_Ordre;
        
        internal System.Windows.Controls.TextBox Txt_CodeSite;
        
        internal System.Windows.Controls.Label lbl_Site;
        
        internal System.Windows.Controls.TextBox Txt_LibelleSite;
        
        internal System.Windows.Controls.TextBox Txt_CodeCentre;
        
        internal System.Windows.Controls.Label lbl_Centre;
        
        internal System.Windows.Controls.TextBox Txt_LibelleCentre;
        
        internal System.Windows.Controls.TextBox Txt_LibelleTypeDevis;
        
        internal System.Windows.Controls.TextBox Txt_EtapeCourante;
        
        internal System.Windows.Controls.TextBox Txt_EtapeSuivante;
        
        internal System.Windows.Controls.Label lbl_TypeDevis;
        
        internal System.Windows.Controls.Label lbl_EtapeEnCours;
        
        internal System.Windows.Controls.Label lbl_EtapeSuivante;
        
        internal System.Windows.Controls.TextBox Txt_Commune;
        
        internal System.Windows.Controls.Label lbl_Devis_Copy;
        
        internal System.Windows.Controls.TextBox Txt_Quartier;
        
        internal System.Windows.Controls.Label lbl_Devis_Copy1;
        
        internal System.Windows.Controls.TextBox Txt_Secteur;
        
        internal System.Windows.Controls.Label lbl_Devis_Copy2;
        
        internal System.Windows.Controls.TextBox Txt_Rue;
        
        internal System.Windows.Controls.Label lbl_Devis_Copy3;
        
        internal System.Windows.Controls.Label lbl_Etage_Copy1;
        
        internal System.Windows.Controls.Label label15_Copy1;
        
        internal System.Windows.Controls.TextBox txt_TypePanne;
        
        internal System.Windows.Controls.TextBox Txt_Commentaire;
        
        internal System.Windows.Controls.Label lbl_Devis_Copy4;
        
        internal System.Windows.Controls.Label label15_Copy;
        
        internal System.Windows.Controls.TextBox txt_TypePanneTraite;
        
        internal System.Windows.Controls.TextBox Txt_Commentaire1;
        
        internal System.Windows.Controls.TabItem tabItemFournitures;
        
        internal System.Windows.Controls.DataGrid dataGridForniture;
        
        internal System.Windows.Controls.Label lbl_TotalHT;
        
        internal System.Windows.Controls.TextBox Txt_TotalHt;
        
        internal System.Windows.Controls.Label lbl_TotalTTC;
        
        internal System.Windows.Controls.TextBox Txt_TotalTtc;
        
        internal System.Windows.Controls.Label lbl_TotalTVA;
        
        internal System.Windows.Controls.TextBox Txt_TotalTva;
        
        internal System.Windows.Controls.Button btn_transmetre;
        
        internal System.Windows.Controls.Button RejeterButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Devis/UcValidationDapannage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.tabControl_Consultation = ((System.Windows.Controls.TabControl)(this.FindName("tabControl_Consultation")));
            this.tabItemDevis = ((System.Windows.Controls.TabItem)(this.FindName("tabItemDevis")));
            this.Gbo_InformationDevis = ((SilverlightContrib.Controls.GroupBox)(this.FindName("Gbo_InformationDevis")));
            this.Txt_NumeroDevis = ((System.Windows.Controls.TextBox)(this.FindName("Txt_NumeroDevis")));
            this.lbl_Devis = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis")));
            this.Txt_Ordre = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Ordre")));
            this.Txt_CodeSite = ((System.Windows.Controls.TextBox)(this.FindName("Txt_CodeSite")));
            this.lbl_Site = ((System.Windows.Controls.Label)(this.FindName("lbl_Site")));
            this.Txt_LibelleSite = ((System.Windows.Controls.TextBox)(this.FindName("Txt_LibelleSite")));
            this.Txt_CodeCentre = ((System.Windows.Controls.TextBox)(this.FindName("Txt_CodeCentre")));
            this.lbl_Centre = ((System.Windows.Controls.Label)(this.FindName("lbl_Centre")));
            this.Txt_LibelleCentre = ((System.Windows.Controls.TextBox)(this.FindName("Txt_LibelleCentre")));
            this.Txt_LibelleTypeDevis = ((System.Windows.Controls.TextBox)(this.FindName("Txt_LibelleTypeDevis")));
            this.Txt_EtapeCourante = ((System.Windows.Controls.TextBox)(this.FindName("Txt_EtapeCourante")));
            this.Txt_EtapeSuivante = ((System.Windows.Controls.TextBox)(this.FindName("Txt_EtapeSuivante")));
            this.lbl_TypeDevis = ((System.Windows.Controls.Label)(this.FindName("lbl_TypeDevis")));
            this.lbl_EtapeEnCours = ((System.Windows.Controls.Label)(this.FindName("lbl_EtapeEnCours")));
            this.lbl_EtapeSuivante = ((System.Windows.Controls.Label)(this.FindName("lbl_EtapeSuivante")));
            this.Txt_Commune = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Commune")));
            this.lbl_Devis_Copy = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis_Copy")));
            this.Txt_Quartier = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Quartier")));
            this.lbl_Devis_Copy1 = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis_Copy1")));
            this.Txt_Secteur = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Secteur")));
            this.lbl_Devis_Copy2 = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis_Copy2")));
            this.Txt_Rue = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Rue")));
            this.lbl_Devis_Copy3 = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis_Copy3")));
            this.lbl_Etage_Copy1 = ((System.Windows.Controls.Label)(this.FindName("lbl_Etage_Copy1")));
            this.label15_Copy1 = ((System.Windows.Controls.Label)(this.FindName("label15_Copy1")));
            this.txt_TypePanne = ((System.Windows.Controls.TextBox)(this.FindName("txt_TypePanne")));
            this.Txt_Commentaire = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Commentaire")));
            this.lbl_Devis_Copy4 = ((System.Windows.Controls.Label)(this.FindName("lbl_Devis_Copy4")));
            this.label15_Copy = ((System.Windows.Controls.Label)(this.FindName("label15_Copy")));
            this.txt_TypePanneTraite = ((System.Windows.Controls.TextBox)(this.FindName("txt_TypePanneTraite")));
            this.Txt_Commentaire1 = ((System.Windows.Controls.TextBox)(this.FindName("Txt_Commentaire1")));
            this.tabItemFournitures = ((System.Windows.Controls.TabItem)(this.FindName("tabItemFournitures")));
            this.dataGridForniture = ((System.Windows.Controls.DataGrid)(this.FindName("dataGridForniture")));
            this.lbl_TotalHT = ((System.Windows.Controls.Label)(this.FindName("lbl_TotalHT")));
            this.Txt_TotalHt = ((System.Windows.Controls.TextBox)(this.FindName("Txt_TotalHt")));
            this.lbl_TotalTTC = ((System.Windows.Controls.Label)(this.FindName("lbl_TotalTTC")));
            this.Txt_TotalTtc = ((System.Windows.Controls.TextBox)(this.FindName("Txt_TotalTtc")));
            this.lbl_TotalTVA = ((System.Windows.Controls.Label)(this.FindName("lbl_TotalTVA")));
            this.Txt_TotalTva = ((System.Windows.Controls.TextBox)(this.FindName("Txt_TotalTva")));
            this.btn_transmetre = ((System.Windows.Controls.Button)(this.FindName("btn_transmetre")));
            this.RejeterButton = ((System.Windows.Controls.Button)(this.FindName("RejeterButton")));
        }
    }
}


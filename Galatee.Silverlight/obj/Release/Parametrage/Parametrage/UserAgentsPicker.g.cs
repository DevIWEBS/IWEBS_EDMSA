﻿#pragma checksum "E:\EDEN\EDMSA\iWEBS_EDMSA\Galatee.Silverlight\Parametrage\Parametrage\UserAgentsPicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CAE7BC346A788694514391E3BA8564C"
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


namespace Galatee.Silverlight.Parametrage {
    
    
    public partial class UserAgentsPicker : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button BtnCancel;
        
        internal System.Windows.Controls.Button BtnOK;
        
        internal System.Windows.Controls.Label Lab_Matricule;
        
        internal System.Windows.Controls.TextBox Txt_matricule;
        
        internal System.Windows.Controls.Label label2;
        
        internal System.Windows.Controls.TextBox Txt_name;
        
        internal System.Windows.Controls.Label label3;
        
        internal System.Windows.Controls.TextBox Txt_codeFonction;
        
        internal System.Windows.Controls.ComboBox Cbo_Fonction;
        
        internal System.Windows.Controls.Button Btn_search;
        
        internal System.Windows.Controls.Button Btn_reset;
        
        internal System.Windows.Controls.DataGrid Dtg_agent;
        
        internal System.Windows.Controls.BusyIndicator busyIndicator;
        
        internal System.Windows.Controls.CheckBox chkEnConsultation;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Galatee.Silverlight;component/Parametrage/Parametrage/UserAgentsPicker.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.BtnCancel = ((System.Windows.Controls.Button)(this.FindName("BtnCancel")));
            this.BtnOK = ((System.Windows.Controls.Button)(this.FindName("BtnOK")));
            this.Lab_Matricule = ((System.Windows.Controls.Label)(this.FindName("Lab_Matricule")));
            this.Txt_matricule = ((System.Windows.Controls.TextBox)(this.FindName("Txt_matricule")));
            this.label2 = ((System.Windows.Controls.Label)(this.FindName("label2")));
            this.Txt_name = ((System.Windows.Controls.TextBox)(this.FindName("Txt_name")));
            this.label3 = ((System.Windows.Controls.Label)(this.FindName("label3")));
            this.Txt_codeFonction = ((System.Windows.Controls.TextBox)(this.FindName("Txt_codeFonction")));
            this.Cbo_Fonction = ((System.Windows.Controls.ComboBox)(this.FindName("Cbo_Fonction")));
            this.Btn_search = ((System.Windows.Controls.Button)(this.FindName("Btn_search")));
            this.Btn_reset = ((System.Windows.Controls.Button)(this.FindName("Btn_reset")));
            this.Dtg_agent = ((System.Windows.Controls.DataGrid)(this.FindName("Dtg_agent")));
            this.busyIndicator = ((System.Windows.Controls.BusyIndicator)(this.FindName("busyIndicator")));
            this.chkEnConsultation = ((System.Windows.Controls.CheckBox)(this.FindName("chkEnConsultation")));
        }
    }
}


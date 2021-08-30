﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Galatee.Structure
{
    [DataContract]
    public class CsMapperEntfac 
    {
        //[DataMember] public CsEnteteFacture  leEntfac { get; set; }
        public string LOTRI { get; set; }
        public string JET { get; set; }
        public string CENTRE { get; set; }
        public string CLIENT { get; set; }
        public string ORDRE { get; set; }
        public string DENABON { get; set; }
        public string NOMABON { get; set; }
        public string DENMAND { get; set; }
        public string NOMMAND { get; set; }
        public string ADRMAND1 { get; set; }
        public string ADRMAND2 { get; set; }
        public string CPOS { get; set; }
        public string BUREAU { get; set; }
        public string BANQUE { get; set; }
        public string GUICHET { get; set; }
        public string COMPTE { get; set; }
        public string RIB { get; set; }
        public string CODCONSO { get; set; }
        public string CATEGORIECLIENT { get; set; }
        public string REGROUPEMENT { get; set; }
        public string REGEDIT { get; set; }
        public string AG { get; set; }
        public string COMMUNE { get; set; }
        public string QUARTIER { get; set; }
        public string RUE { get; set; }
        public string NOMRUE { get; set; }
        public string NUMRUE { get; set; }
        public string COMPRUE { get; set; }
        public string ETAGE { get; set; }
        public string PORTE { get; set; }
        public string CADR { get; set; }
        public string TOURNEE { get; set; }
        public string ORDTOUR { get; set; }
        public string NBFAC { get; set; }
        public string FACTURE { get; set; }
        public string MES { get; set; }
        public Nullable<decimal> TOTFHT { get; set; }
        public Nullable<decimal> TOTFTAX { get; set; }
        public Nullable<decimal> TOTFTTC { get; set; }
        public string TOPE { get; set; }
        public string PERIODE { get; set; }
        public Nullable<int> EXIG { get; set; }
        public string COPER { get; set; }
        public string MODEPAIEMENT { get; set; }
        public Nullable<decimal> ANCIENREPORT { get; set; }
        public Nullable<decimal> TOTALNONARRONDI { get; set; }
        public string LIENFAC { get; set; }
        public string TOPMAJ { get; set; }
        public string SECTEUR { get; set; }
        public Nullable<System.DateTime> DRESABON { get; set; }
        public string REFERENCEATM { get; set; }
        public string CODEPROFIL { get; set; }
        public int PK_ID { get; set; }
        public Nullable<System.DateTime> DFAC { get; set; }
        public System.DateTime DATECREATION { get; set; }
        public Nullable<System.DateTime> DATEMODIFICATION { get; set; }
        public string USERCREATION { get; set; }
        public string USERMODIFICATION { get; set; }
        public int FK_IDCLIENT { get; set; }
        public int FK_IDCENTRE { get; set; }
        public int FK_IDCATEGORIECLIENT { get; set; }
        public int FK_IDTOURNEE { get; set; }
        public Nullable<int> FK_IDCOMMUNE { get; set; }
        public Nullable<bool> ISFACTUREEMAIL { get; set; }
        public Nullable<bool> ISFACTURESMS { get; set; }
        public string EMAIL { get; set; }
        public string TELEPHONE { get; set; }
        public Nullable<int> FK_IDQUARTIER { get; set; }
        public string MATRICULE { get; set; }


    }
}

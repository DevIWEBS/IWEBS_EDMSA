//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Galatee.Entity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETAILCAMPAGNE
    {
        public string IDCOUPURE { get; set; }
        public int PK_ID { get; set; }
        public string CENTRE { get; set; }
        public string CLIENT { get; set; }
        public string ORDRE { get; set; }
        public string REFEM { get; set; }
        public string NDOC { get; set; }
        public string COPER { get; set; }
        public Nullable<decimal> MONTANT { get; set; }
        public Nullable<System.DateTime> EXIGIBILITE { get; set; }
        public string TOURNEE { get; set; }
        public string ORDTOUR { get; set; }
        public string CATEGORIECLIENT { get; set; }
        public Nullable<decimal> SOLDEDUE { get; set; }
        public Nullable<int> NOMBREFACTURE { get; set; }
        public Nullable<decimal> SOLDECLIENT { get; set; }
        public Nullable<decimal> SOLDEFACTURE { get; set; }
        public string COMPTEUR { get; set; }
        public Nullable<bool> ISAUTORISER { get; set; }
        public string MOTIFAUTORISATION { get; set; }
        public Nullable<decimal> FRAIS { get; set; }
        public Nullable<bool> ISANNULATIONFRAIS { get; set; }
        public string MOTIFANNULATION { get; set; }
        public Nullable<System.DateTime> DATERDV { get; set; }
        public string USERCREATION { get; set; }
        public Nullable<System.DateTime> DATECREATION { get; set; }
        public Nullable<System.DateTime> DATEMODIFICATION { get; set; }
        public string USERMODIFICATION { get; set; }
        public int FK_IDLCLIENT { get; set; }
        public int FK_IDCENTRE { get; set; }
        public int FK_IDCLIENT { get; set; }
        public int FK_IDTOURNEE { get; set; }
        public int FK_IDCATEGORIECLIENT { get; set; }
        public int FK_IDCAMPAGNE { get; set; }
        public Nullable<int> RELANCE { get; set; }
        public Nullable<int> FK_IDTYPECOUPURE { get; set; }
    
        public virtual CAMPAGNE CAMPAGNE { get; set; }
        public virtual CATEGORIECLIENT CATEGORIECLIENT1 { get; set; }
        public virtual CENTRE CENTRE1 { get; set; }
        public virtual CLIENT CLIENT1 { get; set; }
        public virtual LCLIENT LCLIENT { get; set; }
        public virtual TOURNEE TOURNEE1 { get; set; }
        public virtual TYPECOUPURE TYPECOUPURE { get; set; }
    }
}

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
    
    public partial class CATEGORIECLIENT
    {
        public CATEGORIECLIENT()
        {
            this.CATEGORIECLIENT_TYPECLIENT = new HashSet<CATEGORIECLIENT_TYPECLIENT>();
            this.CATEGORIECLIENT_USAGE = new HashSet<CATEGORIECLIENT_USAGE>();
            this.CLIENT = new HashSet<CLIENT>();
            this.COUTDEMANDE = new HashSet<COUTDEMANDE>();
            this.DCLIENT = new HashSet<DCLIENT>();
            this.DETAILCAMPAGNE = new HashSet<DETAILCAMPAGNE>();
            this.DETAILCAMPAGNEPRENCONTENTIEUX = new HashSet<DETAILCAMPAGNEPRENCONTENTIEUX>();
            this.ENTFAC = new HashSet<ENTFAC>();
            this.LOTRI = new HashSet<LOTRI>();
            this.PAGERI = new HashSet<PAGERI>();
            this.PAGISOL = new HashSet<PAGISOL>();
            this.TYPETARIFPARCATEGORIE = new HashSet<TYPETARIFPARCATEGORIE>();
            this.FAC_ENTFAC = new HashSet<FAC_ENTFAC>();
        }
    
        public string CODE { get; set; }
        public string LIBELLE { get; set; }
        public System.DateTime DATECREATION { get; set; }
        public Nullable<System.DateTime> DATEMODIFICATION { get; set; }
        public string USERCREATION { get; set; }
        public string USERMODIFICATION { get; set; }
        public int PK_ID { get; set; }
        public Nullable<bool> ESTSUPPRIMER { get; set; }
    
        public virtual ICollection<CATEGORIECLIENT_TYPECLIENT> CATEGORIECLIENT_TYPECLIENT { get; set; }
        public virtual ICollection<CATEGORIECLIENT_USAGE> CATEGORIECLIENT_USAGE { get; set; }
        public virtual ICollection<CLIENT> CLIENT { get; set; }
        public virtual ICollection<COUTDEMANDE> COUTDEMANDE { get; set; }
        public virtual ICollection<DCLIENT> DCLIENT { get; set; }
        public virtual ICollection<DETAILCAMPAGNE> DETAILCAMPAGNE { get; set; }
        public virtual ICollection<DETAILCAMPAGNEPRENCONTENTIEUX> DETAILCAMPAGNEPRENCONTENTIEUX { get; set; }
        public virtual ICollection<ENTFAC> ENTFAC { get; set; }
        public virtual ICollection<LOTRI> LOTRI { get; set; }
        public virtual ICollection<PAGERI> PAGERI { get; set; }
        public virtual ICollection<PAGISOL> PAGISOL { get; set; }
        public virtual ICollection<TYPETARIFPARCATEGORIE> TYPETARIFPARCATEGORIE { get; set; }
        public virtual ICollection<FAC_ENTFAC> FAC_ENTFAC { get; set; }
    }
}

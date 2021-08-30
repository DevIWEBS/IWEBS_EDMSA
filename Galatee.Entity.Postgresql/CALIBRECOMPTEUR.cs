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
    
    public partial class CALIBRECOMPTEUR
    {
        public CALIBRECOMPTEUR()
        {
            this.COMPTEUR = new HashSet<COMPTEUR>();
            this.COMPTEURFRAUDE = new HashSet<COMPTEURFRAUDE>();
            this.DCOMPTEUR = new HashSet<DCOMPTEUR>();
            this.TYPEDISJONCTEURPARCALIBRECOMPTEUR = new HashSet<TYPEDISJONCTEURPARCALIBRECOMPTEUR>();
            this.MAGASINVIRTUEL = new HashSet<MAGASINVIRTUEL>();
            this.REGLAGECOMPTEUR = new HashSet<REGLAGECOMPTEUR>();
            this.TbCompteurBTA = new HashSet<TbCompteurBTA>();
        }
    
        public string LIBELLE { get; set; }
        public Nullable<int> REGLAGEMINI { get; set; }
        public Nullable<int> REGLAGEMAXI { get; set; }
        public System.DateTime DATECREATION { get; set; }
        public Nullable<System.DateTime> DATEMODIFICATION { get; set; }
        public string USERCREATION { get; set; }
        public string USERMODIFICATION { get; set; }
        public int PK_ID { get; set; }
        public int FK_IDPRODUIT { get; set; }
        public int FK_IDPHASE { get; set; }
    
        public virtual PHASECOMPTEUR PHASECOMPTEUR { get; set; }
        public virtual PRODUIT PRODUIT { get; set; }
        public virtual ICollection<COMPTEUR> COMPTEUR { get; set; }
        public virtual ICollection<COMPTEURFRAUDE> COMPTEURFRAUDE { get; set; }
        public virtual ICollection<DCOMPTEUR> DCOMPTEUR { get; set; }
        public virtual ICollection<TYPEDISJONCTEURPARCALIBRECOMPTEUR> TYPEDISJONCTEURPARCALIBRECOMPTEUR { get; set; }
        public virtual ICollection<MAGASINVIRTUEL> MAGASINVIRTUEL { get; set; }
        public virtual ICollection<REGLAGECOMPTEUR> REGLAGECOMPTEUR { get; set; }
        public virtual ICollection<TbCompteurBTA> TbCompteurBTA { get; set; }
    }
}

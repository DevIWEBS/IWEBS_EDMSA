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
    
    public partial class USAGE
    {
        public USAGE()
        {
            this.CATEGORIECLIENT_USAGE = new HashSet<CATEGORIECLIENT_USAGE>();
            this.CLIENT = new HashSet<CLIENT>();
            this.DCLIENT = new HashSet<DCLIENT>();
            this.COMPTEURFRAUDE = new HashSet<COMPTEURFRAUDE>();
        }
    
        public int PK_ID { get; set; }
        public string CODE { get; set; }
        public string LIBELLE { get; set; }
    
        public virtual ICollection<CATEGORIECLIENT_USAGE> CATEGORIECLIENT_USAGE { get; set; }
        public virtual ICollection<CLIENT> CLIENT { get; set; }
        public virtual ICollection<DCLIENT> DCLIENT { get; set; }
        public virtual ICollection<COMPTEURFRAUDE> COMPTEURFRAUDE { get; set; }
    }
}

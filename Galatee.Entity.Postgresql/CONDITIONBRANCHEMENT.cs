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
    
    public partial class CONDITIONBRANCHEMENT
    {
        public System.Guid PK_ID { get; set; }
        public string NOM { get; set; }
        public string COLONNENAME { get; set; }
        public string VALUE { get; set; }
        public int FK_IDTABLETRAVAIL { get; set; }
        public System.Guid FK_IDRAFFECTATIONWKF { get; set; }
        public Nullable<int> FK_IDETAPEVRAIE { get; set; }
        public Nullable<int> FK_IDETAPEFAUSE { get; set; }
        public string OPERATEUR { get; set; }
        public bool PEUT_TRANSMETTRE_SI_FAUX { get; set; }
    
        public virtual RAFFECTATIONETAPEWORKFLOW RAFFECTATIONETAPEWORKFLOW { get; set; }
    }
}

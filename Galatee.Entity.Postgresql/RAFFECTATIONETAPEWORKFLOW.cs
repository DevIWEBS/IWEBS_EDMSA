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
    
    public partial class RAFFECTATIONETAPEWORKFLOW
    {
        public RAFFECTATIONETAPEWORKFLOW()
        {
            this.CONDITIONBRANCHEMENT = new HashSet<CONDITIONBRANCHEMENT>();
        }
    
        public System.Guid PK_ID { get; set; }
        public System.Guid FK_RWORKFLOWCENTRE { get; set; }
        public int FK_IDETAPE { get; set; }
        public int ORDRE { get; set; }
        public System.Guid FK_IDGROUPEVALIDATIOIN { get; set; }
        public string CONDITION { get; set; }
        public Nullable<bool> FROMCONDITION { get; set; }
        public Nullable<System.Guid> FK_IDRETAPEWORKFLOWORIGINE { get; set; }
        public Nullable<int> DUREE { get; set; }
        public Nullable<int> ALERTE { get; set; }
        public Nullable<bool> USEAFFECTATION { get; set; }
    
        public virtual ICollection<CONDITIONBRANCHEMENT> CONDITIONBRANCHEMENT { get; set; }
        public virtual ETAPE ETAPE { get; set; }
        public virtual GROUPE_VALIDATION GROUPE_VALIDATION { get; set; }
        public virtual RWORFKLOWCENTRE RWORFKLOWCENTRE { get; set; }
    }
}

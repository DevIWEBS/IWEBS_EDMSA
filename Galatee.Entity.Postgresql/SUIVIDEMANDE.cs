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
    
    public partial class SUIVIDEMANDE
    {
        public int PK_ID { get; set; }
        public string NUMDEM { get; set; }
        public int FK_IDETAPE { get; set; }
        public Nullable<int> DUREE { get; set; }
        public string MATRICULEAGENT { get; set; }
        public string COMMENTAIRE { get; set; }
        public System.DateTime DATECREATION { get; set; }
        public Nullable<System.DateTime> DATEMODIFICATION { get; set; }
        public string USERCREATION { get; set; }
        public string USERMODIFICATION { get; set; }
        public int FK_IDDEMANDE { get; set; }
    
        public virtual ETAPE ETAPE { get; set; }
        public virtual DEMANDE DEMANDE { get; set; }
    }
}

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
    
    public partial class IMPORTCOLONNE
    {
        public int ID_COLONNE { get; set; }
        public string NOM { get; set; }
        public string TYPE { get; set; }
        public Nullable<int> LONGUEUR { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<int> ID_PARAMETRAGE { get; set; }
    
        public virtual PARAMETRAGEIMPORT PARAMETRAGEIMPORT { get; set; }
    }
}

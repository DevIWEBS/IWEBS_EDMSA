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
    
    public partial class PARAMETRESMTP
    {
        public int PK_ID { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string SERVEURSMTP { get; set; }
        public Nullable<int> PORT { get; set; }
        public Nullable<bool> SSL { get; set; }
    }
}

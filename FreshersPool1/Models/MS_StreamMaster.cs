//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreshersPool1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MS_StreamMaster
    {
        public MS_StreamMaster()
        {
            this.CA_Academics = new HashSet<CA_Academics>();
            this.CA_Academics1 = new HashSet<CA_Academics>();
            this.CA_Academics2 = new HashSet<CA_Academics>();
        }
    
        public string StreamID { get; set; }
        public string StreamDesc { get; set; }
    
        public virtual ICollection<CA_Academics> CA_Academics { get; set; }
        public virtual ICollection<CA_Academics> CA_Academics1 { get; set; }
        public virtual ICollection<CA_Academics> CA_Academics2 { get; set; }
    }
}

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
    
    public partial class CO_College
    {
        public CO_College()
        {
            this.CA_Academics = new HashSet<CA_Academics>();
            this.CA_Academics1 = new HashSet<CA_Academics>();
        }
    
        public string CollegeID { get; set; }
        public string CollegeName { get; set; }
        public int CollegeCode { get; set; }
        public string CollegeEmail { get; set; }
        public string Website { get; set; }
        public Nullable<int> YearStarted { get; set; }
        public string TpoName { get; set; }
        public string TpoMobile { get; set; }
        public string TpoEmail { get; set; }
        public string CollegePhone { get; set; }
        public string Status { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> Pin { get; set; }
        public string CollegeLogo { get; set; }
    
        public virtual ICollection<CA_Academics> CA_Academics { get; set; }
        public virtual ICollection<CA_Academics> CA_Academics1 { get; set; }
    }
}

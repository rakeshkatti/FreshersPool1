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
    
    public partial class MS_RoleMaster
    {
        public MS_RoleMaster()
        {
            this.CA_RolePreferences = new HashSet<CA_RolePreferences>();
            this.EM_JobPostings = new HashSet<EM_JobPostings>();
        }
    
        public string RoleID { get; set; }
        public string RoleDesc { get; set; }
    
        public virtual ICollection<CA_RolePreferences> CA_RolePreferences { get; set; }
        public virtual ICollection<EM_JobPostings> EM_JobPostings { get; set; }
    }
}
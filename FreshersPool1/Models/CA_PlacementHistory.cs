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
    
    public partial class CA_PlacementHistory
    {
        public int CandidateID { get; set; }
        public int JobID { get; set; }
        public string EmployerID { get; set; }
        public string DriveType { get; set; }
        public System.DateTime Date { get; set; }
        public string DrivePlace { get; set; }
        public string Result { get; set; }
        public string Remarks { get; set; }
    
        public virtual MS_DriveMaster MS_DriveMaster { get; set; }
        public virtual MS_ResultMaster MS_ResultMaster { get; set; }
    }
}
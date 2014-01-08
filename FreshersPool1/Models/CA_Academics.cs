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
    
    public partial class CA_Academics
    {
        public int CandidateID { get; set; }
        public string PG_Qual { get; set; }
        public string PG_Stream { get; set; }
        public Nullable<double> PG_PassPercentage { get; set; }
        public string PG_PassingYear { get; set; }
        public string PG_College { get; set; }
        public string Grad_Qual { get; set; }
        public string Grad_Stream { get; set; }
        public double Grad_PassPercentage { get; set; }
        public string Grad_PassingYear { get; set; }
        public string Grad_College { get; set; }
        public string Inter_Board { get; set; }
        public string Inter_Stream { get; set; }
        public double Inter_PassPercentage { get; set; }
        public string Inter_PassingYear { get; set; }
        public string Inter_College { get; set; }
        public string Tenth_Board { get; set; }
        public double Tenth_PassPercentage { get; set; }
        public string Tenth_PassingYear { get; set; }
        public string Tenth_School { get; set; }
        public string AnyGaps { get; set; }
        public string AnyBacklogs { get; set; }
    
        public virtual CA_PersonalData CA_PersonalData { get; set; }
        public virtual CO_College CO_College { get; set; }
        public virtual CO_College CO_College1 { get; set; }
        public virtual MS_StreamMaster MS_StreamMaster { get; set; }
        public virtual MS_StreamMaster MS_StreamMaster1 { get; set; }
        public virtual MS_StreamMaster MS_StreamMaster2 { get; set; }
    }
}
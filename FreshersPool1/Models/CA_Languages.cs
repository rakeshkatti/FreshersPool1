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
    
    public partial class CA_Languages
    {
        public int CandidateID { get; set; }
        public string LanguageID { get; set; }
        public string Language { get; set; }
        public string Speak { get; set; }
        public string Reads { get; set; }
        public string Write { get; set; }
    
        public virtual MS_LanguageMaster MS_LanguageMaster { get; set; }
        public virtual CA_PersonalData CA_PersonalData { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanManagement.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicationFeedback
    {
        public int FeedbackID { get; set; }
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public string FeedbackText { get; set; }
        public System.DateTime DateSubmitted { get; set; }
    
        public virtual LoanApplication LoanApplication { get; set; }
        public virtual User User { get; set; }
    }
}

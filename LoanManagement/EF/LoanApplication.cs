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
    
    public partial class LoanApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanApplication()
        {
            this.ApplicationFeedbacks = new HashSet<ApplicationFeedback>();
        }
    
        public int ApplicationID { get; set; }
        public double LoanAmount { get; set; }
        public string ApplicationStatus { get; set; }
        public System.DateTime AppliedDate { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public int ApplicantID { get; set; }
        public int ProductID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationFeedback> ApplicationFeedbacks { get; set; }
        public virtual LoanProduct LoanProduct { get; set; }
        public virtual User User { get; set; }
    }
}

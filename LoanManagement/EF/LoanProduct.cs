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
    
    public partial class LoanProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoanProduct()
        {
            this.LoanApplications = new HashSet<LoanApplication>();
        }
    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double InterestRate { get; set; }
        public string TermMonths { get; set; }
        public string EligibilityCriteria { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanApplication> LoanApplications { get; set; }
    }
}

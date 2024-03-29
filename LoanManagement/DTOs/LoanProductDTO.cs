using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class LoanProductDTO
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double InterestRate { get; set; }
        [Required]
        public string TermMonths { get; set; }
        [Required]
        public string EligibilityCriteria { get; set; }
    }
}
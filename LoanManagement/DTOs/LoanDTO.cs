using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class LoanDTO
    {
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public string ApplicationStatus { get; set; }
        [Required]
        public int ApplicantID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string DocumentUpload { get; set; }
    }
}
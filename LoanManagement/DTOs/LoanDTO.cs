using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class LoanDTO
    {
        public int ApplicationID { get; set; }
        public double LoanAmount { get; set; }
        public string ApplicationStatus { get; set; }
        public System.DateTime AppliedDate { get; set; }
        public System.DateTime DecisionDate { get; set; }
        public int ApplicantID { get; set; }
        public int ProductID { get; set; }
        public string DocumentUpload { get; set; }
    }
}
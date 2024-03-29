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
        public int ProductID { get; set; }
    }
}
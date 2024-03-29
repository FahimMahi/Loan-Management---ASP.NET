using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class ReminderDTO
    {
        public int ReminderID { get; set; }
        [Required]
        public string ReminderType { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string ReminderDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int UserID { get; set; }
    }
}
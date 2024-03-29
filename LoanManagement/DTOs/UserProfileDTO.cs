using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class UserProfileDTO
    {
        public int userID { get; set; }
        public string username { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int ContactNumber { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagement.DTOs
{
    public class UserDTO
    {
        public int userID { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int ContactNumber { get; set; }
        public string Role { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
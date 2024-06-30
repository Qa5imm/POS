﻿
using System.ComponentModel.DataAnnotations;

namespace posApp.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;

    }
}
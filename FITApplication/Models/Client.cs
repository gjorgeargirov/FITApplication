using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Range(1, 99)]
        public int Age { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Height { get; set; }

        public string Email { get; set; }
    }
}
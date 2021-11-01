using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class Client
    {
        public Client()
        {
            programs = new List<Program>();
        }
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Range(8,99)]
        public int Age { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Program> programs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class Program
    {
        public Program()
        {
            clients = new List<Client>();
        }

        [Key]
        public int ProgramID { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public virtual ICollection<Client> clients { get; set; }
    }
}
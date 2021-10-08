using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }
        public String Name { get; set; }

        public string ImgUrl { get; set; }

        public float Price { get; set; }
    }
}
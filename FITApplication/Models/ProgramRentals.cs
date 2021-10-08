using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class ProgramRentals
    {
        public int ProgramRentalsID { get; set; }

        public Program program { get; set; }
        public List<Client> clients { get; set; }

        public ProgramRentals()
        {
            clients = new List<Client>();
        }
    }
}
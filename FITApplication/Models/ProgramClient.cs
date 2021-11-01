using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class ProgramClient
    {
        public int ClientID { get; set; }
        public int ProgramID { get; set; }

        public Program program { get; set; }

        public List<Client> clients { get; set; }
    }
}
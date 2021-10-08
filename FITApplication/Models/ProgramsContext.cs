using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FITApplication.Models
{
    public class ProgramsContext:DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Program> programs { get; set; }
        public ProgramsContext() : base("DefaultConnection"){}

        public static ProgramsContext Create()
        {
            return new ProgramsContext();
        }
    }
}
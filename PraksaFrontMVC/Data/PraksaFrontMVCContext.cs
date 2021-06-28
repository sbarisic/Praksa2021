using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PraksaFrontMVC.Models;

namespace PraksaFrontMVC.Data
{
    public class PraksaFrontMVCContext : DbContext
    {
        public PraksaFrontMVCContext (DbContextOptions<PraksaFrontMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PraksaFrontMVC.Models.PermitName> PermitName { get; set; }

        public DbSet<PraksaFrontMVC.Models.RoleName> RoleName { get; set; }

        public DbSet<PraksaFrontMVC.Models.Person> Person { get; set; }

        public DbSet<PraksaFrontMVC.Models.Role> Role { get; set; }

        public DbSet<PraksaFrontMVC.Models.Attendant> Attendant { get; set; }

        public DbSet<PraksaFrontMVC.Models.Work> Work { get; set; }

        public DbSet<PraksaFrontMVC.Models.ContactEmail> ContactEmail { get; set; }
    }
}

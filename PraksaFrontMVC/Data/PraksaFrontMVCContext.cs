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
    }
}

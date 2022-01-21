using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hirlea_Grigore2_Proiect.Models;

namespace Hirlea_Grigore2_Proiect.Data
{
    public class Hirlea_Grigore2_ProiectContext : DbContext
    {
        public Hirlea_Grigore2_ProiectContext (DbContextOptions<Hirlea_Grigore2_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Hirlea_Grigore2_Proiect.Models.Product> Product { get; set; }

        public DbSet<Hirlea_Grigore2_Proiect.Models.Storage> Storage { get; set; }

        public DbSet<Hirlea_Grigore2_Proiect.Models.Category> Category { get; set; }
    }
}

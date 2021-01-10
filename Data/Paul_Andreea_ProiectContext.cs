using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paul_Andreea_Proiect.Models;

namespace Paul_Andreea_Proiect.Data
{
    public class Paul_Andreea_ProiectContext : DbContext
    {
        public Paul_Andreea_ProiectContext (DbContextOptions<Paul_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Paul_Andreea_Proiect.Models.Product> Product { get; set; }

        public DbSet<Paul_Andreea_Proiect.Models.Seller> Seller { get; set; }

        public DbSet<Paul_Andreea_Proiect.Models.Category> Category { get; set; }
    }
}

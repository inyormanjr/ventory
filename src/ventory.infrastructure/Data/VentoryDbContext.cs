using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ventory.domain.Entities.CompanyAgg;
using ventory.domain.Entities.ProductAgg;
using ventory.domain.Entities.UserAgg;
namespace ventory.infrastructure.Data
{
    public class VentoryDbContext : DbContext
    {
        //Implement the constructor
        public VentoryDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //Implement the DbSet properties
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //apply all configuration by assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VentoryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
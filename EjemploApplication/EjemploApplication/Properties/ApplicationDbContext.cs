using EjemploApplication.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EjemploApplication.Properties
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.RFC)
                .IsUnique();
        }
    }

}

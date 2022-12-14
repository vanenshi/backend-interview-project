using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(x => new { x.FirstName, x.LastName, x.DateOfBirth })
                .IsUnique(true);

            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.Email)
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}

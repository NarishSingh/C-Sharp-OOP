using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinqToDb
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        
        protected override void OnConfiguring (DbContextOptionsBuilder builder) => 
            builder.UseSqlServer(ConfigurationExtensions.GetConnectionString("DefaultConnection"));
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
            => modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasKey (c => c.Id);
    }
}
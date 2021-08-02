using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinqToDb
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
            => modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasKey (c => c.Id);
    }
}
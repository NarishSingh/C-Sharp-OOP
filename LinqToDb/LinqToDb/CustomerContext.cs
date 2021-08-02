using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinqToDb
{
    public class CustomerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        /*
        //Customer only 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasKey(c => c.Id);
        */
        
        //Customer + Purchase
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
                entity.Property(e => e.Name).IsRequired();
            });

            builder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });
        }
    }
}
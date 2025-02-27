using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace CustomerDB
{
    public class CustomerDBContext : DbContext
    {
        static DbContextOptions<CustomerDBContext> _options;
        static CustomerDBContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CustomerDBContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        public CustomerDBContext()
        : base(_options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "Canada" },
                new Country { Id = 3, Name = "United Kingdom" } 
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FullName = "John Doe", BirthDate = new DateTime(1990, 5, 15), Gender = "Male", Email = "johndoe@example.com", CountryId = 1 },
                new Customer { Id = 2, FullName = "Jane Smith", BirthDate = new DateTime(1985, 8, 23), Gender = "Female", Email = "janesmith@example.com", CountryId = 2 },
                new Customer { Id = 3, FullName = "Alice Brown", BirthDate = new DateTime(1995, 3, 10), Gender = "Female", Email = "alicebrown@example.com", CountryId = 3 },
                new Customer { Id = 4, FullName = "Michael Johnson", BirthDate = new DateTime(1988, 7, 20), Gender = "Male", Email = "michaelj@example.com", CountryId = 1 },
                new Customer { Id = 5, FullName = "Emma Wilson", BirthDate = new DateTime(1992, 11, 5), Gender = "Female", Email = "emmawilson@example.com", CountryId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Fashion" },
                new Category { Id = 3, Name = "Home & Kitchen" } 
            );

            modelBuilder.Entity<Promotion>().HasData(
                new Promotion { Id = 1, Name = "Black Friday Sale", CategoryId = 1, CountryId = 1, StartDate = new DateTime(2025, 11, 29), EndDate = new DateTime(2025, 12, 1) },
                new Promotion { Id = 2, Name = "Winter Discount", CategoryId = 2, CountryId = 2, StartDate = new DateTime(2025, 12, 15), EndDate = new DateTime(2026, 1, 5) },
                new Promotion { Id = 3, Name = "Cyber Monday Deals", CategoryId = 1, CountryId = 3, StartDate = new DateTime(2025, 12, 2), EndDate = new DateTime(2025, 12, 4) },
                new Promotion { Id = 4, Name = "Summer Clearance Sale", CategoryId = 2, CountryId = 1, StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 20) },
                new Promotion { Id = 5, Name = "Christmas Sale", CategoryId = 3, CountryId = 2, StartDate = new DateTime(2025, 12, 20), EndDate = new DateTime(2026, 1, 2) },
                new Promotion { Id = 6, Name = "New Year’s Discount", CategoryId = 1, CountryId = 3, StartDate = new DateTime(2026, 1, 1), EndDate = new DateTime(2026, 1, 10) },
                new Promotion { Id = 7, Name = "Easter Savings", CategoryId = 3, CountryId = 1, StartDate = new DateTime(2026, 4, 10), EndDate = new DateTime(2026, 4, 15) },
                new Promotion { Id = 8, Name = "Back to School Offers", CategoryId = 2, CountryId = 3, StartDate = new DateTime(2025, 8, 1), EndDate = new DateTime(2025, 8, 30) },
                new Promotion { Id = 9, Name = "Spring Home Decor Deals", CategoryId = 3, CountryId = 2, StartDate = new DateTime(2026, 3, 15), EndDate = new DateTime(2026, 3, 25) },
                new Promotion { Id = 10, Name = "Halloween Specials", CategoryId = 1, CountryId = 1, StartDate = new DateTime(2025, 10, 25), EndDate = new DateTime(2025, 10, 31) }
            );
        }

    }
}

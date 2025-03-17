using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace BookShopDb
{
    public class BookShopDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }


        static DbContextOptions<BookShopDbContext> _options;
        static BookShopDbContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BookShopDbContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        public BookShopDbContext()
        : base(_options)
        {
            Database.EnsureDeleted();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Pearson" },
                new Publisher { Id = 2, Name = "HarperCollins" },
                new Publisher { Id = 3, Name = "Penguin Random House" },
                new Publisher { Id = 4, Name = "Simon & Schuster" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling" },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell" },
                new Author { Id = 3, FirstName = "Agatha", LastName = "Christie" },
                new Author { Id = 4, FirstName = "Mark", LastName = "Twain" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Dystopian" },
                new Genre { Id = 3, Name = "Mystery" },
                new Genre { Id = 4, Name = "Classic Literature" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    PageCount = 309,
                    YearOfPublication = 1997,
                    CostPrice = 10.00m,
                    SellingPrice = 20.00m,
                    StockCount = 50,
                    SoldCount = 10,
                    IsWrittenOff = false,
                    SequelId = null,
                    PublisherId = 1,
                    AuthorId = 1,
                    GenreId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    PageCount = 328,
                    YearOfPublication = 1949,
                    CostPrice = 8.00m,
                    SellingPrice = 16.00m,
                    StockCount = 30,
                    SoldCount = 5,
                    IsWrittenOff = false,
                    SequelId = null,
                    PublisherId = 2,
                    AuthorId = 2,
                    GenreId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Murder on the Orient Express",
                    PageCount = 256,
                    YearOfPublication = 1934,
                    CostPrice = 6.00m,
                    SellingPrice = 15.00m,
                    StockCount = 40,
                    SoldCount = 8,
                    IsWrittenOff = false,
                    SequelId = null,
                    PublisherId = 3,
                    AuthorId = 3,
                    GenreId = 3
                },
                new Book
                {
                    Id = 4,
                    Title = "The Adventures of Tom Sawyer",
                    PageCount = 274,
                    YearOfPublication = 1876,
                    CostPrice = 5.00m,
                    SellingPrice = 12.00m,
                    StockCount = 35,
                    SoldCount = 12,
                    IsWrittenOff = true,
                    SequelId = null,
                    PublisherId = 4,
                    AuthorId = 4,
                    GenreId = 4
                }
            );

            modelBuilder.Entity<Promotion>().HasData(
                new Promotion
                {
                    Id = 1,
                    Description = "20% off on all books",
                    DiscountPercentage = 20.00m,
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2025, 12, 31)
                },
                new Promotion
                {
                    Id = 2,
                    Description = "Buy 2 Get 1 Free",
                    DiscountPercentage = 33.33m,
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 30)
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Customer { Id = 3, FirstName = "Alice", LastName = "Brown" },
                new Customer { Id = 4, FirstName = "Bob", LastName = "Johnson" }
            );

            modelBuilder.Entity<ReservedBook>().HasData(
                new ReservedBook { Id = 1, BookId = 1, CustomerId = 1, ReservedUntil = new DateTime(2025, 5, 1) },
                new ReservedBook { Id = 2, BookId = 2, CustomerId = 2, ReservedUntil = new DateTime(2025, 5, 1) },
                new ReservedBook { Id = 3, BookId = 3, CustomerId = 3, ReservedUntil = new DateTime(2025, 6, 1) },
                new ReservedBook { Id = 4, BookId = 4, CustomerId = 4, ReservedUntil = new DateTime(2025, 7, 1) }
            );

            modelBuilder.Entity<SaleTransaction>().HasData(
                new SaleTransaction { Id = 1, CustomerId = 1, BookId = 1, SaleDate = new DateTime(2025, 3, 12), SalePrice = 20.00m },
                new SaleTransaction { Id = 2, CustomerId = 2, BookId = 2, SaleDate = new DateTime(2025, 3, 12), SalePrice = 16.00m },
                new SaleTransaction { Id = 3, CustomerId = 3, BookId = 3, SaleDate = new DateTime(2025, 3, 15), SalePrice = 15.00m },
                new SaleTransaction { Id = 4, CustomerId = 4, BookId = 4, SaleDate = new DateTime(2025, 3, 18), SalePrice = 12.00m }
            );
        }
    }
}
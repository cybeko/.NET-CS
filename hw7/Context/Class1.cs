using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace Context
{
    public class EmployeeDbContext : DbContext
    {
        static DbContextOptions<EmployeeDbContext> _options;
        static EmployeeDbContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }
        public EmployeeDbContext()
        : base(_options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id); 

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(e => e.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(e => e.PositionId);
            });

            modelBuilder.Entity<Position>()
                .HasData(
                new Position { Id = 1, Name = "Software Engineer" },
                new Position { Id = 2, Name = "Project Manager" },
                new Position { Id = 3, Name = "HR Specialist" }
            );

            modelBuilder.Entity<Employee>()
                .HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", PositionId = 1 },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", PositionId = 2 },
                new Employee { Id = 3, FirstName = "Alice", LastName = "Johnson", PositionId = 3 }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace Context
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Head> Heads { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureRoom> LectureRooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Head)
                .WithOne()
                .HasForeignKey<Department>(d => d.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Head>()
                .HasOne(h => h.Teacher)
                .WithMany(t => t.Heads)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}

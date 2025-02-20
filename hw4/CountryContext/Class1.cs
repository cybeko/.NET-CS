using CountryModel;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CountryContext
{
    public class CountryContext : DbContext
    {
        public CountryContext()
        {
            if (Database.EnsureCreated())
            {
                Continent con1 = new Continent { Name = "Africa"};
                Continent con2 = new Continent { Name = "Asia" };
                Continent con3 = new Continent { Name = "Europe" };
                Continents?.Add(con1);
                Continents?.Add(con2);
                Continents?.Add(con3);

                Countries?.Add(new Country { Name = "China", Capital = "Beijing", Population = 1411778724, Area = 9600000, Continent = con2 });
                Countries?.Add(new Country { Name = "Egypt", Capital = "Cairo", Population = 104124000, Area = 1002450, Continent = con1 });
                Countries?.Add(new Country { Name = "Germany", Capital = "Berlin", Population = 83155031, Area = 357022, Continent = con3 });

                SaveChanges();
            }
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-N69P0E7;Database=CountryDB;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}

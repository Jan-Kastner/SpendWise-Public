using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpendWise.DAL;
using System.IO;

namespace SpendWise.DAL.Factories
{
    /// <summary>
    /// Factory class for creating instances of <see cref="SpendWiseDbContext"/> configured for PostgreSQL.
    /// </summary>
    public class DbContextPostgresFactory : IDbContextFactory<SpendWiseDbContext>
    {
        private readonly bool _seedTestingData;
        private readonly DbContextOptionsBuilder<SpendWiseDbContext> _contextOptionsBuilder = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextPostgresFactory"/> class.
        /// </summary>
        /// <param name="seedTestingData">A boolean indicating whether to seed testing data into the database.</param>
        public DbContextPostgresFactory(bool seedTestingData = false)
        {
            _seedTestingData = seedTestingData;
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _contextOptionsBuilder.UseNpgsql(connectionString);
        }

        /// <summary>
        /// Creates and configures a new instance of <see cref="SpendWiseDbContext"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="SpendWiseDbContext"/>.</returns>
        public SpendWiseDbContext CreateDbContext() => new(_contextOptionsBuilder.Options, _seedTestingData);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpendWise.DAL;
using Npgsql;

namespace SpendWise.DAL.Tests.Factories
{
    /// <summary>
    /// Factory class for creating instances of <see cref="SpendWiseDbContext"/> configured for PostgreSQL with a specified database name.
    /// </summary>
    public class DbContextPostgresTestingFactory : IDbContextFactory<SpendWiseDbContext>
    {
        private readonly bool _seedTestingData;

        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextPostgresTestingFactory"/> class.
        /// </summary>
        /// <param name="databaseName">The name of the PostgreSQL database to connect to.</param>
        /// <param name="seedTestingData">A boolean indicating whether to seed testing data into the database. Default is <c>false</c>.</param>
        public DbContextPostgresTestingFactory(string databaseName, bool seedTestingData = false)
        {
            _seedTestingData = seedTestingData;
            _databaseName = databaseName;
        }

        /// <summary>
        /// Creates and configures a new instance of <see cref="SpendWiseDbContext"/> with the specified database name.
        /// </summary>
        /// <returns>A new instance of <see cref="SpendWiseDbContext"/>.</returns>
        public SpendWiseDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Database = _databaseName
            };

            var optionsBuilder = new DbContextOptionsBuilder<SpendWiseDbContext>();
            optionsBuilder.UseNpgsql(builder.ConnectionString);

            return new SpendWiseDbContext(optionsBuilder.Options, _seedTestingData);
        }
    }
}
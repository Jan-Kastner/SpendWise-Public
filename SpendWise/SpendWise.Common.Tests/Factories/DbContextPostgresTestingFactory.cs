using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SpendWise.DAL.dbContext;

namespace SpendWise.Common.Tests.Factories
{
    /// <summary>
    /// Factory class for creating instances of <see cref="SpendWiseDbContext"/> configured for PostgreSQL with a specified database name.
    /// </summary>
    public class DbContextPostgresTestingFactory : IDbContextFactory<SpendWiseTestDbContext>
    {
        private readonly string _databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextPostgresTestingFactory"/> class.
        /// </summary>
        /// <param name="databaseName">The name of the PostgreSQL database to connect to.</param>
        public DbContextPostgresTestingFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        /// <summary>
        /// Creates and configures a new instance of <see cref="SpendWiseDbContext"/> with the specified database name.
        /// </summary>
        /// <returns>A new instance of <see cref="SpendWiseDbContext"/>.</returns>
        public SpendWiseTestDbContext CreateDbContext()
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

            var optionsBuilder = new DbContextOptionsBuilder<SpendWiseTestDbContext>();
            optionsBuilder.UseNpgsql(builder.ConnectionString);

            return new SpendWiseTestDbContext(optionsBuilder.Options);
        }
    }
}
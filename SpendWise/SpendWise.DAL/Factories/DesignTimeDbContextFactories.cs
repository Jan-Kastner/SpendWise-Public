using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SpendWise.DAL.dbContext;
using System.IO;

namespace SpendWise.DAL.Factories
{
    /// <summary>
    /// Factory class for creating instances of <see cref="SpendWiseDbContext"/> at design time.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SpendWiseDbContext>
    {
        /// <summary>
        /// Creates a new instance of <see cref="SpendWiseDbContext"/> configured with the connection string from the configuration file.
        /// </summary>
        /// <param name="args">Command-line arguments passed during the design-time creation. Not used in this implementation.</param>
        /// <returns>A new instance of <see cref="SpendWiseDbContext"/>.</returns>
        public SpendWiseDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<SpendWiseDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new SpendWiseDbContext(optionsBuilder.Options);
        }
    }
}

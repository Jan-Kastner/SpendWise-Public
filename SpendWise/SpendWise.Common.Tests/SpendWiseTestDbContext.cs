using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.dbContext;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests
{
    /// <summary>
    /// Represents the database context for testing, inheriting from <see cref="SpendWiseDbContextBase"/>.
    /// Configured to use seeding for test data.
    /// </summary>
    public class SpendWiseTestDbContext : SpendWiseDbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpendWiseTestDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options to be used by the <see cref="SpendWiseTestDbContext"/>. This is typically
        /// provided by the dependency injection container or a factory.
        /// </param>
        public SpendWiseTestDbContext(DbContextOptions<SpendWiseTestDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model with data for testing.
        /// This method is used to apply seed data to the model.
        /// </summary>
        /// <param name="modelBuilder">
        /// The <see cref="ModelBuilder"/> used to configure the model.
        /// </param>
        protected override void ApplySeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySeeds();
        }
    }
}

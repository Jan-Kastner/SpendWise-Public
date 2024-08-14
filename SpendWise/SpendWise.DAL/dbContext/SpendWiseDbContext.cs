using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.dbContext
{
    /// <summary>
    /// Represents the database context for production use, inheriting from 
    /// <see cref="SpendWiseDbContextBase"/>.
    /// </summary>
    public class SpendWiseDbContext : SpendWiseDbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpendWiseDbContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options to be used by the <see cref="SpendWiseDbContext"/>. This is typically 
        /// provided by the dependency injection container or a factory.
        /// </param>
        public SpendWiseDbContext(DbContextOptions<SpendWiseDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model without applying seed data for production.
        /// This method overrides the base class method but performs no operations 
        /// in the production environment.
        /// </summary>
        /// <param name="modelBuilder">
        /// The <see cref="ModelBuilder"/> used to configure the model.
        /// </param>
        protected override void ApplySeeding(ModelBuilder modelBuilder)
        {
            // No operation (NOP) for production environment
        }
    }
}

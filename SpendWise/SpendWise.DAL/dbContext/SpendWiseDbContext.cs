using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.dbContext
{
    /// <summary>
    /// SpendWise DbContext for production use.
    /// </summary>
    public class SpendWiseDbContext : SpendWiseDbContextBase
    {
        public SpendWiseDbContext(DbContextOptions<SpendWiseDbContext> options)
            : base(options)
        {
        }

        // No seeding in production
        protected override void ApplySeeding(ModelBuilder modelBuilder)
        {
            // No operation (NOP)
        }
    }
}

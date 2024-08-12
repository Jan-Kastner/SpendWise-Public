using Microsoft.EntityFrameworkCore;
using SpendWise.DAL.dbContext;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests
{
    /// <summary>
    /// SpendWise DbContext for testing, which seeds demo data.
    /// </summary>
    public class SpendWiseTestDbContext : SpendWiseDbContextBase
    {
        public SpendWiseTestDbContext(DbContextOptions<SpendWiseTestDbContext> options)
            : base(options)
        {
        }

        // Seed data for testing
        protected override void ApplySeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySeeds();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides extension methods for the <see cref="ModelBuilder"/> class to apply seed data.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Applies all seed data to the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entity model for a context.</param>
        public static void ApplySeeds(this ModelBuilder modelBuilder)
        {
            CategorySeeds.Seed(modelBuilder);
            UserSeeds.Seed(modelBuilder);
            GroupSeeds.Seed(modelBuilder);
            LimitSeeds.Seed(modelBuilder);
            GroupUserSeeds.Seed(modelBuilder);
            InvitationSeeds.Seed(modelBuilder);
            TransactionSeeds.Seed(modelBuilder);
            TransactionGroupUserSeeds.Seed(modelBuilder);
        }
    }
}
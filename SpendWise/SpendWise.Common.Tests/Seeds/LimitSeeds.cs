using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Enums;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="LimitEntity"/> entity.
    /// </summary>
    public static class LimitSeeds
    {
        public static readonly Guid GroupUserCharlieInFamilyId = Guid.NewGuid();
        public static readonly Guid GroupUserDianaInFamilyId = Guid.NewGuid();
        public static readonly Guid GroupUserJohnInWorkId = Guid.NewGuid();

        /// <summary>
        /// Gets the seed data for a limit assigned to Charlie in the family group.
        /// </summary>
        public static readonly LimitEntity LimitCharlieFamily = new()
        {
            Id = Guid.NewGuid(),
            Amount = 1000m,
            NoticeType = NoticeType.InApp,
            GroupUserId = GroupUserCharlieInFamilyId
        };

        /// <summary>
        /// Gets the seed data for a limit assigned to Diana in the family group.
        /// </summary>
        public static readonly LimitEntity LimitDianaFamily = new()
        {
            Id = Guid.NewGuid(),
            Amount = 1500m,
            NoticeType = NoticeType.SMS,
            GroupUserId = GroupUserDianaInFamilyId
        };

        /// <summary>
        /// Gets the seed data for a limit assigned to John in the work group.
        /// </summary>
        public static readonly LimitEntity LimitJohnWork = new()
        {
            Id = Guid.NewGuid(),
            Amount = 2000m,
            NoticeType = NoticeType.InApp,
            GroupUserId = GroupUserJohnInWorkId
        };

        /// <summary>
        /// Seeds the <see cref="LimitEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LimitEntity>().HasData(
                LimitCharlieFamily,
                LimitDianaFamily,
                LimitJohnWork
            );
        }
    }
}

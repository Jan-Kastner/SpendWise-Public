using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="LimitEntity"/> entity.
    /// </summary>
    public static class LimitSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="LimitEntity"/> representing a limit for Admin in the family group.
        /// </summary>
        public static readonly LimitEntity LimitAdminFamily = new()
        {
            Id = Guid.NewGuid(),
            Amount = 1000m,
            NoticeType = 1,
            GroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="LimitEntity"/> representing a limit for John Doe in the friends group.
        /// </summary>
        public static readonly LimitEntity LimitJohnDoeFriends = new()
        {
            Id = Guid.NewGuid(),
            Amount = 500m,
            NoticeType = 1,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
            GroupUser = null!
        };

        /// <summary>
        /// Seeds the <see cref="LimitEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LimitEntity>().HasData(
                LimitAdminFamily,
                LimitJohnDoeFriends
            );
        }
    }
}

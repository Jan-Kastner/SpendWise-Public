using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="GroupUserEntity"/> entity.
    /// </summary>
    public static class GroupUserSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing an admin user in the family group.
        /// </summary>
        public static readonly GroupUserEntity GroupUserAdminInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserAdmin.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing John Doe as a user in the friends group.
        /// </summary>
        public static readonly GroupUserEntity GroupUserJohnDoeInFriends = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupFriends.Id,
            User = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing John Doe as a user in the family group.
        /// </summary>
        public static readonly GroupUserEntity GroupUserJohnDoeInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing Alice Brown as a user in the work group.
        /// </summary>
        public static readonly GroupUserEntity GroupUserAliceBrownInWork = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserAliceBrown.Id,
            GroupId = GroupSeeds.GroupWork.Id,
            User = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing an admin user in the family group with related entities.
        /// </summary>
        public static readonly GroupUserEntity GroupUserAdminInFamilyWithRelations = GroupUserAdminInFamily with
        {
            User = UserSeeds.UserAdmin,
            Group = GroupSeeds.GroupFamily,
            Limit = LimitSeeds.LimitAdminFamily
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing John Doe as a user in the friends group with related entities.
        /// </summary>
        public static readonly GroupUserEntity GroupUserJohnDoeInFriendsWithRelations = GroupUserJohnDoeInFriends with
        {
            User = UserSeeds.UserJohnDoe,
            Group = GroupSeeds.GroupFriends
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing John Doe as a user in the family group with related entities.
        /// </summary>
        public static readonly GroupUserEntity GroupUserJohnDoeInFamilyWithRelations = GroupUserJohnDoeInFamily with
        {
            User = UserSeeds.UserJohnDoe,
            Group = GroupSeeds.GroupFamily
        };

        /// <summary>
        /// A seed instance of <see cref="GroupUserEntity"/> representing Alice Brown as a user in the work group with related entities.
        /// </summary>
        public static readonly GroupUserEntity GroupUserAliceBrownInWorkWithRelations = GroupUserAliceBrownInWork with
        {
            User = UserSeeds.UserAliceBrown,
            Group = GroupSeeds.GroupWork
        };

        /// <summary>
        /// Seeds the <see cref="GroupUserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUserEntity>().HasData(
                GroupUserAdminInFamily,
                GroupUserJohnDoeInFriends,
                GroupUserJohnDoeInFamily,
                GroupUserAliceBrownInWork
            );
        }
    }
}

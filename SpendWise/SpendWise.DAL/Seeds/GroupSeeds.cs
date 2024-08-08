using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.DAL.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="GroupEntity"/> entity.
    /// </summary>
    public static class GroupSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a family group.
        /// </summary>
        public static readonly GroupEntity GroupFamily = new()
        {
            Id = Guid.NewGuid(),
            Name = "Family",
            Description = "Family group"
        };

        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a friends group.
        /// </summary>
        public static readonly GroupEntity GroupFriends = new()
        {
            Id = Guid.NewGuid(),
            Name = "Friends",
            Description = "Friends group"
        };

        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a work group.
        /// </summary>
        public static readonly GroupEntity GroupWork = new()
        {
            Id = Guid.NewGuid(),
            Name = "Work",
            Description = "Work group"
        };

        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a family group with related entities.
        /// </summary>
        public static readonly GroupEntity GroupFamilyWithRelations = GroupFamily with
        {
            GroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserAdminInFamily,
                GroupUserSeeds.GroupUserJohnDoeInFamily
            },
            Invitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationAdminToJohnDoeIntoFamily
            }
        };

        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a friends group with related entities.
        /// </summary>
        public static readonly GroupEntity GroupFriendsWithRelations = GroupFriends with
        {
            GroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserJohnDoeInFriends
            },
            Invitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationJohnDoeToAdminIntoFriends
            }
        };

        /// <summary>
        /// A seed instance of <see cref="GroupEntity"/> representing a work group with related entities.
        /// </summary>
        public static readonly GroupEntity GroupWorkWithRelations = GroupWork with
        {
            GroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserAliceBrownInWork
            }
        };

        /// <summary>
        /// Seeds the <see cref="GroupEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupEntity>().HasData(
                GroupFamily,
                GroupFriends,
                GroupWork
            );
        }
    }
}

using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="InvitationEntity"/> entity.
    /// </summary>
    public static class InvitationSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="InvitationEntity"/> representing an invitation from Admin to John Doe 
        /// into the family group.
        /// </summary>
        public static readonly InvitationEntity InvitationAdminToJohnDoeIntoFamily = new()
        {
            Id = Guid.NewGuid(),
            SenderId = UserSeeds.UserAdmin.Id,
            ReceiverId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            SentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc),
            ResponseDate = null,
            IsAccepted = null,
            Sender = null!,
            Receiver = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="InvitationEntity"/> representing an invitation from John Doe to Admin 
        /// into the friends group.
        /// </summary>
        public static readonly InvitationEntity InvitationJohnDoeToAdminIntoFriends = new()
        {
            Id = Guid.NewGuid(),
            SenderId = UserSeeds.UserJohnDoe.Id,
            ReceiverId = UserSeeds.UserAdmin.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            SentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc),
            ResponseDate = new DateTime(2024, 7, 1, 14, 0, 0, DateTimeKind.Utc),
            IsAccepted = true,
            Sender = null!,
            Receiver = null!,
            Group = null!
        };

        /// <summary>
        /// A seed instance of <see cref="InvitationEntity"/> representing an invitation from Admin to John Doe 
        /// into the family group with related entities.
        /// </summary>
        public static readonly InvitationEntity InvitationAdminToJohnDoeIntoFamilyWithRelations =
            InvitationAdminToJohnDoeIntoFamily with
            {
                Sender = UserSeeds.UserAdmin,
                Receiver = UserSeeds.UserJohnDoe,
                Group = GroupSeeds.GroupFamily
            };

        /// <summary>
        /// A seed instance of <see cref="InvitationEntity"/> representing an invitation from John Doe to Admin 
        /// into the friends group with related entities.
        /// </summary>
        public static readonly InvitationEntity InvitationJohnDoeToAdminIntoFriendsWithRelations =
            InvitationJohnDoeToAdminIntoFriends with
            {
                Sender = UserSeeds.UserAdmin,
                Receiver = UserSeeds.UserJohnDoe,
                Group = GroupSeeds.GroupFamily
            };

        /// <summary>
        /// Seeds the <see cref="InvitationEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvitationEntity>().HasData(
                InvitationAdminToJohnDoeIntoFamily,
                InvitationJohnDoeToAdminIntoFriends
            );
        }
    }
}

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
        /// Gets the seed data for an invitation from Diana to Charlie into the family group.
        /// </summary>
        public static readonly InvitationEntity InvitationDianaToCharlieIntoFamily = new()
        {
            Id = Guid.NewGuid(),
            SenderId = UserSeeds.UserDianaGreen.Id,
            ReceiverId = UserSeeds.UserCharlieBlack.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            SentDate = new DateTime(2024, 7, 1, 12, 0, 0, DateTimeKind.Utc),
            ResponseDate = null,
            IsAccepted = true,
            Sender = UserSeeds.UserDianaGreen,
            Receiver = UserSeeds.UserCharlieBlack,
            Group = GroupSeeds.GroupFamily
        };

        /// <summary>
        /// Gets the seed data for an invitation from John to Diana into the family group.
        /// </summary>
        public static readonly InvitationEntity InvitationJohnToDianaIntoFamily = new()
        {
            Id = Guid.NewGuid(),
            SenderId = UserSeeds.UserJohnDoe.Id,
            ReceiverId = UserSeeds.UserDianaGreen.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            SentDate = new DateTime(2024, 7, 2, 12, 0, 0, DateTimeKind.Utc),
            ResponseDate = null,
            IsAccepted = true,
            Sender = UserSeeds.UserJohnDoe,
            Receiver = UserSeeds.UserDianaGreen,
            Group = GroupSeeds.GroupFamily
        };

        /// <summary>
        /// Gets the seed data for an invitation from John to Diana into the work group.
        /// </summary>
        public static readonly InvitationEntity InvitationJohnToDianaIntoWork = new()
        {
            Id = Guid.NewGuid(),
            SenderId = UserSeeds.UserJohnDoe.Id,
            ReceiverId = UserSeeds.UserDianaGreen.Id,
            GroupId = GroupSeeds.GroupWork.Id,
            SentDate = new DateTime(2024, 7, 3, 12, 0, 0, DateTimeKind.Utc),
            ResponseDate = null,
            IsAccepted = null,
            Sender = UserSeeds.UserJohnDoe,
            Receiver = UserSeeds.UserDianaGreen,
            Group = GroupSeeds.GroupWork
        };

        /// <summary>
        /// Seeds the <see cref="InvitationEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvitationEntity>().HasData(
                InvitationDianaToCharlieIntoFamily with
                {
                    Sender = null!,
                    Receiver = null!,
                    Group = null!
                },

                InvitationJohnToDianaIntoFamily with
                {
                    Sender = null!,
                    Receiver = null!,
                    Group = null!
                },

                InvitationJohnToDianaIntoWork with
                {
                    Sender = null!,
                    Receiver = null!,
                    Group = null!
                }
            );
        }
    }
}

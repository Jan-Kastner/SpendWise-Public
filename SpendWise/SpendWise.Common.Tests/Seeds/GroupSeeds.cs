using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="GroupEntity"/> entity.
    /// </summary>
    public static class GroupSeeds
    {
        private static bool _relationsInitialized = false;
        /// <summary>
        /// Gets the seed data for the family group.
        /// </summary>
        public static readonly GroupEntity GroupFamily = new()
        {
            Id = Guid.NewGuid(),
            Name = "Family",
            Description = "Family group",
            GroupUsers = new List<GroupUserEntity>(),
            Invitations = new List<InvitationEntity>()
        };

        /// <summary>
        /// Gets the seed data for the friends group.
        /// </summary>
        public static readonly GroupEntity GroupFriends = new()
        {
            Id = Guid.NewGuid(),
            Name = "Friends",
            Description = "Friends group",
            GroupUsers = new List<GroupUserEntity>(),
            Invitations = new List<InvitationEntity>()
        };

        /// <summary>
        /// Gets the seed data for the work group.
        /// </summary>
        public static readonly GroupEntity GroupWork = new()
        {
            Id = Guid.NewGuid(),
            Name = "Work",
            Description = "Work group",
            GroupUsers = new List<GroupUserEntity>(),
            Invitations = new List<InvitationEntity>()
        };

        /// <summary>
        /// Initializes the relationships between groups and their associated users and invitations.
        /// </summary>
        public static void InitializeRelations()
        {
            if (!_relationsInitialized)
            {
                // Initialize relations for GroupFamily
                GroupFamily.GroupUsers.Add(GroupUserSeeds.GroupUserBobInFamily);
                GroupFamily.GroupUsers.Add(GroupUserSeeds.GroupUserCharlieInFamily);
                GroupFamily.GroupUsers.Add(GroupUserSeeds.GroupUserDianaInFamily);
                GroupFamily.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInFamily);
                GroupFamily.Invitations.Add(InvitationSeeds.InvitationDianaToCharlieIntoFamily);
                GroupFamily.Invitations.Add(InvitationSeeds.InvitationJohnToDianaIntoFamily);

                // Initialize relations for GroupFriends
                GroupFriends.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInFriends);

                // Initialize relations for GroupWork
                GroupWork.GroupUsers.Add(GroupUserSeeds.GroupUserJohnInWork);
                GroupWork.Invitations.Add(InvitationSeeds.InvitationJohnToDianaIntoWork);

                _relationsInitialized = true;
            }
        }

        /// <summary>
        /// Seeds the <see cref="GroupEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupEntity>().HasData(
                GroupFamily with
                {
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    Invitations = Array.Empty<InvitationEntity>()
                },

                GroupFriends with
                {
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    Invitations = Array.Empty<InvitationEntity>()
                },

                GroupWork with
                {
                    GroupUsers = Array.Empty<GroupUserEntity>(),
                    Invitations = Array.Empty<InvitationEntity>()
                }
            );
            InitializeRelations();
        }
    }
}

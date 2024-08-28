using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="GroupUserEntity"/> entity.
    /// </summary>
    public static class GroupUserSeeds
    {
        private static bool _relationsInitialized = false;
        /// <summary>
        /// Gets the seed data for Bob in the family group.
        /// </summary>
        public static GroupUserEntity GroupUserBobInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserBobBrown.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = UserSeeds.UserBobBrown, // Set User directly
            Group = GroupSeeds.GroupFamily // Set Group directly
        };

        /// <summary>
        /// Gets the seed data for Charlie in the family group.
        /// </summary>
        public static GroupUserEntity GroupUserCharlieInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserCharlieBlack.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = UserSeeds.UserCharlieBlack, // Set User directly
            Group = GroupSeeds.GroupFamily // Set Group directly
        };

        /// <summary>
        /// Gets the seed data for Diana in the family group.
        /// </summary>
        public static GroupUserEntity GroupUserDianaInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserDianaGreen.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = UserSeeds.UserDianaGreen, // Set User directly
            Group = GroupSeeds.GroupFamily // Set Group directly
        };

        /// <summary>
        /// Gets the seed data for John in the family group.
        /// </summary>
        public static GroupUserEntity GroupUserJohnInFamily = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupFamily.Id,
            User = UserSeeds.UserJohnDoe, // Set User directly
            Group = GroupSeeds.GroupFamily // Set Group directly
        };

        /// <summary>
        /// Gets the seed data for John in the friends group.
        /// </summary>
        public static GroupUserEntity GroupUserJohnInFriends = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupFriends.Id,
            User = UserSeeds.UserJohnDoe, // Set User directly
            Group = GroupSeeds.GroupFriends // Set Group directly
        };

        /// <summary>
        /// Gets the seed data for John in the work group.
        /// </summary>
        public static GroupUserEntity GroupUserJohnInWork = new()
        {
            Id = Guid.NewGuid(),
            UserId = UserSeeds.UserJohnDoe.Id,
            GroupId = GroupSeeds.GroupWork.Id,
            User = UserSeeds.UserJohnDoe, // Set User directly
            Group = GroupSeeds.GroupWork // Set Group directly
        };

        /// <summary>
        /// Initializes the relationships between group users and their associated transaction group users.
        /// </summary>
        public static void InitializeRelations()
        {
            if (!_relationsInitialized)
            {
                // Initialize TransactionGroupUsers collections
                GroupUserDianaInFamily.TransactionGroupUsers.Add(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana);
                GroupUserJohnInFamily.TransactionGroupUsers.Add(TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn);
                GroupUserJohnInFriends.TransactionGroupUsers.Add(TransactionGroupUserSeeds.TransactionGroupUserTaxiFriendsJohn);
                GroupUserJohnInFriends.TransactionGroupUsers.Add(TransactionGroupUserSeeds.TransactionGroupUserTransportFriendsJohn);
                GroupUserJohnInWork.TransactionGroupUsers.Add(TransactionGroupUserSeeds.TransactionGroupUserTransportWorkJohn);

                GroupUserCharlieInFamily.LimitId = LimitSeeds.LimitCharlieFamily.Id;
                GroupUserDianaInFamily.LimitId = LimitSeeds.LimitDianaFamily.Id;
                GroupUserJohnInWork.LimitId = LimitSeeds.LimitJohnWork.Id;

                GroupUserCharlieInFamily.Limit = LimitSeeds.LimitCharlieFamily;
                GroupUserDianaInFamily.Limit = LimitSeeds.LimitDianaFamily;
                GroupUserJohnInWork.Limit = LimitSeeds.LimitJohnWork;

                _relationsInitialized = true;
            }
        }

        /// <summary>
        /// Seeds the <see cref="GroupUserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUserEntity>().HasData(
                GroupUserBobInFamily with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    Limit = null
                },

                GroupUserCharlieInFamily with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    LimitId = LimitSeeds.LimitCharlieFamily.Id,
                    Limit = null
                },

                GroupUserDianaInFamily with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    LimitId = LimitSeeds.LimitDianaFamily.Id,
                    Limit = null
                },

                GroupUserJohnInFamily with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    Limit = null
                },

                GroupUserJohnInFriends with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    Limit = null
                },

                GroupUserJohnInWork with
                {
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>(),
                    User = null!,
                    Group = null!,
                    LimitId = LimitSeeds.LimitJohnWork.Id,
                    Limit = null
                }
            );
            InitializeRelations();
        }
    }
}

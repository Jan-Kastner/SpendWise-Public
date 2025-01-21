using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="TransactionGroupUserEntity"/> entity.
    /// </summary>
    public static class TransactionGroupUserSeeds
    {
        /// <summary>
        /// Gets the seed data for the transaction group user entry for Diana's dinner in the family group.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserDinnerFamilyDiana = new()
        {
            Id = Guid.NewGuid(),
            IsRead = true,
            TransactionId = TransactionSeeds.TransactionDianaDinner.Id,
            GroupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id,
            Transaction = TransactionSeeds.TransactionDianaDinner,
            GroupUser = GroupUserSeeds.GroupUserDianaInFamily
        };

        /// <summary>
        /// Gets the seed data for the transaction group user entry for John's food transaction in the family group.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserFoodFamilyJohn = new()
        {
            Id = Guid.NewGuid(),
            IsRead = true,
            TransactionId = TransactionSeeds.TransactionJohnFood.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnInFamily.Id,
            Transaction = TransactionSeeds.TransactionJohnFood,
            GroupUser = GroupUserSeeds.GroupUserJohnInFamily
        };

        /// <summary>
        /// Gets the seed data for the transaction group user entry for John's taxi transaction in the friends group.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserTaxiFriendsJohn = new()
        {
            Id = Guid.NewGuid(),
            IsRead = false,
            TransactionId = TransactionSeeds.TransactionJohnTaxi.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnInFriends.Id,
            Transaction = TransactionSeeds.TransactionJohnTaxi,
            GroupUser = GroupUserSeeds.GroupUserJohnInFriends
        };

        /// <summary>
        /// Gets the seed data for the transaction group user entry for John's transport transaction in the friends group.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserTransportFriendsJohn = new()
        {
            Id = Guid.NewGuid(),
            IsRead = false,
            TransactionId = TransactionSeeds.TransactionJohnTransport.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnInFriends.Id,
            Transaction = TransactionSeeds.TransactionJohnTransport,
            GroupUser = GroupUserSeeds.GroupUserJohnInFriends
        };

        /// <summary>
        /// Gets the seed data for the transaction group user entry for John's transport transaction in the work group.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserTransportWorkJohn = new()
        {
            Id = Guid.NewGuid(),
            IsRead = false,
            TransactionId = TransactionSeeds.TransactionJohnTransport.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnInWork.Id,
            Transaction = TransactionSeeds.TransactionJohnTransport,
            GroupUser = GroupUserSeeds.GroupUserJohnInWork
        };

        /// <summary>
        /// Seeds the <see cref="TransactionGroupUserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to seed data into.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionGroupUserEntity>().HasData(
                TransactionGroupUserDinnerFamilyDiana with
                {
                    Transaction = null!,
                    GroupUser = null!
                },

                TransactionGroupUserFoodFamilyJohn with
                {
                    Transaction = null!,
                    GroupUser = null!
                },

                TransactionGroupUserTaxiFriendsJohn with
                {
                    Transaction = null!,
                    GroupUser = null!
                },

                TransactionGroupUserTransportFriendsJohn with
                {
                    Transaction = null!,
                    GroupUser = null!
                },

                TransactionGroupUserTransportWorkJohn with
                {
                    Transaction = null!,
                    GroupUser = null!
                }
            );
        }
    }
}

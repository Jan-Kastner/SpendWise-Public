using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="TransactionGroupUserEntity"/> entity.
    /// </summary>
    public static class TransactionGroupUserSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Admin Food.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForAdminFood = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionAdminFood.Id,
            GroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the friends group for John Doe Transport.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionJohnDoeTransport.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for John Doe Transport.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionJohnDoeTransport.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 30 Hours.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus30Hours = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionMinus30Hours.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 28 Hours.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus28Hours = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionMinus28Hours.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 26 Hours.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus26Hours = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionMinus26Hours.Id,
            GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Minus 24 Hours.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForMinus24Hours = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionMinus24Hours.Id,
            GroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Minus 22 Hours.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForMinus22Hours = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionMinus22Hours.Id,
            GroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Deletion.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForDelete = new()
        {
            Id = Guid.NewGuid(),
            TransactionId = TransactionSeeds.TransactionDelete.Id,
            GroupUserId = GroupUserSeeds.GroupUserAdminInFamily.Id,
            Transaction = null!,
            GroupUser = null!
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Admin Food with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForAdminFoodWithRelations = TransactionGroupUserAdminInFamilyForAdminFood with
        {
            Transaction = TransactionSeeds.TransactionAdminFood,
            GroupUser = GroupUserSeeds.GroupUserAdminInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the friends group for John Doe Transport with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFriendsForJohnDoeTransportWithRelations = TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport with
        {
            Transaction = TransactionSeeds.TransactionJohnDoeTransport,
            GroupUser = GroupUserSeeds.GroupUserJohnDoeInFriends
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 30 Hours with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus30HoursWithRelations = TransactionGroupUserJohnDoeInFamilyForMinus30Hours with
        {
            Transaction = TransactionSeeds.TransactionMinus30Hours,
            GroupUser = GroupUserSeeds.GroupUserJohnDoeInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 28 Hours with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus28HoursWithRelations = TransactionGroupUserJohnDoeInFamilyForMinus28Hours with
        {
            Transaction = TransactionSeeds.TransactionMinus28Hours,
            GroupUser = GroupUserSeeds.GroupUserJohnDoeInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for Minus 26 Hours with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForMinus26HoursWithRelations = TransactionGroupUserJohnDoeInFamilyForMinus26Hours with
        {
            Transaction = TransactionSeeds.TransactionMinus26Hours,
            GroupUser = GroupUserSeeds.GroupUserJohnDoeInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Minus 24 Hours with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForMinus24HoursWithRelations = TransactionGroupUserAdminInFamilyForMinus24Hours with
        {
            Transaction = TransactionSeeds.TransactionMinus24Hours,
            GroupUser = GroupUserSeeds.GroupUserAdminInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Minus 22 Hours with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForMinus22HoursWithRelations = TransactionGroupUserAdminInFamilyForMinus22Hours with
        {
            Transaction = TransactionSeeds.TransactionMinus22Hours,
            GroupUser = GroupUserSeeds.GroupUserAdminInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for Admin 
        /// in the family group for Deletion with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserAdminInFamilyForDeleteWithRelations = TransactionGroupUserAdminInFamilyForDelete with
        {
            Transaction = TransactionSeeds.TransactionDelete,
            GroupUser = GroupUserSeeds.GroupUserAdminInFamily
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionGroupUserEntity"/> representing a transaction for John Doe 
        /// in the family group for John Doe Transport with related entities.
        /// </summary>
        public static readonly TransactionGroupUserEntity TransactionGroupUserJohnDoeInFamilyForJohnDoeTransportWithRelations = TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport with
        {
            Id = Guid.NewGuid(),
            Transaction = TransactionSeeds.TransactionJohnDoeTransport,
            GroupUser = GroupUserSeeds.GroupUserJohnDoeInFamily
        };

        /// <summary>
        /// Seeds the <see cref="TransactionGroupUserEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionGroupUserEntity>().HasData(
                TransactionGroupUserAdminInFamilyForAdminFood,
                TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport,
                TransactionGroupUserJohnDoeInFamilyForMinus30Hours,
                TransactionGroupUserJohnDoeInFamilyForMinus28Hours,
                TransactionGroupUserJohnDoeInFamilyForMinus26Hours,
                TransactionGroupUserAdminInFamilyForMinus24Hours,
                TransactionGroupUserAdminInFamilyForMinus22Hours,
                TransactionGroupUserAdminInFamilyForDelete,
                TransactionGroupUserJohnDoeInFamilyForJohnDoeTransport
            );
        }
    }
}

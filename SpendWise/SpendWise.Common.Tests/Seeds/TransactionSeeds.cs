using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="TransactionEntity"/> entity.
    /// </summary>
    public static class TransactionSeeds
    {
        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Admin Food.
        /// </summary>
        public static readonly TransactionEntity TransactionAdminFood = new()
        {
            Id = Guid.NewGuid(),
            Amount = 100.0m,
            Date = new DateTime(2024, 7, 1, 12, 5, 0, DateTimeKind.Utc),
            Description = "Groceries",
            Type = 1,
            CategoryId = CategorySeeds.CategoryFood.Id,
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for John Doe Transport.
        /// </summary>
        public static readonly TransactionEntity TransactionJohnDoeTransport = new()
        {
            Id = Guid.NewGuid(),
            Amount = 50.0m,
            Date = new DateTime(2024, 7, 1, 12, 10, 0, DateTimeKind.Utc),
            Description = "Utilities",
            Type = 2,
            CategoryId = CategorySeeds.CategoryTransport.Id,
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 30 Hours.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus30Hours = new()
        {
            Id = Guid.NewGuid(),
            Date = TransactionAdminFood.Date.AddHours(-30),
            Amount = 150.0m,
            Description = "Lunch",
            Type = 1,
            CategoryId = CategorySeeds.CategoryFood.Id,
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 28 Hours.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus28Hours = new()
        {
            Id = Guid.NewGuid(),
            Date = TransactionAdminFood.Date.AddHours(-28),
            Amount = 200.0m,
            Description = "Coffee",
            Type = 1,
            CategoryId = CategorySeeds.CategoryFood.Id,
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 26 Hours.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus26Hours = new()
        {
            Id = Guid.NewGuid(),
            Date = TransactionAdminFood.Date.AddHours(-26),
            Amount = 175.0m,
            Description = "Taxi",
            Type = 1,
            CategoryId = CategorySeeds.CategoryFood.Id,
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 24 Hours.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus24Hours = TransactionAdminFood with
        {
            Id = Guid.NewGuid(),
            Date = TransactionAdminFood.Date.AddHours(-24),
            Amount = 120.0m,
            Description = "Dinner",
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 22 Hours.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus22Hours = TransactionAdminFood with
        {
            Id = Guid.NewGuid(),
            Date = TransactionAdminFood.Date.AddHours(-22),
            Amount = 60.0m,
            Description = "Snacks",
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Deletion.
        /// </summary>
        public static readonly TransactionEntity TransactionDelete = TransactionJohnDoeTransport with
        {
            Id = Guid.NewGuid(),
            Category = null
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Admin Food with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionAdminFoodWithRelations = TransactionAdminFood with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForAdminFood
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for John Doe Transport with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionJohnDoeTransportWithRelations = TransactionJohnDoeTransport with
        {
            Category = CategorySeeds.CategoryTransport,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport,
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFriendsForJohnDoeTransport
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 30 Hours with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus30HoursWithRelations = TransactionMinus30Hours with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus30Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 28 Hours with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus28HoursWithRelations = TransactionMinus28Hours with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus28Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 26 Hours with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus26HoursWithRelations = TransactionMinus26Hours with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserJohnDoeInFamilyForMinus26Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 24 Hours with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus24HoursWithRelations = TransactionMinus24Hours with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForMinus24Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Minus 22 Hours with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionMinus22HoursWithRelations = TransactionMinus22Hours with
        {
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForMinus22Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="TransactionEntity"/> representing a transaction for Deletion with related entities.
        /// </summary>
        public static readonly TransactionEntity TransactionDeleteWithRelations = TransactionDelete with
        {
            Category = null, // Assuming the category is removed or not relevant
            TransactionGroupUsers = new List<TransactionGroupUserEntity>
            {
                TransactionGroupUserSeeds.TransactionGroupUserAdminInFamilyForDelete
            }
        };

        /// <summary>
        /// Seeds the <see cref="TransactionEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>().HasData(
                TransactionAdminFood,
                TransactionJohnDoeTransport,
                TransactionMinus30Hours,
                TransactionMinus28Hours,
                TransactionMinus26Hours,
                TransactionMinus24Hours,
                TransactionMinus22Hours,
                TransactionDelete
            );
        }
    }
}

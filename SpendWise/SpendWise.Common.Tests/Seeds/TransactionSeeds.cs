using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Enums;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="TransactionEntity"/> entity.
    /// </summary>
    public static class TransactionSeeds
    {
        /// <summary>
        /// Gets the seed data for Diana's dinner transaction.
        /// </summary>
        public static readonly TransactionEntity TransactionDianaDinner = new()
        {
            Id = Guid.NewGuid(),
            Amount = 45.0m,
            Date = new DateTime(2024, 7, 4, 19, 30, 0, DateTimeKind.Utc),
            Description = "Dinner at restaurant",
            Type = TransactionType.Expense,
            CategoryId = null,
            Category = null,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>()
        };

        /// <summary>
        /// Gets the seed data for John's groceries transaction.
        /// </summary>
        public static readonly TransactionEntity TransactionJohnFood = new()
        {
            Id = Guid.NewGuid(),
            Amount = 100.0m,
            Date = new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc),
            Description = "Groceries",
            Type = TransactionType.Expense,
            CategoryId = CategorySeeds.CategoryFood.Id,
            Category = CategorySeeds.CategoryFood,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>()
        };

        /// <summary>
        /// Gets the seed data for John's taxi ride transaction.
        /// </summary>
        public static readonly TransactionEntity TransactionJohnTaxi = new()
        {
            Id = Guid.NewGuid(),
            Amount = 25.0m,
            Date = new DateTime(2024, 7, 6, 22, 15, 0, DateTimeKind.Utc),
            Description = "Taxi ride home",
            Type = TransactionType.Expense,
            CategoryId = CategorySeeds.CategoryTransport.Id,
            Category = CategorySeeds.CategoryTransport,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>()
        };

        /// <summary>
        /// Gets the seed data for John's public transport transaction.
        /// </summary>
        public static readonly TransactionEntity TransactionJohnTransport = new()
        {
            Id = Guid.NewGuid(),
            Amount = 50.0m,
            Date = new DateTime(2024, 7, 7, 8, 30, 0, DateTimeKind.Utc),
            Description = "Public Transport",
            Type = TransactionType.Expense,
            CategoryId = CategorySeeds.CategoryTransport.Id,
            Category = CategorySeeds.CategoryTransport,
            TransactionGroupUsers = new List<TransactionGroupUserEntity>()
        };

        /// <summary>
        /// Seeds the <see cref="TransactionEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to seed data into.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>().HasData(
                TransactionDianaDinner with
                {
                    Category = null,
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>()
                },

                TransactionJohnFood with
                {
                    Category = null,
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>()
                },

                TransactionJohnTaxi with
                {
                    Category = null,
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>()
                },

                TransactionJohnTransport with
                {
                    Category = null,
                    TransactionGroupUsers = Array.Empty<TransactionGroupUserEntity>()
                }
            );
        }
    }
}
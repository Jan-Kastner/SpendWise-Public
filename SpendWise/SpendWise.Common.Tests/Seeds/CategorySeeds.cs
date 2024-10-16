using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="CategoryEntity"/> entity.
    /// </summary>
    public static class CategorySeeds
    {
        private static bool _relationsInitialized = false;

        /// <summary>
        /// Gets the seed data for the food category.
        /// </summary>
        public static readonly CategoryEntity CategoryFood = new()
        {
            Id = Guid.NewGuid(),
            Name = "Food",
            Description = "Groceries and eating out",
            Color = "#ff0000",
            Icon = Array.Empty<byte>(),
            Transactions = new List<TransactionEntity>()
        };

        /// <summary>
        /// Gets the seed data for the transport category.
        /// </summary>
        public static readonly CategoryEntity CategoryTransport = new()
        {
            Id = Guid.NewGuid(),
            Name = "Transport",
            Description = "Transportation expenses",
            Color = "#00ff00",
            Icon = Array.Empty<byte>(),
            Transactions = new List<TransactionEntity>()
        };

        /// <summary>
        /// Initializes the relationships between categories and their associated transactions.
        /// </summary>
        public static void InitializeRelations()
        {
            if (!_relationsInitialized)
            {
                CategoryFood.Transactions.Add(TransactionSeeds.TransactionJohnFood);

                CategoryTransport.Transactions.Add(TransactionSeeds.TransactionJohnTaxi);
                CategoryTransport.Transactions.Add(TransactionSeeds.TransactionJohnTransport);

                _relationsInitialized = true;
            }
        }

        /// <summary>
        /// Seeds the <see cref="CategoryEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure the entity.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                CategoryFood with
                {
                    Transactions = Array.Empty<TransactionEntity>()
                },

                CategoryTransport with
                {
                    Transactions = Array.Empty<TransactionEntity>()
                }
            );
            InitializeRelations();
        }
    }
}

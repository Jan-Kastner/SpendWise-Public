using SpendWise.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SpendWise.Common.Tests.Seeds
{
    /// <summary>
    /// Provides seed data for the <see cref="CategoryEntity"/> entity.
    /// </summary>
    public static class CategorySeeds
    {
        /// <summary>
        /// A seed instance of <see cref="CategoryEntity"/> representing food-related expenses.
        /// </summary>
        public static readonly CategoryEntity CategoryFood = new()
        {
            Id = Guid.NewGuid(),
            Name = "Food",
            Description = "Groceries and eating out",
            Color = "#ff0000",
            Icon = null
        };

        /// <summary>
        /// A seed instance of <see cref="CategoryEntity"/> representing transportation-related expenses.
        /// </summary>
        public static readonly CategoryEntity CategoryTransport = new()
        {
            Id = Guid.NewGuid(),
            Name = "Transport",
            Description = "Transportation expenses",
            Color = "#00ff00",
            Icon = null
        };

        /// <summary>
        /// A seed instance of <see cref="CategoryEntity"/> with related transactions for food-related expenses.
        /// </summary>
        public static readonly CategoryEntity CategoryFoodWithRelations = CategoryFood with
        {
            Transactions = new List<TransactionEntity>
            {
                TransactionSeeds.TransactionAdminFood,
                TransactionSeeds.TransactionMinus30Hours,
                TransactionSeeds.TransactionMinus28Hours,
                TransactionSeeds.TransactionMinus26Hours,
                TransactionSeeds.TransactionMinus24Hours,
                TransactionSeeds.TransactionMinus22Hours
            }
        };

        /// <summary>
        /// A seed instance of <see cref="CategoryEntity"/> with related transactions for transportation-related expenses.
        /// </summary>
        public static readonly CategoryEntity CategoryTransportWithRelations = CategoryTransport with
        {
            Transactions = new List<TransactionEntity>
            {
                TransactionSeeds.TransactionJohnDoeTransport,
                TransactionSeeds.TransactionDelete
            }
        };

        /// <summary>
        /// Seeds the <see cref="CategoryEntity"/> data into the provided <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to seed data.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                CategoryFood,
                CategoryTransport
            );
        }
    }
}

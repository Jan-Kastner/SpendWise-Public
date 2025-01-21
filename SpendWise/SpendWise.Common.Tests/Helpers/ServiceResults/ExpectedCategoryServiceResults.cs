using SpendWise.BLL.DTOs;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for category DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedCategoryServiceResults
    {
        /// <summary>
        /// Gets the expected result for the food category as a list DTO.
        /// </summary>
        public static readonly CategoryListDto CategoryFoodList = new()
        {
            Id = CategorySeeds.CategoryFood.Id,
            Name = "Food",
            Color = "#ff0000",
            Icon = Array.Empty<byte>()
        };

        /// <summary>
        /// Gets the expected result for the transport category as a list DTO.
        /// </summary>
        public static readonly CategoryListDto CategoryTransportList = new()
        {
            Id = CategorySeeds.CategoryTransport.Id,
            Name = "Transport",
            Color = "#00ff00",
            Icon = Array.Empty<byte>()
        };

        /// <summary>
        /// Gets the expected result for the food category as a summary DTO.
        /// </summary>
        public static readonly CategorySummaryDto CategoryFoodSummary = new()
        {
            Id = CategorySeeds.CategoryFood.Id,
            Name = "Food",
            Color = "#ff0000",
            Icon = Array.Empty<byte>()
        };

        /// <summary>
        /// Gets the expected result for the transport category as a summary DTO.
        /// </summary>
        public static readonly CategorySummaryDto CategoryTransportSummary = new()
        {
            Id = CategorySeeds.CategoryTransport.Id,
            Name = "Transport",
            Color = "#00ff00",
            Icon = Array.Empty<byte>()
        };

        /// <summary>
        /// Gets the expected result for the food category as a detail DTO.
        /// </summary>
        public static readonly CategoryDetailDto CategoryFoodDetail = new()
        {
            Id = CategorySeeds.CategoryFood.Id,
            Name = "Food",
            Description = "Groceries and eating out",
            Color = "#ff0000",
            Icon = Array.Empty<byte>()
        };

        /// <summary>
        /// Gets the expected result for the transport category as a detail DTO.
        /// </summary>
        public static readonly CategoryDetailDto CategoryTransportDetail = new()
        {
            Id = CategorySeeds.CategoryTransport.Id,
            Name = "Transport",
            Description = "Transportation expenses",
            Color = "#00ff00",
            Icon = Array.Empty<byte>()
        };
    }
}
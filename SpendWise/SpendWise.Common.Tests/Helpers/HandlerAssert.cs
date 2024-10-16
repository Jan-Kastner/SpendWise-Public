using SpendWise.BLL.DTOs;
using SpendWise.Common.Tests.Seeds;
using Xunit;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides methods for performing assertions on handler results in unit tests.
    /// </summary>
    public static class HandlerAssert
    {
        public static void AssertCategoryDetail(CategoryDetailDto category, string expectedName, string expectedColor)
        {
            Assert.NotNull(category);
            Assert.Equal(expectedName, category.Name);
            Assert.Equal(expectedColor, category.Color);
            Assert.All(category.Transactions, transaction =>
            {
                Assert.NotEqual(Guid.Empty, transaction.Id);
                Assert.True(transaction.Amount > 0);
            });
        }

        public static void AssertCategoryList(CategoryListDto category, string expectedName, string expectedColor)
        {
            Assert.NotNull(category);
            Assert.Equal(expectedName, category.Name);
            Assert.Equal(expectedColor, category.Color);
        }

        public static void AssertCategorySummary(CategorySummaryDto summary, string expectedName)
        {
            Assert.NotNull(summary);
            Assert.Equal(expectedName, summary.Name);
        }

        public static void AssertContainsCategoryDetail(IEnumerable<CategoryDetailDto> result, string expectedName, string expectedColor)
        {
            Assert.Contains(result, category => category.Name == expectedName && category.Color == expectedColor);
            Assert.All(result, category => AssertCategoryDetail(category, category.Name, category.Color));
        }

        public static void AssertContainsCategoryList(IEnumerable<CategoryListDto> result, string expectedName, string expectedColor)
        {
            Assert.Contains(result, category => category.Name == expectedName && category.Color == expectedColor);
            Assert.All(result, category => AssertCategoryList(category, category.Name, category.Color));
        }

        public static void AssertContainsCategorySummary(IEnumerable<CategorySummaryDto> result, string expectedName)
        {
            Assert.Contains(result, summary => summary.Name == expectedName);
            Assert.All(result, summary => AssertCategorySummary(summary, summary.Name));
        }
    }
}
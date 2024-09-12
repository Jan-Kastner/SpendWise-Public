using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class TransactionQueryObjectTests : UnitOfWorkTestsBase
    {
        public TransactionQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a transaction by its ID 
        /// returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectTransaction()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithId(transactionId));

            // Assert
            Assert.NotNull(transactions);
            Assert.Single(transactions);
            Assert.Equal(transactionId, transactions.First().Id);
        }

        /// <summary>
        /// Verifies that querying transactions by multiple IDs 
        /// returns the correct entries that match any of the provided IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var transactionId1 = TransactionSeeds.TransactionDianaDinner.Id;
            var transactionId2 = TransactionSeeds.TransactionJohnFood.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithId(transactionId1).OrWithId(transactionId2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.True(t.Id == transactionId1 || t.Id == transactionId2));
        }

        /// <summary>
        /// Verifies that querying transactions by ID excludes the entry with the specified ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var excludedTransactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithId(excludedTransactionId));

            // Assert
            Assert.NotNull(transactions);
            Assert.DoesNotContain(transactions, t => t.Id == excludedTransactionId);
        }

        #endregion

        #region AmountQuery Tests

        /// <summary>
        /// Verifies that querying transactions by amount 
        /// returns all correct entries associated with that amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithAmount_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var amount = TransactionSeeds.TransactionDianaDinner.Amount;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithAmount(amount));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Equal(amount, t.Amount));
        }

        /// <summary>
        /// Verifies that querying transactions by multiple amounts 
        /// returns the correct entries that match any of the provided amounts.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithAmount_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var amount1 = TransactionSeeds.TransactionDianaDinner.Amount;
            var amount2 = TransactionSeeds.TransactionJohnFood.Amount;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithAmount(amount1).OrWithAmount(amount2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.True(t.Amount == amount1 || t.Amount == amount2));
        }

        /// <summary>
        /// Verifies that querying transactions by amount excludes entries with the specified amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithAmount_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var excludedAmount = TransactionSeeds.TransactionDianaDinner.Amount;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithAmount(excludedAmount));

            // Assert
            Assert.NotNull(transactions);
            Assert.DoesNotContain(transactions, t => t.Amount == excludedAmount);
        }

        #endregion

        #region DateQuery Tests

        /// <summary>
        /// Verifies that querying transactions by date 
        /// returns all correct entries associated with that date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDate_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var date = TransactionSeeds.TransactionDianaDinner.Date;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithDate(date));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Equal(date, t.Date));
        }

        /// <summary>
        /// Verifies that querying transactions by multiple dates 
        /// returns the correct entries that match any of the provided dates.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDate_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var date1 = TransactionSeeds.TransactionDianaDinner.Date;
            var date2 = TransactionSeeds.TransactionJohnFood.Date;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithDate(date1).OrWithDate(date2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.True(t.Date == date1 || t.Date == date2));
        }

        /// <summary>
        /// Verifies that querying transactions by date excludes entries with the specified date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDate_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var excludedDate = TransactionSeeds.TransactionDianaDinner.Date;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithDate(excludedDate));

            // Assert
            Assert.NotNull(transactions);
            Assert.DoesNotContain(transactions, t => t.Date == excludedDate);
        }

        #endregion

        /// <summary>
        /// Verifies that querying transactions by description 
        /// returns all correct entries associated with that description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescription_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var transactionDescription = TransactionSeeds.TransactionJohnFood.Description;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithDescription(transactionDescription));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
                Assert.NotNull(transactionDescription);
                Assert.Contains(transactionDescription, t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions by description using an OR condition 
        /// returns all correct entries that contain either of the specified descriptions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescription_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var transactionDescription1 = TransactionSeeds.TransactionJohnFood.Description;
            var transactionDescription2 = "Taxi ride home";
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithDescription(transactionDescription1).OrWithDescription(transactionDescription2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
                Assert.NotNull(transactionDescription1);
                Assert.NotNull(transactionDescription2);
                Assert.True(t.Description.Contains(transactionDescription1) || t.Description.Contains(transactionDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying transactions by partial description match 
        /// returns all correct entries that contain the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescriptionPartialMatch_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var partialDescription = "Groceries";
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithDescriptionPartialMatch(partialDescription));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
                Assert.Contains(partialDescription, t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions by partial description match using an OR condition 
        /// returns all correct entries that contain either of the specified texts in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescriptionPartialMatch_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var partialDescription1 = "Groceries";
            var partialDescription2 = "Transport";
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithDescriptionPartialMatch(partialDescription1).OrWithDescriptionPartialMatch(partialDescription2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
                Assert.True(t.Description.Contains(partialDescription1) || t.Description.Contains(partialDescription2));
            });
        }

        /// <summary>
        /// Verifies that querying transactions with a NOT condition by description 
        /// excludes all transactions containing the specified description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescription_ShouldExcludeTransactions()
        {
            // Arrange
            var transactionDescription = TransactionSeeds.TransactionJohnFood.Description;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithDescription(transactionDescription));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(transactionDescription);
                Assert.DoesNotContain(transactionDescription, t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions with a NOT condition by partial description match 
        /// excludes all transactions containing the specified text in the description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDescriptionPartialMatch_ShouldExcludeTransactions()
        {
            // Arrange
            var excludedText = "Groceries";
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithDescriptionPartialMatch(excludedText));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
                Assert.DoesNotContain(excludedText, t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions without a description 
        /// returns all transactions that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutDescription_ShouldReturnTransactionsWithNullDescription()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithoutDescription());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.Null(t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions without a description using an OR condition 
        /// returns all transactions that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutDescription_ShouldReturnTransactionsWithNullDescription()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithoutDescription());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.Null(t.Description);
            });
        }

        /// <summary>
        /// Verifies that querying transactions with a NOT condition for null description 
        /// excludes all transactions that have a null description.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutDescription_ShouldExcludeTransactionsWithNullDescription()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithoutDescription());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotNull(t.Description);
            });
        }
        #region TypeQuery Tests

        /// <summary>
        /// Verifies that querying transactions by type 
        /// returns all correct entries associated with that type.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithType_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var type = TransactionSeeds.TransactionDianaDinner.Type;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithType(type));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.Equal(type, t.Type);
            });
        }

        /// <summary>
        /// Verifies that querying transactions by multiple types 
        /// returns the correct entries that match any of the provided types.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithType_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var type1 = TransactionSeeds.TransactionDianaDinner.Type;
            var type2 = TransactionSeeds.TransactionJohnFood.Type;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithType(type1).OrWithType(type2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.True(t.Type == type1 || t.Type == type2);
            });
        }

        /// <summary>
        /// Verifies that querying transactions by type excludes entries with the specified type.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithType_ShouldExcludeTransactions()
        {
            // Arrange
            var excludedType = TransactionSeeds.TransactionDianaDinner.Type;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithType(excludedType));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.NotEqual(excludedType, t.Type);
            });
        }

        #endregion

        #region CategoryQuery Tests

        /// <summary>
        /// Verifies that querying transactions by category 
        /// returns all correct entries associated with that category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithCategory_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var categoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithCategory(categoryId));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Equal(categoryId, t.CategoryId));
        }

        /// <summary>
        /// Verifies that querying transactions by multiple categories 
        /// returns the correct entries that match any of the provided categories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithCategory_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var categoryId1 = CategorySeeds.CategoryFood.Id;
            var categoryId2 = CategorySeeds.CategoryTransport.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithCategory(categoryId1).OrWithCategory(categoryId2));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.True(t.CategoryId == categoryId1 || t.CategoryId == categoryId2));
        }

        /// <summary>
        /// Verifies that querying transactions by category excludes entries with the specified category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithCategory_ShouldExcludeTransactions()
        {
            // Arrange
            var excludedCategoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithCategory(excludedCategoryId));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.NotEqual(excludedCategoryId, t.CategoryId));
        }

        /// <summary>
        /// Verifies that querying transactions without a category 
        /// returns all transactions that have a null category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutCategory_ShouldReturnTransactionsWithNullCategory()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithoutCategory());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Null(t.CategoryId));
        }

        /// <summary>
        /// Verifies that querying transactions without a category using an OR condition 
        /// returns all transactions that have a null category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutCategory_ShouldReturnTransactionsWithNullCategory()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithoutCategory());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Null(t.CategoryId));
        }

        /// <summary>
        /// Verifies that querying transactions with a NOT condition for null category 
        /// excludes all transactions that have a null category.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutCategory_ShouldExcludeTransactionsWithNullCategory()
        {
            // Arrange
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithoutCategory());

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.NotNull(t.CategoryId));
        }

        #endregion

        #region TransactionGroupUserQuery Tests

        /// <summary>
        /// Verifies that querying transactions by transaction group user 
        /// returns all correct entries associated with that transaction group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithTransactionGroupUser_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var transactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithTransactionGroupUser(transactionGroupUser.Id));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.Equal(transactionGroupUser.TransactionId, t.Id));
        }

        /// <summary>
        /// Verifies that querying transactions by multiple transaction group users 
        /// returns the correct entries that match any of the provided transaction group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithTransactionGroupUser_ShouldReturnCorrectTransactions()
        {
            // Arrange
            var transactionGroupUser1 = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var transactionGroupUser2 = TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithTransactionGroupUser(transactionGroupUser1.Id).OrWithTransactionGroupUser(transactionGroupUser2.Id));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(new[] { transactionGroupUser1, transactionGroupUser2 }, tgu =>
                Assert.Contains(transactions, t => t.Id == tgu.TransactionId));
        }

        /// <summary>
        /// Verifies that querying transactions by excluding a specific transaction group user 
        /// returns entries that do not contain the transaction group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithTransactionGroupUser_ShouldExcludeTransactions()
        {
            // Arrange
            var transactionGroupUser = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.NotWithTransactionGroupUser(transactionGroupUser.Id));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t => Assert.NotEqual(transactionGroupUser.TransactionId, t.Id));
        }

        #endregion

        #region Complex Tests

        /// <summary>
        /// Verifies that querying transactions by ID and Amount using AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdAndAmount_ShouldReturnCorrectEntry()
        {
            // Arrange
            var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var transactionAmount = TransactionSeeds.TransactionDianaDinner.Amount;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithId(transactionId).WithAmount(transactionAmount));

            // Assert
            Assert.NotNull(transactions);
            Assert.Single(transactions);
            Assert.Equal(transactionId, transactions.First().Id);
            Assert.Equal(transactionAmount, transactions.First().Amount);
        }

        /// <summary>
        /// Verifies that querying transactions by Date and Description using AND condition
        /// returns entries that match both criteria.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDateAndDescription_ShouldReturnCorrectEntries()
        {
            // Arrange
            var transactionDate = TransactionSeeds.TransactionDianaDinner.Date;
            var transactionDescription = TransactionSeeds.TransactionDianaDinner.Description;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithDate(transactionDate).WithDescription(transactionDescription));

            // Assert
            Assert.NotNull(transactions);
            Assert.Single(transactions);
            Assert.Equal(transactionDate, transactions.First().Date);
            Assert.Equal(transactionDescription, transactions.First().Description);
        }

        /// <summary>
        /// Verifies that querying transactions by Amount or Type using OR condition
        /// returns entries that match either criterion.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithAmountOrType_ShouldReturnCorrectEntries()
        {
            // Arrange
            var transactionAmount = TransactionSeeds.TransactionDianaDinner.Amount;
            var transactionType = TransactionSeeds.TransactionJohnFood.Type;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithAmount(transactionAmount).OrWithType(transactionType));

            // Assert
            Assert.NotNull(transactions);
            Assert.NotEmpty(transactions);
            Assert.All(transactions, t => Assert.True(t.Amount == transactionAmount || t.Type == transactionType));
        }

        /// <summary>
        /// Verifies that querying transactions by Description and Type using AND 
        /// and excluding a specific Category using NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDescriptionAndTypeNotWithCategory_ShouldReturnCorrectEntries()
        {
            // Arrange
            var transactionDescription = TransactionSeeds.TransactionDianaDinner.Description;
            var transactionType = TransactionSeeds.TransactionDianaDinner.Type;
            var excludedCategoryId = CategorySeeds.CategoryFood.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.WithDescription(transactionDescription!)
                                     .WithType(transactionType)
                                     .NotWithCategory(excludedCategoryId));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                bool isDescriptionMatch = t.Description == transactionDescription;
                bool isTypeMatch = t.Type == transactionType;
                bool isCategoryMatch = t.CategoryId == excludedCategoryId;

                Assert.True(isDescriptionMatch && isTypeMatch && !isCategoryMatch);
            });
        }

        /// <summary>
        /// Verifies that querying transactions by partial Description or Amount using OR condition
        /// and excluding a specific ID using NOT condition works together.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDescriptionPartialMatchNotWithId_ShouldReturnCorrectEntries()
        {
            // Arrange
            var excludedTransactionId = TransactionSeeds.TransactionDianaDinner.Id;
            var queryObject = new TransactionQueryObject();

            // Act
            var transactions = await _unitOfWork.Repository<TransactionEntity, TransactionDto>()
                .GetAsync(queryObject.OrWithDescriptionPartialMatch("Dinner").NotWithId(excludedTransactionId));

            // Assert
            Assert.NotNull(transactions);
            Assert.All(transactions, t =>
            {
                Assert.Contains("Dinner", t.Description);
                Assert.NotEqual(excludedTransactionId, t.Id);
            });
        }

        #endregion
    }
}
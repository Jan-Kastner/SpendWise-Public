using SpendWise.BLL.Queries;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.BLL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Enums;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for transaction-related handlers focusing on relations.
    /// </summary>
    public class TransactionServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public TransactionServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        #region Summary transactions

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by amount equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching amount.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching amount greater than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotAmountGreaterThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching amount less than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by date equal.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByDateEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(date: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotDateEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDate: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by date from.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByDateFrom()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateFrom: new DateTime(2024, 7, 6, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by date to.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByDateTo()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateTo: new DateTime(2024, 7, 6, 22, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(description: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by description partial match.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(descriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescription: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching description partial match.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by without description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by with description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByWithDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by transaction type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(type: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching transaction type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>(); // Assuming no transactions of other types
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notType: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by category ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByCategoryId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(categoryId: expectedTransaction.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching category ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotCategoryId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notCategoryId: ExpectedTransactionServiceResults.TransactionJohnFoodSummary.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by without category.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByWithoutCategory()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDianaDinnerSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by with category.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByWithCategory()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByUserId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary,
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(userId: ExpectedUserServiceResults.UserJohnDoeList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotUserId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDianaDinnerSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notUserId: ExpectedUserServiceResults.UserJohnDoeList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerSummary,
                ExpectedTransactionServiceResults.TransactionJohnFoodSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(groupId: ExpectedGroupServiceResults.GroupFamilyList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by not matching group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionSummaryDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnTaxiSummary,
                ExpectedTransactionServiceResults.TransactionJohnTransportSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionsByCriteriaQuery(notGroupId: ExpectedGroupServiceResults.GroupFamilyList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        #endregion

        #region List Transactions

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by amount equal.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching amount.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by amount greater than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching amount greater than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotAmountGreaterThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by amount less than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching amount less than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by date equal.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByDateEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(date: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching date.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotDateEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDate: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by date from.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByDateFrom()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateFrom: new DateTime(2024, 7, 6, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by date to.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByDateTo()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateTo: new DateTime(2024, 7, 6, 22, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(description: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by description partial match.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(descriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescription: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching description partial match.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by without description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by with description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByWithDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by transaction type.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(type: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching transaction type.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>(); // Assuming no transactions of other types
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notType: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by category ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByCategoryId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(categoryId: expectedTransaction.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching category ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotCategoryId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notCategoryId: ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by without category.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByWithoutCategory()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by with category.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByWithCategory()
        {
            // Arrange
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList,
                ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }
        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching amount.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByUserId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
                {
                    ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList,
                    ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                    ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                    ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
                };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(userId: ExpectedUserServiceResults.UserJohnDoeList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching amount.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotUserId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notUserId: ExpectedUserServiceResults.UserJohnDoeList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
                {
                    ExpectedTransactionServiceResults.TransactionDinnerFamilyDianaList,
                    ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList
                };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(groupId: ExpectedGroupServiceResults.GroupFamilyList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by not matching group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionListDto>
                {
                    ExpectedTransactionServiceResults.TransactionJohnTaxiFriendsList,
                    ExpectedTransactionServiceResults.TransactionJohnTransportFriendsList,
                    ExpectedTransactionServiceResults.TransactionJohnTransportWorkList
                };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionListDto>>();
            var query = new GetTransactionsByCriteriaQuery(notGroupId: ExpectedGroupServiceResults.GroupFamilyList.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }
        #endregion

        #region Detail transactions

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by amount equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching amount.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountEqual: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotAmountGreaterThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountGreaterThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotAmountLessThan()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notAmountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDateEqual()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(date: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching date.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotDateEqual()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDate: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date from.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDateFrom()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateFrom: new DateTime(2024, 7, 6, 12, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date to.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDateTo()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(dateTo: new DateTime(2024, 7, 6, 22, 5, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(description: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by description partial match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(descriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescription: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching description partial match.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notDescriptionPartialMatch: "Grocer");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by without description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByWithoutDescription()
        {
            // Arrange
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by with description.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByWithDescription()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(withDescription: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by transaction type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(type: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching transaction type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotType()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>(); // Assuming no transactions of other types
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notType: TransactionType.Expense);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by category ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByCategoryId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(categoryId: expectedTransaction.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching category ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotCategoryId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notCategoryId: ExpectedTransactionServiceResults.TransactionJohnFoodDetail.CategoryId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by without category.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByWithoutCategory()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDianaDinnerDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by with category.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByWithCategory()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(withCategory: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by user ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByUserId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail,
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(userId: ExpectedUserServiceResults.UserJohnDoeSummary.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotUserId()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDianaDinnerDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notUserId: ExpectedUserServiceResults.UserJohnDoeSummary.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionDianaDinnerDetail,
                ExpectedTransactionServiceResults.TransactionJohnFoodDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(groupId: ExpectedGroupServiceResults.GroupFamilySummary.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by not matching group ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedTransactions = new List<TransactionDetailDto>
            {
                ExpectedTransactionServiceResults.TransactionJohnTaxiDetail,
                ExpectedTransactionServiceResults.TransactionJohnTransportDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(notGroupId: ExpectedGroupServiceResults.GroupFamilySummary.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedTransaction in expectedTransactions)
            {
                Assert.Contains(result, t => t.Id == expectedTransaction.Id);
            }
        }
        #endregion

        #region Summary transactions by ID

        /// <summary>
        /// Tests that the handler returns the correct transaction summary when queried by ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionSummary_WhenQueriedById()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodSummary;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionSummaryDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result);
        }
        #endregion

        #region List transactions by ID
        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedById()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnTransportWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionListDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["IsRead"]);
            Assert.Null(result.IsRead);
        }
        #endregion

        #region Detail transactions by ID
        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedById()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["Category", "Groups", "User"]);
        }
        #endregion

        #region Complex transaction tests

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by amount equal and not matching amount equal.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountEqualAndNotAmountEqualAndDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountEqual: 100.0m, notAmountEqual: 50.0m, description: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by amount greater than and not matching amount less than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDescriptionPartialMatchAndNotAmountGreaterThan()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionDianaDinnerDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(descriptionPartialMatch: "Dinner", notAmountGreaterThan: 100.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date and not matching description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountGreaterThanAndDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountGreaterThan: 50.0m, description: "Groceries");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date and not matching description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByAmountLessThanAndDescriptionPartialMatch()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnTaxiDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(amountLessThan: 50.0m, descriptionPartialMatch: "Taxi");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date and not matching description.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByDateAndNotDescription()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(date: new DateTime(2024, 7, 5, 12, 5, 0, DateTimeKind.Utc), notDescription: "Taxi ride home");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by date from and not matching description partial match.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByGroupIdAndUserIdAndCategoryIdAndAmountLessThan()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnTaxiDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionsByCriteriaQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionsByCriteriaQuery(groupId: GroupSeeds.GroupFriends.Id, userId: UserSeeds.UserJohnDoe.Id, categoryId: CategorySeeds.CategoryTransport.Id, amountLessThan: 50.0m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedTransaction, result.FirstOrDefault(), propertiesToIgnore: ["Category", "Groups", "User"]);
        }
        #endregion

        #region Related entities

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by ID and user loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionList_WhenQueriedByIdAndCategoryLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionListDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeCategory: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["IsRead"]);
            Assert.Null(result.IsRead);
            Assert.NotNull(result.Category);
            DeepAssert.Equal(expectedTransaction.Category, result.Category);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction list when queried by ID and user loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByIdAndCategoryLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeCategory: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["Groups", "User"]);
            Assert.NotNull(result.Category);
            DeepAssert.Equal(expectedTransaction.Category, result.Category);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by ID and user loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByIdAndUserLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeUser: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["Groups", "Category"]);
            Assert.NotNull(result.User);
            DeepAssert.Equal(expectedTransaction.User, result.User);
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by ID and group loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByIdAndGroupLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeGroups: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["User", "Category", "GroupParticipants"]);
            Assert.NotNull(result.Groups);
            Assert.NotEmpty(result.Groups);
            foreach (var expectedGroup in expectedTransaction.Groups)
            {
                Assert.Contains(result.Groups, g => g.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by ID and user, category and group loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByIdAndUserCategoryGroupLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnFoodDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeUser: true, includeCategory: true, includeGroups: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            DeepAssert.Equal(expectedTransaction, result, propertiesToIgnore: ["GroupParticipants"]);
            Assert.NotNull(result.User);
            DeepAssert.Equal(expectedTransaction.User, result.User);
            Assert.NotNull(result.Category);
            DeepAssert.Equal(expectedTransaction.Category, result.Category);
            Assert.NotNull(result.Groups);
            Assert.NotEmpty(result.Groups);
            foreach (var expectedGroup in expectedTransaction.Groups)
            {
                Assert.Contains(result.Groups, g => g.Id == expectedGroup.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct transaction detail when queried by ID and user, category and group participants loaded.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnTransactionDetail_WhenQueriedByIdAndUserCategoryGroupParticipantsLoaded()
        {
            // Arrange
            var expectedTransaction = ExpectedTransactionServiceResults.TransactionJohnTransportDetail;
            var handler = _serviceProvider.GetRequiredService<IGetTransactionByIdQueryHandler<TransactionDetailDto>>();
            var query = new GetTransactionByIdQuery(id: expectedTransaction.Id, includeUser: true, includeCategory: true, includeParticipants: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedTransaction, result);
            Assert.NotNull(result.User);
            DeepAssert.Equal(expectedTransaction.User, result.User);
            Assert.NotNull(result.Category);
            DeepAssert.Equal(expectedTransaction.Category, result.Category);
            Assert.NotNull(result.Groups);
            Assert.NotEmpty(result.Groups);
            foreach (var expectedGroup in expectedTransaction.Groups)
            {
                Assert.Contains(result.Groups, g => g.Id == expectedGroup.Id);
                var g = result.Groups.First(x => x.Id == expectedGroup.Id);
                Assert.NotNull(g.GroupParticipants);
                Assert.NotEmpty(g.GroupParticipants);
                foreach (var expectedParticipant in expectedGroup.GroupParticipants)
                {
                    Assert.Contains(g.GroupParticipants, p => p.Id == expectedParticipant.Id);
                }
            }
        }

        #endregion

    }
}
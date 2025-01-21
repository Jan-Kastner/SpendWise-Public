using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for limit-related handlers focusing on relations.
    /// </summary>
    public class LimitServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="LimitServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public LimitServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        #region Summary limits

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by amount equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(amountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by not matching amount.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedLimits = new List<LimitSummaryDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilySummary,
                ExpectedLimitServiceResults.LimitDianaFamilySummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(amountGreaterThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by not amount greater than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNotAmountGreaterThan()
        {
            // Arrange
            var expectedLimits = new List<LimitSummaryDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilySummary,
                ExpectedLimitServiceResults.LimitDianaFamilySummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmountGreaterThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitCharlieFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(amountLessThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by not amount less than.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNotAmountLessThan()
        {
            // Arrange
            var expectedLimits = new List<LimitSummaryDto>
            {
                ExpectedLimitServiceResults.LimitDianaFamilySummary,
                ExpectedLimitServiceResults.LimitJohnWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmountLessThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNoticeType()
        {
            // Arrange
            var expectedLimits = new List<LimitSummaryDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilySummary,
                ExpectedLimitServiceResults.LimitJohnWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by not matching notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNotNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(notNoticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by group user ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByGroupUserId()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilySummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(groupUserId: expectedLimit.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by not matching group user ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedByNotGroupUserId()
        {
            // Arrange
            var expectedLimits = new List<LimitSummaryDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilySummary,
                ExpectedLimitServiceResults.LimitJohnWorkSummary
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitsByCriteriaQuery(notGroupUserId: ExpectedLimitServiceResults.LimitDianaFamilyDetail.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }
        #endregion

        #region List limits

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by amount equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(amountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by not matching amount.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedLimits = new List<LimitListDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyList,
                ExpectedLimitServiceResults.LimitDianaFamilyList
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(amountGreaterThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitCharlieFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(amountLessThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByNoticeType()
        {
            // Arrange
            var expectedLimits = new List<LimitListDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyList,
                ExpectedLimitServiceResults.LimitJohnWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by not matching notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByNotNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(notNoticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by group user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByGroupUserId()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilyList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(groupUserId: expectedLimit.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by not matching group user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedByNotGroupUserId()
        {
            // Arrange
            var expectedLimits = new List<LimitListDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyList,
                ExpectedLimitServiceResults.LimitJohnWorkList
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitListDto>>();
            var query = new GetLimitsByCriteriaQuery(notGroupUserId: ExpectedLimitServiceResults.LimitDianaFamilyDetail.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        #endregion

        #region Detail limits

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount equal.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountEqual()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by not matching amount.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByNotAmountEqual()
        {
            // Arrange
            var expectedLimits = new List<LimitDetailDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyDetail,
                ExpectedLimitServiceResults.LimitDianaFamilyDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(notAmountEqual: 2000m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount greater than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountGreaterThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountGreaterThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount less than.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountLessThan()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitCharlieFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountLessThan: 1500m);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByNoticeType()
        {
            // Arrange
            var expectedLimits = new List<LimitDetailDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyDetail,
                ExpectedLimitServiceResults.LimitJohnWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by not matching notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByNotNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(notNoticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by group user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByGroupUserId()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitDianaFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(groupUserId: expectedLimit.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by not matching group user ID.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByNotGroupUserId()
        {
            // Arrange
            var expectedLimits = new List<LimitDetailDto>
            {
                ExpectedLimitServiceResults.LimitCharlieFamilyDetail,
                ExpectedLimitServiceResults.LimitJohnWorkDetail
            };
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(notGroupUserId: ExpectedLimitServiceResults.LimitDianaFamilyDetail.GroupUserId);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedLimit in expectedLimits)
            {
                Assert.Contains(result, l => l.Id == expectedLimit.Id);
            }
        }
        #endregion

        #region Summary limits by ID

        /// <summary>
        /// Tests that the handler returns the correct limit summary when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitSummary_WhenQueriedById()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkSummary;
            var handler = _serviceProvider.GetRequiredService<IGetLimitByIdQueryHandler<LimitSummaryDto>>();
            var query = new GetLimitByIdQuery(expectedLimit.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedLimit, result);
        }

        #endregion

        #region List limits by ID

        /// <summary>
        /// Tests that the handler returns the correct limit list when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitList_WhenQueriedById()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkList;
            var handler = _serviceProvider.GetRequiredService<IGetLimitByIdQueryHandler<LimitListDto>>();
            var query = new GetLimitByIdQuery(expectedLimit.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedLimit, result);
        }

        #endregion

        #region Detail limits by ID

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by ID.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedById()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitByIdQueryHandler<LimitDetailDto>>();
            var query = new GetLimitByIdQuery(expectedLimit.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            DeepAssert.Equal(expectedLimit, result);
        }

        #endregion

        #region Detail limits by multiple queries

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount equal and notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountEqualAndNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountEqual: 2000m, noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount greater than and notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountGreaterThanAndNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitJohnWorkDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountGreaterThan: 1500m, noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        /// <summary>
        /// Tests that the handler returns the correct limit detail when queried by amount less than and notice type.
        /// </summary>
        [Fact]
        public async Task Handle_ShouldReturnLimitDetail_WhenQueriedByAmountLessThanAndNoticeType()
        {
            // Arrange
            var expectedLimit = ExpectedLimitServiceResults.LimitCharlieFamilyDetail;
            var handler = _serviceProvider.GetRequiredService<IGetLimitsByCriteriaQueryHandler<LimitDetailDto>>();
            var query = new GetLimitsByCriteriaQuery(amountLessThan: 1500m, noticeType: NoticeType.InApp);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedLimit, result.FirstOrDefault());
        }

        #endregion
    }
}

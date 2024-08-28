using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="LimitEntity"/> entity.
    /// </summary>
    public class LimitEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper used to log test results.</param>
        public LimitEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Contains tests that cover the basic Create, Read, Update, and Delete (CRUD) operations 
        /// for the <see cref="LimitEntity"/> in the database context.
        /// These tests ensure that the application can correctly persist and retrieve limits, as well as handle updates and deletions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the retrieval of a <see cref="LimitEntity"/> by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchLimitById_ReturnsExpectedLimit()
        {
            // Arrange
            var expectedLimit = LimitSeeds.LimitCharlieFamily;
            var limitIdToFetch = expectedLimit.Id;

            // Act
            var actualLimit = await SpendWiseDbContextSUT.Limits
                .Where(l => l.Id == limitIdToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(expectedLimit, actualLimit);
        }

        [Fact]
        /// <summary>
        /// Tests the addition of a valid <see cref="LimitEntity"/> to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddLimit_ValidLimit_SuccessfullyPersists()
        {
            // Arrange
            var limitToAdd = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id,
                Amount = 100.00m,
                NoticeType = 1
            };

            // Act
            SpendWiseDbContextSUT.Limits.Add(limitToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualLimit = await SpendWiseDbContextSUT.Limits.FindAsync(limitToAdd.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(limitToAdd, actualLimit);
        }

        [Fact]
        /// <summary>
        /// Tests the update of an existing <see cref="LimitEntity"/> in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateLimit_ExistingLimit_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingLimit = await SpendWiseDbContextSUT.Limits
                .AsNoTracking()
                .FirstAsync(l => l.Id == LimitSeeds.LimitCharlieFamily.Id);

            var updatedLimit = existingLimit with
            {
                Amount = 15000.00m
            };

            // Act
            SpendWiseDbContextSUT.Limits.Update(updatedLimit);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualLimit = await dbx.Limits
                .SingleAsync(l => l.Id == existingLimit.Id);

            Assert.NotNull(actualLimit);
            Assert.Equal(updatedLimit.Amount, actualLimit.Amount);
            DeepAssert.Equal(updatedLimit, actualLimit);
        }

        [Fact]
        /// <summary>
        /// Tests the deletion of an existing <see cref="LimitEntity"/> from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteLimit_ExistingLimit_SuccessfullyRemovesLimit()
        {
            // Arrange
            var limitToDelete = await SpendWiseDbContextSUT.Limits
                .AsNoTracking()
                .FirstAsync(l => l.Id == LimitSeeds.LimitCharlieFamily.Id);

            var groupUserId = limitToDelete.GroupUserId;

            // Ensure the limit exists before deletion
            Assert.True(await SpendWiseDbContextSUT.Limits.AnyAsync(l => l.Id == limitToDelete.Id));

            // Ensure the associated GroupUser exists before deletion
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == groupUserId));

            // Act
            SpendWiseDbContextSUT.Limits.Remove(limitToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Limits.AnyAsync(l => l.Id == limitToDelete.Id));
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == groupUserId));
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Contains tests focused on handling error scenarios in the `LimitEntity` CRUD operations.
        /// These tests verify that the database context correctly throws exceptions when invalid data is persisted,
        /// ensuring that integrity constraints and validation rules are enforced.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the addition of a `LimitEntity` with a duplicate `GroupUserId`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddLimit_DuplicateGroupUserId_ThrowsDbUpdateException()
        {
            // Arrange
            var duplicateLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserCharlieInFamily.Id,
                Amount = 150.00m,
                NoticeType = 2
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(duplicateLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Tests the addition of a `LimitEntity` with a negative amount.
        /// </summary>
        /// <remarks>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddLimit_NegativeAmount_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id,
                Amount = -100.00m,
                NoticeType = 1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Tests the addition of a `LimitEntity` with an invalid `NoticeType`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddLimit_InvalidNoticeType_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id,
                Amount = 100.00m,
                NoticeType = 999
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Tests the addition of a `LimitEntity` with an invalid `GroupUserId`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddLimit_InvalidUserId_ThrowsDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = Guid.NewGuid(),
                Amount = 100.00m,
                NoticeType = 1
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Tests the update of an existing `LimitEntity` with an invalid amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateLimit_InvalidAmount_ThrowsDbUpdateException()
        {
            // Arrange
            var existingLimit = await SpendWiseDbContextSUT.Limits
                .AsNoTracking()
                .FirstAsync(l => l.Id == LimitSeeds.LimitCharlieFamily.Id);

            var invalidLimit = existingLimit with
            {
                Amount = -1.00m,
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Limits.Update(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Contains tests focused on retrieving `LimitEntity` data from the database.
        /// These tests ensure that specific queries return the expected results and that
        /// the data is correctly filtered based on certain criteria.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the retrieval of limits by `GroupUserId`.
        /// </summary>
        /// <remarks>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchLimitByGroupUserId_ReturnsExpectedLimits()
        {
            // Arrange
            var expectedGroupUser = GroupUserSeeds.GroupUserCharlieInFamily;

            // Act
            var actualLimits = await SpendWiseDbContextSUT.Limits
                .Where(l => l.GroupUserId == expectedGroupUser.Id)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(actualLimits);
            foreach (var limit in actualLimits)
            {
                Assert.Equal(expectedGroupUser.Id, limit.GroupUserId);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Contains tests that ensure the consistency of the database after certain operations,
        /// such as deletions. These tests verify that integrity constraints are maintained and that
        /// related entities are handled correctly.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the deletion of a `LimitEntity` and checks the integrity constraints afterward.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteLimit_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var existingLimitId = LimitSeeds.LimitCharlieFamily.Id;
            var expectedGroupUserId = LimitSeeds.LimitCharlieFamily.GroupUserId;

            // Act
            var limitToDelete = await SpendWiseDbContextSUT.Limits
                .Where(l => l.Id == existingLimitId)
                .SingleOrDefaultAsync();

            Assert.NotNull(limitToDelete);

            SpendWiseDbContextSUT.Limits.Remove(limitToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            // Check if GroupUser still exists
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == expectedGroupUserId));

            // Check that the deleted limit is no longer present
            Assert.False(await SpendWiseDbContextSUT.Limits.AnyAsync(l => l.Id == existingLimitId));
        }

        #endregion

    }
}
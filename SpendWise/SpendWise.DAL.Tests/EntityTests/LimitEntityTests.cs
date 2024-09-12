using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

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
        /// Tests the retrieval of a <see cref="LimitEntity"/> by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchLimitById_ShouldReturnExpectedLimit()
        {
            // Arrange
            var expectedLimit = LimitSeeds.LimitCharlieFamily;
            var limitId = expectedLimit.Id;

            // Act
            var actualLimit = await SpendWiseDbContextSUT.Limits
                .SingleOrDefaultAsync(l => l.Id == limitId);

            // Assert
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(expectedLimit, actualLimit);
        }

        /// <summary>
        /// Tests the addition of a valid <see cref="LimitEntity"/> to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_ShouldPersistValidLimit()
        {
            // Arrange
            var newLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id,
                Amount = 100.00m,
                NoticeType = NoticeType.InApp
            };

            // Act
            SpendWiseDbContextSUT.Limits.Add(newLimit);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualLimit = await SpendWiseDbContextSUT.Limits.FindAsync(newLimit.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(newLimit, actualLimit);
        }

        /// <summary>
        /// Tests the update of an existing <see cref="LimitEntity"/> in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_ShouldPersistChanges()
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

        /// <summary>
        /// Tests the deletion of an existing <see cref="LimitEntity"/> from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_ShouldRemoveLimit()
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
        /// Tests the addition of a `LimitEntity` with a duplicate `GroupUserId`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithDuplicateGroupUserId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var duplicateLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserCharlieInFamily.Id,
                Amount = 150.00m,
                NoticeType = NoticeType.SMS
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(duplicateLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests the addition of a `LimitEntity` with a negative amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithNegativeAmount_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserBobInFamily.Id,
                Amount = -100.00m,
                NoticeType = NoticeType.InApp
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests the addition of a `LimitEntity` with an invalid `GroupUserId`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithInvalidGroupUserId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = Guid.NewGuid(),
                Amount = 100.00m,
                NoticeType = NoticeType.InApp
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await SpendWiseDbContextSUT.Limits.AddAsync(invalidLimit);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Tests the update of an existing `LimitEntity` with an invalid amount.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_WithInvalidAmount_ShouldThrowDbUpdateException()
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
        /// Tests the retrieval of limits by `GroupUserId`.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchLimitsByGroupUserId_ShouldReturnExpectedLimits()
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
        /// Tests the deletion of a `LimitEntity` and checks the integrity constraints afterward.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_ShouldMaintainIntegrityConstraints()
        {
            // Arrange
            var existingLimitId = LimitSeeds.LimitCharlieFamily.Id;
            var expectedGroupUserId = LimitSeeds.LimitCharlieFamily.GroupUserId;

            // Act
            var limitToDelete = await SpendWiseDbContextSUT.Limits
                .SingleOrDefaultAsync(l => l.Id == existingLimitId);

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
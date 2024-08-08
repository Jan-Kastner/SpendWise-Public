using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;

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

        /// <summary>
        /// Tests that the limit is correctly retrieved by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetLimit_ById_ReturnsCorrectLimit()
        {
            // Arrange
            var existingLimitId = LimitSeeds.LimitAdminFamily.Id;
            var expectedLimit = LimitSeeds.LimitAdminFamily;

            // Act
            var limit = await SpendWiseDbContextSUT.Limits
                .Where(l => l.Id == existingLimitId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(limit);
            DeepAssert.Equal(expectedLimit, limit);
        }

        /// <summary>
        /// Tests that a valid limit is added to the database and persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WhenValidLimitIsAdded_LimitIsPersisted()
        {
            // Arrange
            var limit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
                Amount = 100.00m,
                NoticeType = 1,
                GroupUser = null!
            };

            // Act
            SpendWiseDbContextSUT.Limits.Add(limit);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var actualLimit = await SpendWiseDbContextSUT.Limits.FindAsync(limit.Id);
            Assert.NotNull(actualLimit);
            DeepAssert.Equal(limit, actualLimit);
        }

        /// <summary>
        /// Tests that adding a limit with a duplicate group user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithDuplicateGroupUserId_ThrowsException()
        {
            // Arrange
            var duplicateLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFriends.Id, // Same GroupUserId as in seeded data
                Amount = 150.00m,
                NoticeType = 2,
                GroupUser = null!
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
        /// Tests that adding a limit with a negative amount throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithNegativeAmount_ThrowsException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
                Amount = -100.00m, // Invalid negative amount
                NoticeType = 1,
                GroupUser = null!
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
        /// Tests that adding a limit with an invalid notice type throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithInvalidNoticeType_ThrowsException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = GroupUserSeeds.GroupUserJohnDoeInFamily.Id,
                Amount = 100.00m,
                NoticeType = 999,
                GroupUser = null!
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
        /// Tests that adding a limit with a non-existing group user ID throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddLimit_WithInvalidUserId_ThrowsException()
        {
            // Arrange
            var invalidLimit = new LimitEntity
            {
                Id = Guid.NewGuid(),
                GroupUserId = Guid.NewGuid(), // Invalid user ID
                Amount = 100.00m,
                NoticeType = 1,
                GroupUser = null!
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
        /// Tests that changes to an existing limit are persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_WhenLimitIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var existingLimit = await SpendWiseDbContextSUT.Limits
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(l => l.Id == LimitSeeds.LimitAdminFamily.Id);

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
            // Add other assertions as needed
            DeepAssert.Equal(updatedLimit, actualLimit);
        }

        /// <summary>
        /// Tests that a limit is removed from the database when deleted, and that the associated group user is not deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLimit_WhenLimitIsDeleted_LimitIsRemoved_AndGroupUserIsNotDeleted()
        {
            // Arrange
            var baseEntity = LimitSeeds.LimitAdminFamily;
            var groupUserId = baseEntity.GroupUserId;

            // Ensure the limit exists before deletion
            Assert.True(await SpendWiseDbContextSUT.Limits.AnyAsync(l => l.Id == baseEntity.Id));

            // Ensure the associated GroupUser exists before deletion
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == groupUserId));

            // Act
            SpendWiseDbContextSUT.Limits.Remove(baseEntity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            // Check that the limit has been deleted
            Assert.False(await SpendWiseDbContextSUT.Limits.AnyAsync(l => l.Id == baseEntity.Id));

            // Check that the associated GroupUser has not been deleted
            Assert.True(await SpendWiseDbContextSUT.GroupUsers.AnyAsync(gu => gu.Id == groupUserId));
        }

        /// <summary>
        /// Tests that the total amount of limits for a user group is correctly summed up.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTotalAmount_ForLimits_ReturnsCorrectSum()
        {
            // Arrange
            var userGroupId = GroupUserSeeds.GroupUserAdminInFamily.Id;

            // Act
            var totalAmount = await SpendWiseDbContextSUT.Limits
                .Where(l => l.GroupUserId == userGroupId)
                .SumAsync(l => l.Amount);

            // Assert
            var expectedTotalAmount = LimitSeeds.LimitAdminFamily.Amount;
            Assert.Equal(expectedTotalAmount, totalAmount);
        }

        /// <summary>
        /// Tests that updating a limit with an invalid amount throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateLimit_WithInvalidAmount_ThrowsException()
        {
            // Arrange
            var existingLimit = await SpendWiseDbContextSUT.Limits
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(l => l.Id == LimitSeeds.LimitAdminFamily.Id);

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
    }
}

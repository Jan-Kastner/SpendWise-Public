using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;

public class TransactionGroupUserQueryObjectTests : UnitOfWorkTestsBase
{
    public TransactionGroupUserQueryObjectTests(ITestOutputHelper output) : base(output)
    {
    }

    #region AND Tests

    /// <summary>
    /// Verifies that querying a transaction group user by its ID 
    /// returns the correct entry from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithId_ReturnsCorrectEntry()
    {
        // Arrange
        var existingEntry = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.WithId(existingEntry.Id));

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(existingEntry.Id, result.First().Id);
    }

    /// <summary>
    /// Verifies that querying transaction group users by transaction ID 
    /// returns all correct entries associated with that transaction.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithTransactionId_ReturnsCorrectEntries()
    {
        // Arrange
        var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.WithTransactionId(transactionId));

        // Assert
        Assert.NotNull(result);
        Assert.All(result, entry => Assert.Equal(transactionId, entry.TransactionId));
    }

    /// <summary>
    /// Verifies that querying transaction group users by group user ID 
    /// returns all correct entries associated with that group user.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithGroupUserId_ReturnsCorrectEntries()
    {
        // Arrange
        var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.WithGroupUserId(groupUserId));

        // Assert
        Assert.NotNull(result);
        Assert.All(result, entry => Assert.Equal(groupUserId, entry.GroupUserId));
    }

    #endregion

    #region OR Tests

    /// <summary>
    /// Verifies that querying transaction group users by multiple IDs 
    /// returns the correct entries that match any of the provided IDs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithId_ReturnsCorrectEntries()
    {
        // Arrange
        var existingEntry1 = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
        var existingEntry2 = TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.OrWithId(existingEntry1.Id).OrWithId(existingEntry2.Id));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.Id == existingEntry1.Id);
        Assert.Contains(result, e => e.Id == existingEntry2.Id);
    }

    /// <summary>
    /// Verifies that querying transaction group users by multiple transaction IDs 
    /// returns the correct entries that match any of the provided transaction IDs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithTransactionId_ReturnsCorrectEntries()
    {
        // Arrange
        var transactionId1 = TransactionSeeds.TransactionDianaDinner.Id;
        var transactionId2 = TransactionSeeds.TransactionJohnFood.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.OrWithTransactionId(transactionId1).OrWithTransactionId(transactionId2));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.TransactionId == transactionId1);
        Assert.Contains(result, e => e.TransactionId == transactionId2);
    }

    /// <summary>
    /// Verifies that querying transaction group users by multiple group user IDs 
    /// returns the correct entries that match any of the provided group user IDs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithGroupUserId_ReturnsCorrectEntries()
    {
        // Arrange
        var groupUserId1 = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var groupUserId2 = GroupUserSeeds.GroupUserJohnInFriends.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.OrWithGroupUserId(groupUserId1).OrWithGroupUserId(groupUserId2));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.GroupUserId == groupUserId1);
        Assert.Contains(result, e => e.GroupUserId == groupUserId2);
    }

    #endregion

    #region NOT Tests

    /// <summary>
    /// Verifies that querying transaction group users by ID excludes the entry with the specified ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithId_ReturnsEntriesExcludingId()
    {
        // Arrange
        var existingEntry = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.NotWithId(existingEntry.Id));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.Id == existingEntry.Id);
    }

    /// <summary>
    /// Verifies that querying transaction group users by transaction ID excludes entries with the specified transaction ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithTransactionId_ReturnsEntriesExcludingTransactionId()
    {
        // Arrange
        var transactionId = TransactionSeeds.TransactionDianaDinner.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.NotWithTransactionId(transactionId));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.TransactionId == transactionId);
    }

    /// <summary>
    /// Verifies that querying transaction group users by group user ID excludes entries with the specified group user ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithGroupUserId_ReturnsEntriesExcludingGroupUserId()
    {
        // Arrange
        var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var queryObject = new TransactionGroupUserQueryObject();

        // Act
        var result = await _unitOfWork.Repository<TransactionGroupUserEntity, TransactionGroupUserDto>()
            .GetAsync(queryObject.NotWithGroupUserId(groupUserId));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.GroupUserId == groupUserId);
    }

    #endregion
}



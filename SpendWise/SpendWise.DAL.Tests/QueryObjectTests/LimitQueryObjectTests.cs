using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;

public class LimitQueryObjectTests : UnitOfWorkTestsBase
{
    public LimitQueryObjectTests(ITestOutputHelper output) : base(output)
    {
    }

    #region AND Tests

    /// <summary>
    /// Verifies that querying a limit by its ID 
    /// returns the correct entry from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithId_ReturnsCorrectEntry()
    {
        // Arrange
        var existingEntry = LimitSeeds.LimitDianaFamily;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.WithId(existingEntry.Id));

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(existingEntry.Id, result.First().Id);
    }

    /// <summary>
    /// Verifies that querying limits by group user ID 
    /// returns all correct entries associated with that group user.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithGroupUserId_ReturnsCorrectEntries()
    {
        // Arrange
        var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.WithGroupUserId(groupUserId));

        // Assert
        Assert.NotNull(result);
        Assert.All(result, entry => Assert.Equal(groupUserId, entry.GroupUserId));
    }

    /// <summary>
    /// Verifies that querying limits by amount 
    /// returns all correct entries associated with that amount.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithAmount_ReturnsCorrectEntries()
    {
        // Arrange
        var amount = LimitSeeds.LimitDianaFamily.Amount;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.WithAmount(amount));

        // Assert
        Assert.NotNull(result);
        Assert.All(result, entry => Assert.Equal(amount, entry.Amount));
    }

    /// <summary>
    /// Verifies that querying limits by notice type 
    /// returns all correct entries associated with that notice type.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_WithNoticeType_ReturnsCorrectEntries()
    {
        // Arrange
        var noticeType = LimitSeeds.LimitDianaFamily.NoticeType;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.WithNoticeType(noticeType));

        // Assert
        Assert.NotNull(result);
        Assert.All(result, entry => Assert.Equal(noticeType, entry.NoticeType));
    }

    #endregion

    #region OR Tests

    /// <summary>
    /// Verifies that querying limits by multiple IDs 
    /// returns the correct entries that match any of the provided IDs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithId_ReturnsCorrectEntries()
    {
        // Arrange
        var existingEntry1 = LimitSeeds.LimitCharlieFamily;
        var existingEntry2 = LimitSeeds.LimitDianaFamily;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.OrWithId(existingEntry1.Id).OrWithId(existingEntry2.Id));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.Id == existingEntry1.Id);
        Assert.Contains(result, e => e.Id == existingEntry2.Id);
    }

    /// <summary>
    /// Verifies that querying limits by multiple group user IDs 
    /// returns the correct entries that match any of the provided group user IDs.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithGroupUserId_ReturnsCorrectEntries()
    {
        // Arrange
        var groupUserId1 = GroupUserSeeds.GroupUserCharlieInFamily.Id;
        var groupUserId2 = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.OrWithGroupUserId(groupUserId1).OrWithGroupUserId(groupUserId2));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.GroupUserId == groupUserId1);
        Assert.Contains(result, e => e.GroupUserId == groupUserId2);
    }

    /// <summary>
    /// Verifies that querying limits by multiple amounts 
    /// returns the correct entries that match any of the provided amounts.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithAmount_ReturnsCorrectEntries()
    {
        // Arrange
        var amount1 = LimitSeeds.LimitCharlieFamily.Amount;
        var amount2 = LimitSeeds.LimitDianaFamily.Amount;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.OrWithAmount(amount1).OrWithAmount(amount2));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.Amount == amount1);
        Assert.Contains(result, e => e.Amount == amount2);
    }

    /// <summary>
    /// Verifies that querying limits by multiple notice types 
    /// returns the correct entries that match any of the provided notice types.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_OrWithNoticeType_ReturnsCorrectEntries()
    {
        // Arrange
        var noticeType1 = LimitSeeds.LimitCharlieFamily.NoticeType;
        var noticeType2 = LimitSeeds.LimitDianaFamily.NoticeType;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.OrWithNoticeType(noticeType1).OrWithNoticeType(noticeType2));

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, e => e.NoticeType == noticeType1);
        Assert.Contains(result, e => e.NoticeType == noticeType2);
    }

    #endregion

    #region NOT Tests

    /// <summary>
    /// Verifies that querying limits by ID excludes the entry with the specified ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithId_ReturnsEntriesExcludingId()
    {
        // Arrange
        var existingEntry = LimitSeeds.LimitDianaFamily;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.NotWithId(existingEntry.Id));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.Id == existingEntry.Id);
    }

    /// <summary>
    /// Verifies that querying limits by group user ID excludes entries with the specified group user ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithGroupUserId_ReturnsEntriesExcludingGroupUserId()
    {
        // Arrange
        var groupUserId = GroupUserSeeds.GroupUserDianaInFamily.Id;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.NotWithGroupUserId(groupUserId));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.GroupUserId == groupUserId);
    }

    /// <summary>
    /// Verifies that querying limits by amount excludes entries with the specified amount.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithAmount_ReturnsEntriesExcludingAmount()
    {
        // Arrange
        var amount = LimitSeeds.LimitDianaFamily.Amount;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.NotWithAmount(amount));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.Amount == amount);
    }

    /// <summary>
    /// Verifies that querying limits by notice type excludes entries with the specified notice type.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task QueryObject_NotWithNoticeType_ReturnsEntriesExcludingNoticeType()
    {
        // Arrange
        var noticeType = LimitSeeds.LimitDianaFamily.NoticeType;
        var queryObject = new LimitQueryObject();

        // Act
        var result = await _unitOfWork.Repository<LimitEntity, LimitDto>()
            .GetAsync(queryObject.NotWithNoticeType(noticeType));

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, e => e.NoticeType == noticeType);
    }

    #endregion
}

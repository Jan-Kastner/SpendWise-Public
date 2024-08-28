using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for the <see cref="InvitationEntity"/> entity.
    /// </summary>
    public class InvitationEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public InvitationEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        /// <summary>
        /// Tests for basic CRUD (Create, Read, Update, Delete) operations involving the <see cref="InvitationEntity"/>.
        /// This region includes tests that validate the correct behavior of these operations in the database.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that fetching an invitation by its ID returns the expected invitation entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitationById_ReturnsExpectedInvitation()
        {
            // Arrange
            var expectedInvitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var invitationIdToFetch = expectedInvitation.Id;

            // Act
            var actualInvitation = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.Id == invitationIdToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualInvitation);
            DeepAssert.Equal(expectedInvitation, actualInvitation);
        }

        [Fact]
        /// <summary>
        /// Tests the addition of a valid invitation entity to the database and verifies it is successfully persisted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitation_ValidInvitation_SuccessfullyPersists()
        {
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            // Arrange
            var invitationToAdd = new InvitationEntity
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserJohnDoe.Id,
                ReceiverId = UserSeeds.UserAliceSmith.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = baseTime,
                ResponseDate = null,
                IsAccepted = null,
                Sender = null!,
                Receiver = null!,
                Group = null!
            };

            // Act
            SpendWiseDbContextSUT.Invitations.Add(invitationToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualInvitation = await dbx.Invitations.FindAsync(invitationToAdd.Id);
            Assert.NotNull(actualInvitation);
            DeepAssert.Equal(invitationToAdd, actualInvitation);
        }

        [Fact]
        /// <summary>
        /// Tests the updating of an existing invitation entity and verifies that the changes are correctly persisted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_ExistingInvitation_SuccessfullyPersistsChanges()
        {
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var updatedInvitation = existingInvitation with
            {
                ResponseDate = baseTime,
                IsAccepted = true
            };

            // Act
            SpendWiseDbContextSUT.Invitations.Update(updatedInvitation);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualInvitation = await dbx.Invitations
                .SingleAsync(i => i.Id == updatedInvitation.Id);

            Assert.NotNull(actualInvitation);
            Assert.Equal(updatedInvitation.ResponseDate, actualInvitation.ResponseDate);
            Assert.Equal(updatedInvitation.IsAccepted, actualInvitation.IsAccepted);
            DeepAssert.Equal(updatedInvitation, actualInvitation);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing invitation entity successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_ExistingInvitation_SuccessfullyRemovesInvitation()
        {
            // Arrange
            var invitationToDelete = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            Assert.NotNull(invitationToDelete);
            Assert.True(await SpendWiseDbContextSUT.Invitations.AnyAsync(i => i.Id == invitationToDelete.Id));

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Invitations.AnyAsync(i => i.Id == invitationToDelete.Id));
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Contains tests for validating the error handling mechanisms when performing update operations on the <see cref="InvitationEntity"/>.
        /// These tests ensure that invalid data triggers the appropriate exceptions, thereby maintaining the integrity of the application's data.
        /// </summary>

        [Fact]
        /// <summary>
        /// Validates that updating an invitation with an invalid SenderId results in a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_InvalidSenderId_ThrowsDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                SenderId = Guid.Empty // Invalid SenderId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Ensures that updating an invitation with an invalid ReceiverId raises a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_InvalidReceiverId_ThrowsDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                ReceiverId = Guid.Empty // Invalid ReceiverId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Confirms that updating an invitation with an invalid GroupId triggers a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_InvalidGroupId_ThrowsDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                GroupId = Guid.Empty // Invalid GroupId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        [Fact]
        /// <summary>
        /// Verifies that updating an invitation with an invalid ResponseDate (e.g., <see cref="DateTime.MinValue"/>) causes a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateInvitation_InvalidResponseDate_ThrowsDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                ResponseDate = DateTime.MinValue // Invalid ResponseDate
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Contains tests focused on retrieving <see cref="InvitationEntity"/> data from the database.
        /// These tests ensure that the data retrieval logic functions as expected, particularly when filtering by different properties.
        /// </summary>

        [Fact]
        /// <summary>
        /// Validates that invitations can be correctly fetched based on their acceptance status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitationsByStatus_ReturnsExpectedInvitations()
        {
            // Arrange
            var status = true; // Accepted invitations

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.IsAccepted == status)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(status, i.IsAccepted));
        }

        [Fact]
        /// <summary>
        /// Ensures that invitations sent by a specific user can be accurately retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitationsBySenderId_ReturnsExpectedInvitations()
        {
            // Arrange
            var senderIdToFetch = UserSeeds.UserJohnDoe.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.SenderId == senderIdToFetch)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(senderIdToFetch, i.SenderId));
        }

        [Fact]
        /// <summary>
        /// Confirms that invitations received by a specific user can be accurately retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitationsByReceiverId_ReturnsExpectedInvitations()
        {
            // Arrange
            var receiverIdToFetch = UserSeeds.UserDianaGreen.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.ReceiverId == receiverIdToFetch)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(receiverIdToFetch, i.ReceiverId));
        }

        #endregion

        #region Related Entities Handling Tests

        [Fact]
        /// <summary>
        /// Validates that the navigation properties of an invitation entity are correctly loaded when fetching an invitation by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchInvitation_NavigationPropertiesAreCorrectlyLoaded()
        {
            // Arrange
            var invitationIdToFetch = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;

            // Act
            var actualInvitation = await SpendWiseDbContextSUT.Invitations
                .Include(i => i.Sender)
                .Include(i => i.Receiver)
                .Include(i => i.Group)
                .SingleOrDefaultAsync(i => i.Id == invitationIdToFetch);

            // Assert
            Assert.NotNull(actualInvitation);
            Assert.NotNull(actualInvitation.Sender);
            Assert.NotNull(actualInvitation.Receiver);
            Assert.NotNull(actualInvitation.Group);
            DeepAssert.Equal(UserSeeds.UserDianaGreen, actualInvitation.Sender);
            DeepAssert.Equal(UserSeeds.UserCharlieBlack, actualInvitation.Receiver);
            DeepAssert.Equal(GroupSeeds.GroupFamily, actualInvitation.Group);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Contains tests that focus on handling special cases and updates in the <see cref="InvitationEntity"/>.
        /// These tests ensure that the application can handle concurrent operations and correctly persist data even under challenging conditions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Tests the ability of the application to successfully handle concurrent additions of multiple invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddInvitations_ConcurrentAdditions_SuccessfullyPersistAllInvitations()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );
            var invitationsToAdd = Enumerable.Range(0, 10).Select(_ => new InvitationEntity
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserJohnDoe.Id,
                ReceiverId = UserSeeds.UserDianaGreen.Id,
                GroupId = GroupSeeds.GroupFriends.Id,
                SentDate = baseTime,
                ResponseDate = null,
                IsAccepted = null,
                Sender = null!,
                Receiver = null!,
                Group = null!
            }).ToList();

            // Act
            SpendWiseDbContextSUT.Invitations.AddRange(invitationsToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualInvitations = await dbx.Invitations
                .Where(i => invitationsToAdd.Select(it => it.Id).Contains(i.Id))
                .ToListAsync();

            Assert.Equal(invitationsToAdd.Count, actualInvitations.Count);
            DeepAssert.Equal(invitationsToAdd, actualInvitations);
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Contains tests to ensure the consistency and integrity of the <see cref="InvitationEntity"/> after certain operations, such as deletions.
        /// These tests check that related entities remain intact and the database's referential integrity is maintained.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies the integrity constraints of the database after deleting an invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteInvitation_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var invitationToRemove = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var senderId = invitationToRemove.SenderId;
            var receiverId = invitationToRemove.ReceiverId;
            var groupId = invitationToRemove.GroupId;

            // Ensure the invitation and related entities exist before deletion
            Assert.NotNull(invitationToRemove);
            Assert.True(await SpendWiseDbContextSUT.Users.AnyAsync(u => u.Id == senderId));
            Assert.True(await SpendWiseDbContextSUT.Users.AnyAsync(u => u.Id == receiverId));
            Assert.True(await SpendWiseDbContextSUT.Groups.AnyAsync(g => g.Id == groupId));

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            // Check that the invitation has been deleted
            Assert.False(await dbx.Invitations.AnyAsync(i => i.Id == invitationToRemove.Id));

            // Check that the associated sender still exists
            Assert.True(await dbx.Users.AnyAsync(u => u.Id == senderId));

            // Check that the associated receiver still exists
            Assert.True(await dbx.Users.AnyAsync(u => u.Id == receiverId));

            // Check that the associated group still exists
            Assert.True(await dbx.Groups.AnyAsync(g => g.Id == groupId));
        }

        #endregion
    }
}

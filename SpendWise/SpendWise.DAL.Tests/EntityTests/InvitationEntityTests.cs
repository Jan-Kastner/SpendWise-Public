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
        /// Verifies that fetching an invitation by its ID returns the expected invitation entity.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchInvitationById_ShouldReturnExpectedInvitation()
        {
            // Arrange
            var expectedInvitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var invitationId = expectedInvitation.Id;

            // Act
            var actualInvitation = await SpendWiseDbContextSUT.Invitations
                .SingleOrDefaultAsync(i => i.Id == invitationId);

            // Assert
            Assert.NotNull(actualInvitation);
            DeepAssert.Equal(expectedInvitation, actualInvitation);
        }

        /// <summary>
        /// Tests the addition of a valid invitation entity to the database and verifies it is successfully persisted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddInvitation_ShouldPersistValidInvitation()
        {
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            // Arrange
            var newInvitation = new InvitationEntity
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
            SpendWiseDbContextSUT.Invitations.Add(newInvitation);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualInvitation = await dbx.Invitations.FindAsync(newInvitation.Id);
            Assert.NotNull(actualInvitation);
            DeepAssert.Equal(newInvitation, actualInvitation);
        }

        /// <summary>
        /// Tests the updating of an existing invitation entity and verifies that the changes are correctly persisted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_ShouldPersistChanges()
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

        /// <summary>
        /// Verifies that deleting an existing invitation entity successfully removes it from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_ShouldRemoveInvitation()
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
        /// Validates that updating an invitation with an invalid SenderId results in a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidSenderId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                SenderId = Guid.NewGuid() // Invalid SenderId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Ensures that updating an invitation with an invalid ReceiverId raises a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidReceiverId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                ReceiverId = Guid.NewGuid() // Invalid ReceiverId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Confirms that updating an invitation with an invalid GroupId triggers a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidGroupId_ShouldThrowDbUpdateException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            var invalidInvitation = existingInvitation with
            {
                GroupId = Guid.NewGuid() // Invalid GroupId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Invitations.Update(invalidInvitation);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });

            Assert.NotNull(exception);
        }

        /// <summary>
        /// Verifies that updating an invitation with an invalid ResponseDate (e.g., <see cref="DateTime.MinValue"/>) causes a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidResponseDate_ShouldThrowDbUpdateException()
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
        /// Validates that invitations can be correctly fetched based on their acceptance status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchInvitationsByStatus_ShouldReturnExpectedInvitations()
        {
            // Arrange
            var isAccepted = true; // Accepted invitations

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.IsAccepted == isAccepted)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(isAccepted, i.IsAccepted));
        }

        /// <summary>
        /// Ensures that invitations sent by a specific user can be accurately retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchInvitationsBySenderId_ShouldReturnExpectedInvitations()
        {
            // Arrange
            var senderId = UserSeeds.UserJohnDoe.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.SenderId == senderId)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(senderId, i.SenderId));
        }

        /// <summary>
        /// Confirms that invitations received by a specific user can be accurately retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchInvitationsByReceiverId_ShouldReturnExpectedInvitations()
        {
            // Arrange
            var receiverId = UserSeeds.UserDianaGreen.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.ReceiverId == receiverId)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(receiverId, i.ReceiverId));
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Validates that the navigation properties of an invitation entity are correctly loaded when fetching an invitation by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task FetchInvitation_WithNavigationProperties_ShouldLoadRelatedEntities()
        {
            // Arrange
            var invitationId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id;

            // Act
            var actualInvitation = await SpendWiseDbContextSUT.Invitations
                .Include(i => i.Sender)
                .Include(i => i.Receiver)
                .Include(i => i.Group)
                .SingleOrDefaultAsync(i => i.Id == invitationId);

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
        /// Tests the ability of the application to successfully handle concurrent additions of multiple invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddInvitations_Concurrently_ShouldPersistAllInvitations()
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
        /// Verifies the integrity constraints of the database after deleting an invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_ShouldMaintainIntegrityConstraints()
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
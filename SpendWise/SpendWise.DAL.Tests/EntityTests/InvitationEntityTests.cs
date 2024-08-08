using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="InvitationEntity"/> entity.
    /// </summary>
    public class InvitationEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper used to log test results.</param>
        public InvitationEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests that the invitation is correctly retrieved by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitation_ById_ReturnsCorrectInvitation()
        {
            // Arrange
            var existingInvitationId = InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id;
            var expectedInvitation = InvitationSeeds.InvitationAdminToJohnDoeIntoFamily;

            // Act
            var invitation = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.Id == existingInvitationId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(invitation);
            DeepAssert.Equal(expectedInvitation, invitation);
        }

        /// <summary>
        /// Tests that a valid invitation is added to the database and persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddInvitation_WhenValidInvitationIsAdded_InvitationIsPersisted()
        {
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), 
                DateTimeKind.Utc
            );
            // Arrange
            var invitation = new InvitationEntity
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserAdmin.Id,
                ReceiverId = UserSeeds.UserJohnDoe.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = baseTime,
                ResponseDate = null,
                IsAccepted = null,
                Sender = null!,
                Receiver = null!,
                Group = null!
            };

            // Act
            SpendWiseDbContextSUT.Invitations.Add(invitation);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualInvitation = await dbx.Invitations.FindAsync(invitation.Id);
            Assert.NotNull(actualInvitation);
            DeepAssert.Equal(invitation, actualInvitation);
        }

        /// <summary>
        /// Tests that changes to an existing invitation are persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WhenExistingInvitationIsUpdated_ChangesArePersisted()
        {
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), 
                DateTimeKind.Utc
            );
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id);

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
        /// Tests that an invitation is removed from the database when deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_WhenInvitationIsDeleted_InvitationIsRemoved()
        {
            // Arrange
            var invitationToDelete = InvitationSeeds.InvitationAdminToJohnDoeIntoFamily;

            // Ensure the invitation exists before deletion
            Assert.True(await SpendWiseDbContextSUT.Invitations.AnyAsync(i => i.Id == invitationToDelete.Id));

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Invitations.AnyAsync(i => i.Id == invitationToDelete.Id));
        }
        /// <summary>
        /// Tests that navigation properties (Sender, Receiver, and Group) are correctly loaded when fetching an invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task VerifyInvitationNavigationProperties_WhenInvitationIsFetched_NavigationPropertiesAreLoaded()
        {
            // Arrange
            var invitationId = InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id;

            // Act
            var invitation = await SpendWiseDbContextSUT.Invitations
                .Include(i => i.Sender)
                .Include(i => i.Receiver)
                .Include(i => i.Group)
                .SingleOrDefaultAsync(i => i.Id == invitationId);

            // Assert
            Assert.NotNull(invitation);
            Assert.NotNull(invitation.Sender);
            Assert.NotNull(invitation.Receiver);
            Assert.NotNull(invitation.Group);
            DeepAssert.Equal(UserSeeds.UserAdmin, invitation.Sender, propertiesToIgnore: new[] { "SentInvitations", "ReceivedInvitations", "GroupUsers" });
            DeepAssert.Equal(UserSeeds.UserJohnDoe, invitation.Receiver, propertiesToIgnore: new[] { "SentInvitations", "ReceivedInvitations", "GroupUsers" });
            DeepAssert.Equal(GroupSeeds.GroupFamily, invitation.Group, propertiesToIgnore: new[] { "GroupUsers", "Invitations" });
        }

        /// <summary>
        /// Tests that the correct invitations are returned based on their acceptance status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitations_ByStatus_ReturnsCorrectInvitations()
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

        /// <summary>
        /// Tests that the correct invitations are returned based on the sender's ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitations_BySenderId_ReturnsCorrectInvitations()
        {
            // Arrange
            var senderId = UserSeeds.UserAdmin.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.SenderId == senderId)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(senderId, i.SenderId));
        }

        /// <summary>
        /// Tests that the correct invitations are returned based on the receiver's ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetInvitations_ByReceiverId_ReturnsCorrectInvitations()
        {
            // Arrange
            var receiverId = UserSeeds.UserJohnDoe.Id;

            // Act
            var invitations = await SpendWiseDbContextSUT.Invitations
                .Where(i => i.ReceiverId == receiverId)
                .ToListAsync();

            // Assert
            Assert.NotEmpty(invitations);
            Assert.All(invitations, i => Assert.Equal(receiverId, i.ReceiverId));
        }

        /// <summary>
        /// Tests that multiple invitations added concurrently are persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddInvitations_Concurrently_InvitationsArePersistedCorrectly()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), 
                DateTimeKind.Utc
            );
            var invitations = Enumerable.Range(0, 10).Select(_ => new InvitationEntity
            {
                Id = Guid.NewGuid(),
                SenderId = UserSeeds.UserAdmin.Id,
                ReceiverId = UserSeeds.UserJohnDoe.Id,
                GroupId = GroupSeeds.GroupFamily.Id,
                SentDate = baseTime,
                ResponseDate = null,
                IsAccepted = null,
                Sender = null!,
                Receiver = null!,
                Group = null!
            }).ToList();

            // Act
            var tasks = invitations.Select(async invitation =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Invitations.Add(invitation);
                await dbx.SaveChangesAsync();
            });

            await Task.WhenAll(tasks);

            // Assert
            var verificationTasks = invitations.Select(async invitation =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                var actualInvitation = await dbx.Invitations.FindAsync(invitation.Id);
                Assert.NotNull(actualInvitation);
                DeepAssert.Equal(invitation, actualInvitation);
            });

            await Task.WhenAll(verificationTasks);
        }

        /// <summary>
        /// Tests that updating an invitation with an invalid SenderId throws an exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidSenderId_ShouldThrowException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id);

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
        /// <summary>
        /// Tests that updating an invitation with an invalid ReceiverId throws an exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidReceiverId_ShouldThrowException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id);

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
        /// <summary>
        /// Tests that updating an invitation with an invalid GroupId throws an exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidGroupId_ShouldThrowException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id);

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
        /// <summary>
        /// Tests that updating an invitation with an invalid ResponseDate throws an exception.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateInvitation_WithInvalidResponseDate_ShouldThrowException()
        {
            // Arrange
            var existingInvitation = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking()
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationAdminToJohnDoeIntoFamily.Id);

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
        /// <summary>
        /// Tests that deleting an invitation does not delete the associated sender, receiver, or group.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteInvitation_WhenInvitationIsDeleted_RelatedEntitiesAreNotDeleted()
        {
            // Arrange
            var invitation = InvitationSeeds.InvitationAdminToJohnDoeIntoFamilyWithRelations;
            var senderId = invitation.SenderId;
            var receiverId = invitation.ReceiverId;
            var groupId = invitation.GroupId;

            // Ensure the invitation and related entities exist before deletion
            Assert.True(await SpendWiseDbContextSUT.Invitations.AnyAsync(i => i.Id == invitation.Id));
            Assert.True(await SpendWiseDbContextSUT.Users.AnyAsync(u => u.Id == senderId));
            Assert.True(await SpendWiseDbContextSUT.Users.AnyAsync(u => u.Id == receiverId));
            Assert.True(await SpendWiseDbContextSUT.Groups.AnyAsync(g => g.Id == groupId));

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitation);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            // Check that the invitation has been deleted
            Assert.False(await dbx.Invitations.AnyAsync(i => i.Id == invitation.Id));

            // Check that the associated sender still exists
            Assert.True(await dbx.Users.AnyAsync(u => u.Id == senderId));

            // Check that the associated receiver still exists
            Assert.True(await dbx.Users.AnyAsync(u => u.Id == receiverId));

            // Check that the associated group still exists
            Assert.True(await dbx.Groups.AnyAsync(g => g.Id == groupId));
        }
    }
}

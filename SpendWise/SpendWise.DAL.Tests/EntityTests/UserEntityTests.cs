using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="UserEntity"/> entity.
    /// </summary>
    public class UserEntityTests : DbContextTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntityTests"/> class.
        /// </summary>
        /// <param name="output">The output helper used to log test results.</param>
        public UserEntityTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Tests that a user can be retrieved by its ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUser_ById_ReturnsCorrectUser()
        {
            // Arrange
            var existingUserId = UserSeeds.UserJohnDoe.Id;
            var expectedUser = UserSeeds.UserJohnDoe;

            // Act
            var user = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == existingUserId)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(user); // Ensure that the user is not null
            DeepAssert.Equal(expectedUser, user, propertiesToIgnore: new[] { "SentInvitations", "ReceivedInvitations", "GroupUsers" });
        }

        /// <summary>
        /// Tests that a valid user is added to the database and persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WhenValidUserIsAdded_UserIsPersisted()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), 
                DateTimeKind.Utc
            );

            var entity = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "David",
                Surname = "Smith",
                Email = "david.smith@example.com",
                Password = "somestrongpassword",
                Date_of_registration = baseTime,
                ReceivedInvitations = Array.Empty<InvitationEntity>(),
                SentInvitations = Array.Empty<InvitationEntity>(),
                GroupUsers = Array.Empty<GroupUserEntity>()
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(entity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Users.SingleOrDefaultAsync(i => i.Id == entity.Id);

            Assert.NotNull(actualEntity);
            DeepAssert.Equal(entity, actualEntity);
        }

        /// <summary>
        /// Tests that updates to an existing user are persisted correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_WhenExistingUserIsUpdated_ChangesArePersisted()
        {
            // Arrange
            var baseEntity = UserSeeds.UserJohnDoe;
            var entity = baseEntity with
            {
                Name = baseEntity.Name + "Updated",
                Surname = baseEntity.Surname + "Updated",
                Email = baseEntity.Email + "Updated",
                Password = baseEntity.Password + "Updated",
                Date_of_registration = baseEntity.Date_of_registration.AddHours(3),
            };

            // Act
            SpendWiseDbContextSUT.Users.Update(entity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Users.SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }


        /// <summary>
        /// Tests that a user is removed from the database when deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_WhenUserIsDeleted_UserIsRemoved()
        {
            // Arrange
            var baseEntity = UserSeeds.UserJohnDoe;
            Assert.True(await SpendWiseDbContextSUT.Users.AnyAsync(i => i.Id == baseEntity.Id));

            // Act
            SpendWiseDbContextSUT.Users.Remove(baseEntity);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Users.AnyAsync(i => i.Id == baseEntity.Id));
        }

        /// <summary>
        /// Tests that a user can be retrieved by its email address.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUser_ByEmail_ReturnsCorrectUser()
        {
            // Arrange
            var userEmail = UserSeeds.UserJohnDoe.Email;
            var expectedUser = UserSeeds.UserJohnDoe;

            // Act
            var user = await SpendWiseDbContextSUT.Users
                .Where(u => u.Email == userEmail)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(user); // Ensure that the user is not null
            DeepAssert.Equal(expectedUser, user);
        }

        /// <summary>
        /// Tests that users within a specific date of registration range are retrieved correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers_ByDateOfRegistrationRange_ReturnsUsersWithinRange()
        {
            // Arrange
            var startDate = new DateTime(2024, 6, 1, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc);
            var expectedUsers = new List<UserEntity> { UserSeeds.UserAdmin, UserSeeds.UserJohnDoe };

            // Act
            var users = await SpendWiseDbContextSUT.Users
                .Where(u => u.Date_of_registration >= startDate && u.Date_of_registration < endDate)
                .ToListAsync();

            // Assert
            Assert.NotNull(users); // Ensure the result is not null
            Assert.Equal(expectedUsers.Count, users.Count); // Verify the count matches
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, users); // Verify each expected user is present in the result
            }
        }
        /// <summary>
        /// Tests that users who belong to multiple groups are correctly retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers_ForMultipleGroups_ReturnsCorrectUsers()
        {
            // Act
            var expectedUser = UserSeeds.UserJohnDoe;
            var usersInMultipleGroups = await SpendWiseDbContextSUT.Users
                .Where(u => u.GroupUsers.Count > 1)
                .ToListAsync();

            // Assert
            Assert.NotNull(usersInMultipleGroups); // Ensure the result is not null
            Assert.Single(usersInMultipleGroups); // Ensure only one user is returned
            DeepAssert.Contains(expectedUser, usersInMultipleGroups); // Verify the expected user is present in the result
        }

        /// <summary>
        /// Tests that the navigation properties of a user are correctly loaded when fetching the user from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task CheckUserNavigationProperties_WhenUsersAreFetched_NavigationPropertiesAreLoaded()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var expectedReceivedInvitations = UserSeeds.UserJohnDoeWithRelations.ReceivedInvitations;
            var expectedSendInvitations = UserSeeds.UserJohnDoeWithRelations.SentInvitations;
            var expectedGroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserJohnDoeInFriends,
                GroupUserSeeds.GroupUserJohnDoeInFamily
            };

            // Act
            var user = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ReceivedInvitations)
                .Include(u => u.SentInvitations)
                .Include(u => u.GroupUsers)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(user); // Ensure the user is not null

            // Check ReceivedInvitations
            Assert.NotNull(user.ReceivedInvitations);
            Assert.Single(user.ReceivedInvitations);
            foreach (var expectedReceivedInvitation in expectedReceivedInvitations)
            {
                DeepAssert.Contains(expectedReceivedInvitation, user.ReceivedInvitations, propertiesToIgnore: new[] { "Sender", "Receiver", "Group" });
            }

            // Check SentInvitations
            Assert.NotNull(user.SentInvitations);
            Assert.Single(user.SentInvitations);
            foreach (var expectedSendInvitation in expectedSendInvitations)
            {
                DeepAssert.Contains(expectedSendInvitation, user.SentInvitations, propertiesToIgnore: new[] { "Sender", "Receiver", "Group" });
            }

            // Check GroupUsers
            Assert.NotNull(user.GroupUsers);
            Assert.Equal(expectedGroupUsers.Count(), user.GroupUsers.Count());
            foreach (var expectedGroupUser in expectedGroupUsers)
            {
                DeepAssert.Contains(expectedGroupUser, user.GroupUsers, propertiesToIgnore: new[] { "User", "Group", "TransactionGroupUsers" });
            }
        }

        /// <summary>
        /// Tests that multiple users are correctly persisted when added concurrently to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUsers_Concurrently_UsersArePersistedCorrectly()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond), 
                DateTimeKind.Utc
            );
            var expectedUsers = Enumerable.Range(0, 10).Select(i => new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Bob{i}",
                Surname = "Johnson",
                Email = $"bob{i}.johnson@spendwise.com",
                Password = "password456",
                Date_of_registration = baseTime
            }).ToList();

            // Act
            var tasks = expectedUsers.Select(user => Task.Run(async () =>
            {
                await using var dbx = await DbContextFactory.CreateDbContextAsync();
                dbx.Users.Add(user);
                await dbx.SaveChangesAsync();
            }));

            await Task.WhenAll(tasks);

            // Assert
            await using var finalDbContext = await DbContextFactory.CreateDbContextAsync();
            var allUsers = await finalDbContext.Users
                .Where(u => expectedUsers.Select(eu => eu.Id).Contains(u.Id))
                .ToListAsync();

            Assert.Equal(expectedUsers.Count, allUsers.Count);

            foreach (var expectedUser in expectedUsers)
            {
                var actualUser = allUsers.SingleOrDefault(u => u.Id == expectedUser.Id);
                Assert.NotNull(actualUser);
                DeepAssert.Equal(expectedUser, actualUser);
            }
        }

        /// <summary>
        /// Tests that adding a user with a duplicate email address throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithDuplicateEmail_ShouldThrowDbUpdateException()
        {
            // Arrange
            var duplicateUser = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "john.doe@spendwise.com", // Duplicate email
                Password = "password789",
                Date_of_registration = DateTime.UtcNow
            };

            SpendWiseDbContextSUT.Users.Add(duplicateUser);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        /// <summary>
        /// Tests that adding a user with an invalid registration date throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithInvalidDateOfRegistration_ShouldThrowDbUpdateException()
        {
            // Arrange
            var invalidUser = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "invalid.user@example.com",
                Password = "password789",
                Date_of_registration = DateTime.UtcNow.AddHours(1) // Invalid Date
            };

            SpendWiseDbContextSUT.Users.Add(invalidUser);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        /// <summary>
        /// Tests that users are correctly ordered by their date of registration when retrieved from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers_OrderedByDateOfRegistration_ReturnsUsersInCorrectOrder()
        {
            // Act
            var users = await SpendWiseDbContextSUT.Users
                .OrderBy(u => u.Date_of_registration)
                .ToListAsync();

            // Assert
            Assert.Equal(5, users.Count); // Ensure the correct number of users
            DeepAssert.Equal(UserSeeds.UserAdmin, users[0]);
            DeepAssert.Equal(UserSeeds.UserJohnDoe, users[1]);
            DeepAssert.Equal(UserSeeds.UserJaneSmith, users[2]);
            DeepAssert.Equal(UserSeeds.UserBobJohnson, users[3]);
            DeepAssert.Equal(UserSeeds.UserAliceBrown, users[4]);
        }

        /// <summary>
        /// Tests that the total number of users retrieved from the database matches the expected count.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetTotalNumberOfUsers_ReturnsCorrectCount()
        {
            // Act
            var userCount = await SpendWiseDbContextSUT.Users.CountAsync();

            // Assert
            var expectedUserCount = 5; // Assuming 5 users in the seed data
            Assert.Equal(expectedUserCount, userCount);
        }

        /// <summary>
        /// Tests that deleting a user also removes related data from other tables, and checks integrity constraints.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UserDeletion_IntegrityConstraints()
        {
            // Arrange
            var user = UserSeeds.UserJohnDoe;

            // Act
            SpendWiseDbContextSUT.Users.Remove(user);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();

            var deletedUser = await dbx.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.Null(deletedUser); // Ensure the user is deleted

            var receivedInvitations = await dbx.Invitations.Where(i => i.ReceiverId == user.Id).ToListAsync();
            Assert.Empty(receivedInvitations); // Ensure related invitations are removed

            var sentInvitations = await dbx.Invitations.Where(i => i.SenderId == user.Id).ToListAsync();
            Assert.Empty(sentInvitations); // Ensure related invitations are removed

            var groupUsers = await dbx.GroupUsers.Where(gu => gu.UserId == user.Id).ToListAsync();
            Assert.Empty(groupUsers); // Ensure related group users are removed
        }

        /// <summary>
        /// Tests that a user with the maximum field length values is stored correctly in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task AddUser_WithMaximumFieldLength_StoresCorrectly()
        {
            // Arrange
            var longName = new string('A', 100); // Maximum length 100 characters for Name
            var longEmail = new string('B', 243) + "@example.com"; // Maximum length 255 characters for Email

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = longName,
                Surname = longName,
                Email = longEmail,
                Password = new string('C', 255), // Maximum length 255 characters for Password
                Date_of_registration = DateTime.UtcNow
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(user);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var storedUser = await dbx.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            Assert.NotNull(storedUser); // Ensure the user is not null
            Assert.Equal(longName, storedUser.Name); // Verify the Name is stored correctly
            Assert.Equal(longName, storedUser.Surname); // Verify the Surname is stored correctly
            Assert.Equal(longEmail, storedUser.Email); // Verify the Email is stored correctly
        }

        /// <summary>
        /// Tests that removing the last invitation for a user does not delete the user, and ensures the user has only one invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteLastInvitation_UserIsNotDeleted_AndHasOnlyOneInvitation()
        {
            // Arrange
            var user = UserSeeds.UserAdmin;
            var invitationToRemove = InvitationSeeds.InvitationJohnDoeToAdminIntoFriends;

            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id);

            Assert.True(initialInvitationCount > 0); // Ensure there is at least one invitation

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingUser = await SpendWiseDbContextSUT.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(remainingUser); // Ensure the user still exists

            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id);
                
            Assert.Equal(0, remainingInvitationCount); // Verify no invitations are left
        }

        /// <summary>
        /// Tests that removing the last group user record for a user does not delete the user, and ensures the user has only one remaining group user record.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveLastGroupUser_UserIsNotDeleted_AndHasOnlyOneGroupUser()
        {
            // Arrange
            var user = UserSeeds.UserAdmin;
            var groupUserToRemove = GroupUserSeeds.GroupUserAdminInFamily;

            // Ensure the user has at least one group user record
            var initialGroupUserCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.UserId == user.Id);

            Assert.True(initialGroupUserCount > 0); // Ensure there is at least one group user record

            // Act
            SpendWiseDbContextSUT.GroupUsers.Remove(groupUserToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingUser = await SpendWiseDbContextSUT.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(remainingUser); // Ensure the user still exists

            var remainingGroupUserCount = await SpendWiseDbContextSUT.GroupUsers
                .CountAsync(gu => gu.UserId == user.Id);
                
            // Verify the user has only one remaining group user record
            Assert.Equal(0, remainingGroupUserCount);
        }
        /// <summary>
        /// Tests that removing the last invitation from a user does not delete the user, and ensures the user has no remaining invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveLastInvitation_DoesNotDeleteUser_AndUserHasOnlyOneInvitation()
        {
            // Arrange
            var user = UserSeeds.UserAdmin;
            var invitationToRemove = InvitationSeeds.InvitationAdminToJohnDoeIntoFamily;

            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.SenderId == user.Id);

            Assert.True(initialInvitationCount > 0); // Ensure the user has at least one invitation

            // Act
            SpendWiseDbContextSUT.Invitations.Remove(invitationToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingUser = await SpendWiseDbContextSUT.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(remainingUser); // Ensure the user is not deleted

            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.SenderId == user.Id);
                
            Assert.Equal(0, remainingInvitationCount); // Verify there are no remaining invitations
        }

        /// <summary>
        /// Tests that retrieving users whose email contains a specified substring returns the correct users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUser_ByEmailContaining_ReturnsCorrectUsers()
        {
            // Arrange
            var partialEmail = "john.doe";
            var expectedUsers = new List<UserEntity> { UserSeeds.UserJohnDoe };

            // Act
            var users = await SpendWiseDbContextSUT.Users
                .Where(u => u.Email.Contains(partialEmail))
                .ToListAsync();

            // Assert
            Assert.NotNull(users); // Ensure the result is not null
            Assert.Equal(expectedUsers.Count, users.Count); // Verify the count matches
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, users); // Verify each expected user is present
            }
        }

        /// <summary>
        /// Tests that retrieving a user with no invitations returns a user with empty invitation lists.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUser_WithNoInvitations_ReturnsUserWithoutInvitations()
        {
            // Arrange
            var userId = UserSeeds.UserJaneSmith.Id;

            // Act
            var user = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ReceivedInvitations)
                .Include(u => u.SentInvitations)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(user); // Ensure the user is not null
            Assert.Empty(user.ReceivedInvitations); // Ensure there are no received invitations
            Assert.Empty(user.SentInvitations); // Ensure there are no sent invitations
        }

        /// <summary>
        /// Tests that retrieving users with specific properties returns the correct users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers_WithSpecificProperties_ReturnsCorrectUsers()
        {
            // Arrange
            var expectedUsers = new List<UserEntity> { UserSeeds.UserJohnDoe, UserSeeds.UserJaneSmith };

            // Act
            var users = await SpendWiseDbContextSUT.Users
                .Where(u => u.Name.Contains("John") || u.Surname.Contains("Smith"))
                .ToListAsync();

            // Assert
            Assert.NotNull(users); // Ensure the result is not null
            Assert.Equal(expectedUsers.Count, users.Count); // Verify the count matches
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, users); // Verify each expected user is present
            }
        }

        /// <summary>
        /// Tests that removing a user also removes all associated invitations from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task RemoveUser_RemovesAssociatedInvitations()
        {
            // Arrange
            var user = UserSeeds.UserJohnDoe;
            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id || i.SenderId == user.Id);

            // Act
            SpendWiseDbContextSUT.Users.Remove(user);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == user.Id || i.SenderId == user.Id);
                
            Assert.Equal(0, remainingInvitationCount); // Verify no invitations are left
        }

        /// <summary>
        /// Tests that updating a user with an invalid email address throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_WithInvalidEmail_ShouldThrowDbUpdateException()
        {
            // Arrange
            var baseEntity = UserSeeds.UserJohnDoe;
            var invalidEmail = new string('B', 244) + "@example.com"; // Email too long

            var updatedEntity = baseEntity with
            {
                Email = invalidEmail
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Users.Update(updatedEntity);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        /// <summary>
        /// Tests that updating a user with an invalid date of registration throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_WithInvalidDateOfRegistration_ShouldThrowDbUpdateException()
        {
            // Arrange
            var baseEntity = UserSeeds.UserJohnDoe;
            var invalidDate = DateTime.UtcNow.AddHours(1); // Future date

            var updatedEntity = baseEntity with
            {
                Date_of_registration = invalidDate
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Users.Update(updatedEntity);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }
    }
}

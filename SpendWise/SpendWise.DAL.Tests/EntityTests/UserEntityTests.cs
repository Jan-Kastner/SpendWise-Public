using SpendWise.DAL.Entities;
using SpendWise.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

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

        #region CRUD Operations Tests

        /// <summary>
        /// Tests the CRUD (Create, Read, Update, Delete) operations for the <see cref="UserEntity"/> entity.
        /// These tests verify that the database operations work as expected for users.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that adding a valid user successfully persists the user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUser_ValidUser_SuccessfullyPersists()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            var userToAdd = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "David",
                Surname = "Smith",
                Email = "david.smith@example.com",
                PasswordHash = "somestrongpassword",
                DateOfRegistration = baseTime,
                ReceivedInvitations = Array.Empty<InvitationEntity>(),
                SentInvitations = Array.Empty<InvitationEntity>(),
                GroupUsers = Array.Empty<GroupUserEntity>(),
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                Role = UserRole.User,
                PreferredTheme = Theme.SystemDefault
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(userToAdd);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualUser = await dbx.Users.SingleOrDefaultAsync(i => i.Id == userToAdd.Id);

            Assert.NotNull(actualUser);
            DeepAssert.Equal(userToAdd, actualUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a user by their ID returns the expected user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUserById_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = UserSeeds.UserJohnDoe;
            var userIdToFetch = expectedUser.Id;

            // Act
            var actualUser = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userIdToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that updating an existing user successfully persists the changes in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateUser_ExistingUser_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            var updatedUser = existingUser with
            {
                Name = existingUser.Name + " Updated",
                Surname = existingUser.Surname + " Updated",
                Email = existingUser.Email + " Updated",
                PasswordHash = existingUser.PasswordHash + " Updated",
                DateOfRegistration = existingUser.DateOfRegistration.AddHours(3),
            };

            // Act
            SpendWiseDbContextSUT.Users.Update(updatedUser);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualUser = await dbx.Users.SingleAsync(i => i.Id == updatedUser.Id);
            DeepAssert.Equal(updatedUser, actualUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that deleting an existing user successfully removes them from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteUser_ExistingUser_SuccessfullyRemovesUser()
        {
            // Arrange
            var userToDelete = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            Assert.NotNull(userToDelete);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            Assert.False(await SpendWiseDbContextSUT.Users.AnyAsync(i => i.Id == userToDelete.Id));
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching a user by their email returns the expected user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUserByEmail_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = UserSeeds.UserJohnDoe;
            var userEmailToFetch = expectedUser.Email;

            // Act
            var actualUser = await SpendWiseDbContextSUT.Users
                .Where(u => u.Email == userEmailToFetch)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        [Fact]
        /// <summary>
        /// Verifies that adding a user with maximum field length successfully stores the data correctly.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUser_WithMaximumFieldLength_StoresDataCorrectly()
        {
            // Arrange
            var maxLengthName = new string('A', 100);
            var maxLengthEmail = new string('B', 243) + "@example.com";

            var userWithMaxLengthFields = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = maxLengthName,
                Surname = maxLengthName,
                Email = maxLengthEmail,
                PasswordHash = new string('C', 255),
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                Role = UserRole.User,
                PreferredTheme = Theme.SystemDefault
            };

            // Act
            SpendWiseDbContextSUT.Users.Add(userWithMaxLengthFields);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();
            var storedUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userWithMaxLengthFields.Id);

            Assert.NotNull(storedUser);
            Assert.Equal(maxLengthName, storedUser.Name);
            Assert.Equal(maxLengthName, storedUser.Surname);
            Assert.Equal(maxLengthEmail, storedUser.Email);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests the error handling scenarios for the <see cref="UserEntity"/> entity.
        /// These tests verify that the database correctly throws exceptions when invalid data is used.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that attempting to add a user with a duplicate email address throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUser_WithDuplicateEmail_ThrowsDbUpdateException()
        {
            // Arrange
            var userWithDuplicateEmail = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "john.doe@spendwise.com", // Duplicate email
                PasswordHash = "password789",
                DateOfRegistration = DateTime.UtcNow,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                Role = UserRole.User,
                PreferredTheme = Theme.SystemDefault
            };

            SpendWiseDbContextSUT.Users.Add(userWithDuplicateEmail);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to add a user with an invalid registration date (e.g., a future date) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUser_WithInvalidRegistrationDate_ThrowsDbUpdateException()
        {
            // Arrange
            var userWithInvalidDate = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "John",
                Surname = "Smith",
                Email = "invalid.user@example.com",
                PasswordHash = "password789",
                DateOfRegistration = DateTime.UtcNow.AddHours(1),
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                Role = UserRole.User,
                PreferredTheme = Theme.SystemDefault
            };

            SpendWiseDbContextSUT.Users.Add(userWithInvalidDate);

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(() => SpendWiseDbContextSUT.SaveChangesAsync());
        }

        [Fact]
        /// <summary>
        /// Verifies that attempting to update a user with an invalid email address (e.g., too long) throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateUser_WithInvalidEmail_ThrowsDbUpdateException()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(l => l.Id == UserSeeds.UserJohnDoe.Id);

            var invalidEmail = new string('B', 244) + "@example.com"; // Email too long

            var updatedEntity = existingUser with
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

        [Fact]
        /// <summary>
        /// Verifies that attempting to update a user with a future registration date throws a <see cref="DbUpdateException"/>.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateUser_WithFutureDateOfRegistration_ThrowsDbUpdateException()
        {
            // Arrange
            var existingUser = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(l => l.Id == UserSeeds.UserJohnDoe.Id);

            var invalidDate = DateTime.UtcNow.AddHours(1); // Future date

            var updatedEntity = existingUser with
            {
                DateOfRegistration = invalidDate
            };

            // Act & Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                SpendWiseDbContextSUT.Users.Update(updatedEntity);
                await SpendWiseDbContextSUT.SaveChangesAsync();
            });
        }

        #endregion

        #region Data Retrieval Tests

        /// <summary>
        /// Tests the data retrieval scenarios for the <see cref="UserEntity"/> entity.
        /// These tests verify that the correct data is retrieved from the database based on various conditions.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that fetching users within a specified date range returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUsersByDateOfRegistrationRange_ReturnsUsersWithinRange()
        {
            // Arrange
            var startDate = new DateTime(2024, 6, 17, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2024, 6, 20, 0, 0, 0, DateTimeKind.Utc);
            var expectedUsers = new List<UserEntity>
            {
                UserSeeds.UserAliceSmith,
                UserSeeds.UserBobBrown,
                UserSeeds.UserCharlieBlack
            };

            // Act
            var actualUsers = await SpendWiseDbContextSUT.Users
                .Where(u => u.DateOfRegistration >= startDate && u.DateOfRegistration < endDate)
                .ToListAsync();

            // Assert
            Assert.NotNull(actualUsers); // Ensure the result is not null
            Assert.Equal(expectedUsers.Count, actualUsers.Count); // Verify the count matches
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, actualUsers); // Verify each expected user is present in the result
            }
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching users who belong to multiple groups returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUsers_InMultipleGroups_ReturnsExpectedUsers()
        {
            // Act
            var expectedUser = UserSeeds.UserJohnDoe;
            var actualUsersInMultipleGroups = await SpendWiseDbContextSUT.Users
                .Where(u => u.GroupUsers.Count > 1)
                .ToListAsync();

            // Assert
            Assert.NotNull(actualUsersInMultipleGroups); // Ensure the result is not null
            Assert.Single(actualUsersInMultipleGroups); // Ensure only one user is returned
            DeepAssert.Contains(expectedUser, actualUsersInMultipleGroups); // Verify the expected user is present in the result
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching the total user count returns the correct number of users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchTotalUserCount_ReturnsCorrectNumber()
        {
            // Act
            var totalUserCount = await SpendWiseDbContextSUT.Users.CountAsync();

            // Assert
            var expectedCount = 5; // Assuming 5 users in the seed data
            Assert.Equal(expectedCount, totalUserCount);
        }

        [Fact]
        /// <summary>
        /// Verifies that retrieving users by a substring of their email returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RetrieveUsers_ByEmailSubstring_ReturnsExpectedUsers()
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

        [Fact]
        /// <summary>
        /// Verifies that retrieving users by a substring of their name or surname returns the expected users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RetrieveUsers_ByNameOrSurname_ReturnsExpectedUsers()
        {
            // Arrange
            var expectedUsers = new List<UserEntity> { UserSeeds.UserJohnDoe, UserSeeds.UserBobBrown };

            // Act
            var users = await SpendWiseDbContextSUT.Users
                .Where(u => u.Name.Contains("John") || u.Surname.Contains("Brown"))
                .ToListAsync();

            // Assert
            Assert.NotNull(users); // Ensure the result is not null
            Assert.Equal(expectedUsers.Count, users.Count); // Verify the count matches
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, users); // Verify each expected user is present
            }
        }

        [Fact]
        /// <summary>
        /// Verifies that fetching users ordered by their registration date returns the users in the correct order.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUsers_OrderedByRegistrationDate_ReturnsUsersInCorrectOrder()
        {
            // Act
            var retrievedUsers = await SpendWiseDbContextSUT.Users
                .OrderBy(u => u.DateOfRegistration)
                .ToListAsync();

            // Assert
            Assert.Equal(5, retrievedUsers.Count); // Ensure the correct number of users
            DeepAssert.Equal(UserSeeds.UserJohnDoe, retrievedUsers[0]);
            DeepAssert.Equal(UserSeeds.UserAliceSmith, retrievedUsers[1]);
            DeepAssert.Equal(UserSeeds.UserBobBrown, retrievedUsers[2]);
            DeepAssert.Equal(UserSeeds.UserCharlieBlack, retrievedUsers[3]);
            DeepAssert.Equal(UserSeeds.UserDianaGreen, retrievedUsers[4]);
        }

        #endregion

        #region Update and Special Cases Tests

        /// <summary>
        /// Tests the update and special case scenarios for the <see cref="UserEntity"/> entity and its related entities.
        /// These tests ensure that updates to the database are handled correctly and that special conditions are met.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that when the last invitation for a user is removed, the user remains in the system with no invitations left.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveLastInvitation_UserRemainsWithOnlyOneInvitation()
        {
            // Arrange
            var user = UserSeeds.UserCharlieBlack;

            var invitationToRemove = await SpendWiseDbContextSUT.Invitations
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(i => i.Id == InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

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

        [Fact]
        /// <summary>
        /// Verifies that when a group association for a user is removed, the user remains in the system with no group associations left.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveGroupUser_UserRemains_WithOnlyOneGroupAssociation()
        {
            // Arrange
            var user = UserSeeds.UserBobBrown;

            var groupUserToRemove = await SpendWiseDbContextSUT.GroupUsers
                .AsNoTracking()
                .FirstAsync(l => l.Id == GroupUserSeeds.GroupUserBobInFamily.Id);

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

            Assert.Equal(0, remainingGroupUserCount); // Verify the user has no remaining group associations
        }

        #endregion

        #region Related Entities Handling Tests

        /// <summary>
        /// Tests the handling of related entities when performing operations on the <see cref="UserEntity"/>.
        /// These tests ensure that associated entities, such as invitations and group associations, are correctly managed when a user is deleted or retrieved.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that when a user is removed, all associated invitations (both received and sent) are also deleted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveUser_DeletesAssociatedInvitations()
        {
            // Arrange
            var userToRemove = await SpendWiseDbContextSUT.Users
                .AsNoTracking()
                .FirstAsync(l => l.Id == UserSeeds.UserJohnDoe.Id);

            var initialInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == userToRemove.Id || i.SenderId == userToRemove.Id);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToRemove);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            var remainingInvitationCount = await SpendWiseDbContextSUT.Invitations
                .CountAsync(i => i.ReceiverId == userToRemove.Id || i.SenderId == userToRemove.Id);

            Assert.Equal(0, remainingInvitationCount); // Verify no invitations are left
        }

        [Fact]
        /// <summary>
        /// Verifies that when fetching a user, all related navigation properties (invitations and group associations) are correctly loaded.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task FetchUser_NavigationPropertiesAreCorrectlyLoaded()
        {
            // Arrange
            var userIdToFetch = UserSeeds.UserDianaGreen.Id;
            var expectedReceivedInvitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationJohnToDianaIntoFamily,
                InvitationSeeds.InvitationJohnToDianaIntoWork
            };
            var expectedSentInvitations = new List<InvitationEntity>
            {
                InvitationSeeds.InvitationDianaToCharlieIntoFamily
            };
            var expectedGroupUsers = new List<GroupUserEntity>
            {
                GroupUserSeeds.GroupUserDianaInFamily
            };

            // Act
            var actualUser = await SpendWiseDbContextSUT.Users
                .Where(u => u.Id == userIdToFetch)
                .Include(u => u.ReceivedInvitations)
                .Include(u => u.SentInvitations)
                .Include(u => u.GroupUsers)
                .SingleOrDefaultAsync();

            // Assert
            Assert.NotNull(actualUser); // Ensure the user is not null

            // Check ReceivedInvitations
            Assert.NotNull(actualUser.ReceivedInvitations);
            foreach (var expectedReceivedInvitation in expectedReceivedInvitations)
            {
                DeepAssert.Contains(expectedReceivedInvitation, actualUser.ReceivedInvitations);
            }

            // Check SentInvitations
            Assert.NotNull(actualUser.SentInvitations);
            Assert.Single(actualUser.SentInvitations);
            foreach (var expectedSentInvitation in expectedSentInvitations)
            {
                DeepAssert.Contains(expectedSentInvitation, actualUser.SentInvitations);
            }

            // Check GroupUsers
            Assert.NotNull(actualUser.GroupUsers);
            Assert.Single(actualUser.GroupUsers);
            Assert.Equal(expectedGroupUsers.Count(), actualUser.GroupUsers.Count());
            foreach (var expectedGroupUser in expectedGroupUsers)
            {
                DeepAssert.Contains(expectedGroupUser, actualUser.GroupUsers);
            }
        }

        #endregion

        #region Consistency Tests

        /// <summary>
        /// Tests to ensure the consistency of operations within the database. 
        /// These tests focus on verifying that operations are handled correctly even under concurrent scenarios.
        /// </summary>

        [Fact]
        /// <summary>
        /// Verifies that multiple users can be added concurrently, and all users are successfully persisted in the database without any data loss or corruption.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddUsers_Concurrently_UsersAreSuccessfullyPersisted()
        {
            // Arrange
            var baseTime = DateTime.UtcNow;
            // Ensure the base time is accurate to the millisecond for consistency
            baseTime = new DateTime(
                baseTime.Ticks - (baseTime.Ticks % TimeSpan.TicksPerMillisecond),
                DateTimeKind.Utc
            );

            // Create a list of users to be added concurrently
            var expectedUsersList = Enumerable.Range(0, 10).Select(i => new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Bob{i}",
                Surname = "Johnson",
                Email = $"bob{i}.johnson@spendwise.com",
                PasswordHash = "password456",
                DateOfRegistration = baseTime,
                Photo = Array.Empty<byte>(),
                IsEmailConfirmed = false,
                EmailConfirmationToken = null,
                ResetPasswordToken = null,
                ResetPasswordTokenExpiry = null,
                IsTwoFactorEnabled = false,
                TwoFactorSecret = null,
                Role = UserRole.User,
                PreferredTheme = Theme.SystemDefault
            }).ToList();

            // Act
            // Simultaneously add all users to the database in parallel tasks
            var addUserTasks = expectedUsersList.Select(user => Task.Run(async () =>
            {
                await using var dbContext = await DbContextFactory.CreateDbContextAsync();
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }));

            await Task.WhenAll(addUserTasks); // Wait for all tasks to complete

            // Assert
            await using var finalDbContext = await DbContextFactory.CreateDbContextAsync();
            var persistedUsers = await finalDbContext.Users
                .Where(u => expectedUsersList.Select(expectedUser => expectedUser.Id).Contains(u.Id))
                .ToListAsync();

            // Verify that the number of persisted users matches the expected number
            Assert.Equal(expectedUsersList.Count(), persistedUsers.Count());

            // Verify that each expected user was successfully persisted with correct data
            foreach (var expectedUser in expectedUsersList)
            {
                var actualUser = persistedUsers.SingleOrDefault(u => u.Id == expectedUser.Id);
                Assert.NotNull(actualUser);
                DeepAssert.Equal(expectedUser, actualUser);
            }
        }

        [Fact]
        /// <summary>
        /// Checks the integrity constraints after deleting a user, ensuring that the user and all related entities (invitations, group associations) are correctly removed.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteUser_CheckIntegrityConstraints_AfterDeletion()
        {
            // Arrange
            var userToDelete = await SpendWiseDbContextSUT.Users
                .AsNoTracking() // Ensure we are not tracking the original entity
                .FirstAsync(u => u.Id == UserSeeds.UserJohnDoe.Id);

            Assert.NotNull(userToDelete);

            // Act
            SpendWiseDbContextSUT.Users.Remove(userToDelete);
            await SpendWiseDbContextSUT.SaveChangesAsync();

            // Assert
            await using var dbContext = await DbContextFactory.CreateDbContextAsync();

            var deletedUser = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userToDelete.Id);
            Assert.Null(deletedUser); // Ensure the user is deleted

            var receivedInvitations = await dbContext.Invitations.Where(i => i.ReceiverId == userToDelete.Id).ToListAsync();
            Assert.Empty(receivedInvitations); // Ensure related invitations are removed

            var sentInvitations = await dbContext.Invitations.Where(i => i.SenderId == userToDelete.Id).ToListAsync();
            Assert.Empty(sentInvitations); // Ensure related invitations are removed

            var groupUsers = await dbContext.GroupUsers.Where(gu => gu.UserId == userToDelete.Id).ToListAsync();
            Assert.Empty(groupUsers); // Ensure related group users are removed
        }

        #endregion
    }
}
using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Tests.QueryObjectTests
{
    public class UserQueryObjectTests : UnitOfWorkTestsBase
    {
        public UserQueryObjectTests(ITestOutputHelper output) : base(output)
        {
        }

        #region IdQuery Tests

        /// <summary>
        /// Verifies that querying a user by its ID returns the correct entry from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithId_ShouldReturnCorrectUser()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithId(userId));

            // Assert
            Assert.NotNull(users);
            Assert.Single(users);
            Assert.Equal(userId, users.First().Id);
        }

        /// <summary>
        /// Verifies that querying a user by multiple IDs returns the correct entries that match any of the provided IDs.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithId_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userId1 = UserSeeds.UserJohnDoe.Id;
            var userId2 = UserSeeds.UserAliceSmith.Id;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithId(userId1).OrWithId(userId2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Id == userId1 || u.Id == userId2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific ID returns entries that do not match the ID.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithId_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedId = UserSeeds.UserJohnDoe.Id;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithId(excludedId));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedId, u.Id));
        }

        #endregion

        #region NameQuery Tests

        /// <summary>
        /// Verifies that querying a user by their name returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userName = UserSeeds.UserAliceSmith.Name;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithName(userName));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(userName, u.Name));
        }

        /// <summary>
        /// Verifies that querying a user by multiple names returns the correct entries that match any of the provided names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userName1 = UserSeeds.UserJohnDoe.Name;
            var userName2 = UserSeeds.UserAliceSmith.Name;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithName(userName1).OrWithName(userName2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Name == userName1 || u.Name == userName2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific name returns entries that do not contain the name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedName = UserSeeds.UserJohnDoe.Name;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithName(excludedName));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedName, u.Name));
        }

        /// <summary>
        /// Verifies that querying users by partial name match returns the correct entries that contain the specified text in their name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var partialName = "John";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithNamePartialMatch(partialName));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Contains(partialName, u.Name));
        }

        /// <summary>
        /// Verifies that querying users by multiple partial name matches returns the correct entries that contain any of the provided texts in their names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithNamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var partialName1 = "John";
            var partialName2 = "Alice";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithNamePartialMatch(partialName1).OrWithNamePartialMatch(partialName2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Name.Contains(partialName1) || u.Name.Contains(partialName2)));
        }

        /// <summary>
        /// Verifies that querying users by partial name match excludes entries that contain the specified text in their names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithNamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedText = "John";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithNamePartialMatch(excludedText));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedText, u.Name));
        }

        #endregion

        #region SurnameQuery Tests

        /// <summary>
        /// Verifies that querying a user by their surname returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSurname_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userSurname = UserSeeds.UserAliceSmith.Surname;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithSurname(userSurname));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(userSurname, u.Surname));
        }

        /// <summary>
        /// Verifies that querying a user by multiple surnames returns the correct entries that match any of the provided surnames.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSurname_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userSurname1 = UserSeeds.UserJohnDoe.Surname;
            var userSurname2 = UserSeeds.UserAliceSmith.Surname;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithSurname(userSurname1).OrWithSurname(userSurname2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Surname == userSurname1 || u.Surname == userSurname2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific surname returns entries that do not contain the surname.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithSurname_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedSurname = UserSeeds.UserJohnDoe.Surname;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithSurname(excludedSurname));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedSurname, u.Surname));
        }

        /// <summary>
        /// Verifies that querying users by partial surname match returns the correct entries that contain the specified text in their surname.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSurnamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var partialSurname = "Smith";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithSurnamePartialMatch(partialSurname));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Contains(partialSurname, u.Surname));
        }

        /// <summary>
        /// Verifies that querying users by multiple partial surname matches returns the correct entries that contain any of the provided texts in their surnames.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSurnamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var partialSurname1 = "Smith";
            var partialSurname2 = "Doe";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithSurnamePartialMatch(partialSurname1).OrWithSurnamePartialMatch(partialSurname2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Surname.Contains(partialSurname1) || u.Surname.Contains(partialSurname2)));
        }

        /// <summary>
        /// Verifies that querying users by partial surname match excludes entries that contain the specified text in their surnames.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithSurnamePartialMatch_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedText = "Doe";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithSurnamePartialMatch(excludedText));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedText, u.Surname));
        }

        #endregion

        #region EmailQuery Tests

        /// <summary>
        /// Verifies that querying a user by their email returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithEmail_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userEmail = UserSeeds.UserAliceSmith.Email;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithEmail(userEmail));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(userEmail, u.Email));
        }

        /// <summary>
        /// Verifies that querying a user by multiple emails returns the correct entries that match any of the provided emails.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithEmail_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userEmail1 = UserSeeds.UserJohnDoe.Email;
            var userEmail2 = UserSeeds.UserAliceSmith.Email;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithEmail(userEmail1).OrWithEmail(userEmail2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Email == userEmail1 || u.Email == userEmail2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific email returns entries that do not contain the email.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithEmail_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedEmail = UserSeeds.UserJohnDoe.Email;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithEmail(excludedEmail));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedEmail, u.Email));
        }

        #endregion

        #region PasswordQuery Tests

        /// <summary>
        /// Verifies that querying a user by their password returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithPassword_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userPassword = UserSeeds.UserAliceSmith.PasswordHash;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithPassword(userPassword));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(userPassword, u.PasswordHash));
        }

        /// <summary>
        /// Verifies that querying a user by multiple passwords returns the correct entries that match any of the provided passwords.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithPassword_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userPassword1 = UserSeeds.UserJohnDoe.PasswordHash;
            var userPassword2 = UserSeeds.UserAliceSmith.PasswordHash;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithPassword(userPassword1).OrWithPassword(userPassword2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.PasswordHash == userPassword1 || u.PasswordHash == userPassword2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific password returns entries that do not contain the password.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithPassword_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedPassword = UserSeeds.UserJohnDoe.PasswordHash;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithPassword(excludedPassword));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedPassword, u.PasswordHash));
        }

        #endregion

        #region DateOfRegistrationQuery Tests

        /// <summary>
        /// Verifies that querying a user by their date of registration returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithDateOfRegistration_ShouldReturnCorrectUsers()
        {
            // Arrange
            var dateOfRegistration = UserSeeds.UserAliceSmith.DateOfRegistration;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithDateOfRegistration(dateOfRegistration));

            // Assert
            Assert.NotNull(users);
            Assert.Single(users);
            Assert.All(users, u => Assert.Equal(dateOfRegistration, u.DateOfRegistration));
        }

        /// <summary>
        /// Verifies that querying a user by multiple dates of registration returns the correct entries that match any of the provided dates.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithDateOfRegistration_ShouldReturnCorrectUsers()
        {
            // Arrange
            var dateOfRegistration1 = UserSeeds.UserJohnDoe.DateOfRegistration;
            var dateOfRegistration2 = UserSeeds.UserAliceSmith.DateOfRegistration;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithDateOfRegistration(dateOfRegistration1).OrWithDateOfRegistration(dateOfRegistration2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.DateOfRegistration == dateOfRegistration1 || u.DateOfRegistration == dateOfRegistration2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific date of registration returns entries that do not contain the date.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithDateOfRegistration_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedDateOfRegistration = UserSeeds.UserJohnDoe.DateOfRegistration;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithDateOfRegistration(excludedDateOfRegistration));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedDateOfRegistration, u.DateOfRegistration));
        }

        #endregion

        #region PhotoQuery Tests

        /// <summary>
        /// Verifies that querying a user by their photo returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length > 0));
        }

        /// <summary>
        /// Verifies that querying a user by multiple photos returns the correct entries that match any of the provided photos.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length > 0));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific photo returns entries that do not contain the photo.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length == 0));
        }

        /// <summary>
        /// Verifies that querying users without a photo returns the correct entries that have a null photo.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithoutPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length == 0));
        }

        /// <summary>
        /// Verifies that querying users without a photo using an OR condition returns the correct entries that have a null photo.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithoutPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length == 0));
        }

        /// <summary>
        /// Verifies that querying users with a NOT condition for null photo excludes all transactions that have a null photo.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithoutPhoto());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Photo.Length > 0));
        }

        #endregion

        #region EmailConfirmedQuery Tests

        /// <summary>
        /// Verifies that querying a user by their email confirmed status returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsEmailConfirmed));
        }

        /// <summary>
        /// Verifies that querying a user by multiple email confirmed statuses returns the correct entries that match any of the provided statuses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsEmailConfirmed));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific email confirmed status returns entries that do not contain the status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsEmailConfirmed));
        }

        /// <summary>
        /// Verifies that querying users without email confirmed status returns the correct entries that have a false email confirmed status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithoutEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsEmailConfirmed));
        }

        /// <summary>
        /// Verifies that querying users without email confirmed status using an OR condition returns the correct entries that have a false email confirmed status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithoutEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsEmailConfirmed));
        }

        /// <summary>
        /// Verifies that querying users with a NOT condition for false email confirmed status excludes all transactions that have a false email confirmed status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithoutEmailConfirmed());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsEmailConfirmed));
        }

        #endregion

        #region TwoFactorEnabledQuery Tests

        /// <summary>
        /// Verifies that querying a user by their two-factor enabled status returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsTwoFactorEnabled));
        }

        /// <summary>
        /// Verifies that querying a user by multiple two-factor enabled statuses returns the correct entries that match any of the provided statuses.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsTwoFactorEnabled));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific two-factor enabled status returns entries that do not contain the status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsTwoFactorEnabled));
        }

        /// <summary>
        /// Verifies that querying users without two-factor enabled status returns the correct entries that have a false two-factor enabled status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithoutTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsTwoFactorEnabled));
        }

        /// <summary>
        /// Verifies that querying users without two-factor enabled status using an OR condition returns the correct entries that have a false two-factor enabled status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithoutTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.IsTwoFactorEnabled));
        }

        /// <summary>
        /// Verifies that querying users with a NOT condition for false two-factor enabled status excludes all transactions that have a false two-factor enabled status.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithoutTwoFactorEnabled());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.IsTwoFactorEnabled));
        }

        #endregion

        #region ResetPasswordTokenQuery Tests

        /// <summary>
        /// Verifies that querying a user by their reset password token returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var resetPasswordToken = UserSeeds.UserJohnDoe.ResetPasswordToken;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithResetPasswordToken(resetPasswordToken!));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(resetPasswordToken, u.ResetPasswordToken));
        }

        /// <summary>
        /// Verifies that querying a user by multiple reset password tokens returns the correct entries that match any of the provided tokens.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var resetPasswordToken1 = UserSeeds.UserJohnDoe.ResetPasswordToken;
            var resetPasswordToken2 = UserSeeds.UserAliceSmith.ResetPasswordToken;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithResetPasswordToken(resetPasswordToken1!).OrWithResetPasswordToken(resetPasswordToken2!));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.ResetPasswordToken == resetPasswordToken1 || u.ResetPasswordToken == resetPasswordToken2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific reset password token returns entries that do not contain the token.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedToken = UserSeeds.UserJohnDoe.ResetPasswordToken;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithResetPasswordToken(excludedToken!));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedToken, u.ResetPasswordToken));
        }

        /// <summary>
        /// Verifies that querying users without a reset password token returns the correct entries that have a null reset password token.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithoutResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithoutResetPasswordToken());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Null(u.ResetPasswordToken));
        }

        /// <summary>
        /// Verifies that querying users without a reset password token using an OR condition returns the correct entries that have a null reset password token.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithoutResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithoutResetPasswordToken());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Null(u.ResetPasswordToken));
        }

        /// <summary>
        /// Verifies that querying users with a NOT condition for null reset password token excludes all transactions that have a null reset password token.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithoutResetPasswordToken_ShouldReturnCorrectUsers()
        {
            // Arrange
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithoutResetPasswordToken());

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotNull(u.ResetPasswordToken));
        }

        #endregion

        #region PreferredThemeQuery Tests

        /// <summary>
        /// Verifies that querying a user by their preferred theme returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithPreferredTheme_ShouldReturnCorrectUsers()
        {
            // Arrange
            var preferredTheme = UserSeeds.UserAliceSmith.PreferredTheme;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithPreferredTheme(preferredTheme));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(preferredTheme, u.PreferredTheme));
        }

        /// <summary>
        /// Verifies that querying a user by multiple preferred themes returns the correct entries that match any of the provided themes.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithPreferredTheme_ShouldReturnCorrectUsers()
        {
            // Arrange
            var preferredTheme1 = UserSeeds.UserJohnDoe.PreferredTheme;
            var preferredTheme2 = UserSeeds.UserAliceSmith.PreferredTheme;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithPreferredTheme(preferredTheme1).OrWithPreferredTheme(preferredTheme2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.PreferredTheme == preferredTheme1 || u.PreferredTheme == preferredTheme2));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific preferred theme returns entries that do not contain the theme.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithPreferredTheme_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedTheme = UserSeeds.UserJohnDoe.PreferredTheme;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithPreferredTheme(excludedTheme));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedTheme, u.PreferredTheme));
        }

        #endregion

        #region SentInvitationQuery Tests

        /// <summary>
        /// Verifies that querying a user by their sent invitation returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithSentInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var invitation = InvitationSeeds.InvitationJohnToDianaIntoFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithSentInvitation(invitation.Id));

            // Assert
            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(invitation.SenderId, u.Id));
        }

        /// <summary>
        /// Verifies that querying a user by multiple sent invitations returns the correct entries that match any of the provided invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithSentInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var invitation1 = InvitationSeeds.InvitationJohnToDianaIntoFamily;
            var invitation2 = InvitationSeeds.InvitationJohnToDianaIntoWork;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithSentInvitation(invitation1.Id).OrWithSentInvitation(invitation2.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                Assert.True(u.Id == invitation1.SenderId || u.Id == invitation2.SenderId);
            });
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific sent invitation returns entries that do not contain the invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithSentInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedInvitation = InvitationSeeds.InvitationJohnToDianaIntoFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithSentInvitation(excludedInvitation.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedInvitation.SenderId, u.Id));
        }

        #endregion

        #region ReceivedInvitationQuery Tests

        /// <summary>
        /// Verifies that querying a user by their received invitation returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithReceivedInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var invitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithReceivedInvitation(invitation.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Equal(invitation.ReceiverId, u.Id));
        }

        /// <summary>
        /// Verifies that querying a user by multiple received invitations returns the correct entries that match any of the provided invitations.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithReceivedInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var invitation1 = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var invitation2 = InvitationSeeds.InvitationJohnToDianaIntoFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithReceivedInvitation(invitation1.Id).OrWithReceivedInvitation(invitation2.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                Assert.True(u.Id == invitation1.ReceiverId || u.Id == invitation2.ReceiverId);
            });
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific received invitation returns entries that do not contain the invitation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithReceivedInvitation_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedInvitation = InvitationSeeds.InvitationDianaToCharlieIntoFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithReceivedInvitation(excludedInvitation.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(excludedInvitation.ReceiverId, u.Id));
        }

        #endregion

        #region GroupUserQuery Tests

        /// <summary>
        /// Verifies that querying a user by their group user returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithGroupUser_ShouldReturnCorrectUsers()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserJohnInFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithGroupUser(groupUser.Id));

            // Assert
            Assert.NotNull(users);
            Assert.Single(users);
            Assert.Equal(groupUser.UserId, users.First().Id);
        }

        /// <summary>
        /// Verifies that querying a user by multiple group users returns the correct entries that match any of the provided group users.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithGroupUser_ShouldReturnCorrectUsers()
        {
            // Arrange
            var groupUser1 = GroupUserSeeds.GroupUserJohnInFamily;
            var groupUser2 = GroupUserSeeds.GroupUserJohnInFriends;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithGroupUser(groupUser1.Id).OrWithGroupUser(groupUser2.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(new[] { groupUser1, groupUser2 }, gu =>
                Assert.Contains(users, u => u.Id == gu.UserId));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific group user returns entries that do not contain the group user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithGroupUser_ShouldReturnCorrectUsers()
        {
            // Arrange
            var groupUser = GroupUserSeeds.GroupUserJohnInFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithGroupUser(groupUser.Id));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.NotEqual(groupUser.UserId, u.Id));
        }

        #endregion

        #region FullNameAndEmailDomainFilters Tests

        /// <summary>
        /// Verifies that querying a user by their full name returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithFullName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var fullName = "John Doe";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithFullName(fullName));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.Contains(fullName, u.Name + " " + u.Surname));
        }

        /// <summary>
        /// Verifies that querying a user by multiple full names returns the correct entries that match any of the provided full names.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithFullName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var fullName1 = "John Doe";
            var fullName2 = "Alice Smith";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithFullName(fullName1).OrWithFullName(fullName2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True((u.Name + " " + u.Surname).Contains(fullName1) || (u.Name + " " + u.Surname).Contains(fullName2)));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific full name returns entries that do not contain the full name.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithFullName_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedFullName = "John Doe";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithFullName(excludedFullName));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.DoesNotContain(excludedFullName, u.Name + " " + u.Surname));
        }

        /// <summary>
        /// Verifies that querying a user by their email domain returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithEmailDomain_ShouldReturnCorrectUsers()
        {
            // Arrange
            var emailDomain = "spendwise.com";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.WithEmailDomain(emailDomain));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.EndsWith("@" + emailDomain, u.Email));
        }

        /// <summary>
        /// Verifies that querying a user by multiple email domains returns the correct entries that match any of the provided domains.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task OrWithEmailDomain_ShouldReturnCorrectUsers()
        {
            // Arrange
            var emailDomain1 = "spendwise.com";
            var emailDomain2 = "google.com";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.OrWithEmailDomain(emailDomain1).OrWithEmailDomain(emailDomain2));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.True(u.Email.EndsWith("@" + emailDomain1) || u.Email.EndsWith("@" + emailDomain2)));
        }

        /// <summary>
        /// Verifies that querying users by excluding a specific email domain returns entries that do not contain the domain.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task NotWithEmailDomain_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedDomain = "spendwise.com";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(queryObject.NotWithEmailDomain(excludedDomain));

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u => Assert.False(u.Email.EndsWith("@" + excludedDomain)));
        }

        #endregion

        #region Complex Query Tests

        /// <summary>
        /// Verifies that querying users with a combination of AND, OR, and NOT conditions returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithEmailOrWithGroupUserIdNotWithRole_ShouldReturnCorrectUsers()
        {
            // Arrange
            var email = UserSeeds.UserJohnDoe.Email;
            var groupUser = GroupUserSeeds.GroupUserCharlieInFamily;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithEmail(email)
                               .OrWithGroupUser(groupUser.Id)
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isEmailMatch = u.Email == email;
                bool isGroupUserIdMatch = u.Id == groupUser.UserId;

                Assert.True(isEmailMatch || isGroupUserIdMatch);
            });
        }

        /// <summary>
        /// Verifies that querying users with a combination of multiple AND and OR conditions returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdOrWithSurnameNotWithPhoto_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var surname = UserSeeds.UserDianaGreen.Surname;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithId(userId)
                               .OrWithSurname(surname)
                               .NotWithPhoto()
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isUserIdMatch = u.Id == userId;
                bool isSurnameMatch = u.Surname.Contains(surname);
                bool hasPhoto = u.Photo.Length > 0;

                Assert.True((isUserIdMatch || isSurnameMatch) && !hasPhoto);
            });
        }

        /// <summary>
        /// Verifies that querying users using a mix of AND and OR conditions, while excluding specific email domains, returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNameOrWithEmailNotWithEmailDomain_ShouldReturnCorrectUsers()
        {
            // Arrange
            var name = UserSeeds.UserCharlieBlack.Name;
            var email = UserSeeds.UserDianaGreen.Email;
            var excludedEmailDomain = "spendwise.com";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithName(name)
                               .OrWithEmail(email)
                               .NotWithEmailDomain(excludedEmailDomain)
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isNameMatch = u.Name.Contains(name);
                bool isEmailMatch = u.Email.Contains(email);
                bool isEmailDomainMatch = u.Email.EndsWith("@" + excludedEmailDomain);

                Assert.True((isNameMatch || isEmailMatch) && !isEmailDomainMatch);
            });
        }

        /// <summary>
        /// Verifies that querying users with a combination of ID and confirmed email, but without two-factor authentication, returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithIdAndWithEmailConfirmedNotWithTwoFactorEnabled_ShouldReturnCorrectUsers()
        {
            // Arrange
            var userId = UserSeeds.UserJohnDoe.Id;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithId(userId)
                               .WithEmailConfirmed()
                               .NotWithTwoFactorEnabled()
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isUserIdMatch = u.Id == userId;
                bool isEmailConfirmed = u.IsEmailConfirmed;
                bool isTwoFactorEnabled = u.IsTwoFactorEnabled;

                Assert.True(isUserIdMatch && isEmailConfirmed && !isTwoFactorEnabled);
            });
        }

        /// <summary>
        /// Verifies that querying users with a combination of name or surname, but without the Admin role, returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithNameOrWithSurnameNotWithRoleAdmin_ShouldReturnCorrectUsers()
        {
            // Arrange
            var name = "John";
            var surname = "Smith";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithName(name)
                               .OrWithSurname(surname)
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isNameMatch = u.Name.Contains(name);
                bool isSurnameMatch = u.Surname.Contains(surname);

                Assert.True(isNameMatch || isSurnameMatch);
            });
        }

        /// <summary>
        /// Verifies that querying users with a combination of reset password token or confirmed email, but without a specific email domain, returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithResetPasswordTokenOrWithEmailConfirmedNotWithEmailDomain_ShouldReturnCorrectUsers()
        {
            // Arrange
            var excludedEmailDomain = "google.com";
            var resetPasswordToken = UserSeeds.UserJohnDoe.ResetPasswordToken;
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithResetPasswordToken(resetPasswordToken!)
                               .OrWithEmailConfirmed()
                               .NotWithEmailDomain(excludedEmailDomain)
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool hasResetPasswordToken = string.IsNullOrEmpty(u.ResetPasswordToken);
                bool isEmailConfirmed = u.IsEmailConfirmed;
                bool isEmailDomainMatch = u.Email.EndsWith("@" + excludedEmailDomain);

                Assert.True((hasResetPasswordToken || isEmailConfirmed) && !isEmailDomainMatch);
            });
        }

        /// <summary>
        /// Verifies that querying users with a combination of full name or having a photo, but without confirmed email, returns the correct entries.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task WithFullNameOrWithPhotoNotWithEmailConfirmed_ShouldReturnCorrectUsers()
        {
            // Arrange
            var fullName = "John Doe";
            var queryObject = new UserQueryObject();

            // Act
            var users = await _unitOfWork.UserRepository
                .ListAsync(
                    queryObject.WithFullName(fullName)
                               .OrWithPhoto()
                               .NotWithEmailConfirmed()
                );

            // Assert
            Assert.NotNull(users);
            Assert.All(users, u =>
            {
                bool isFullNameMatch = (u.Name + " " + u.Surname).Contains(fullName);
                bool hasPhoto = u.Photo.Length > 0;
                bool isEmailConfirmed = u.IsEmailConfirmed;

                Assert.True((isFullNameMatch || hasPhoto) && !isEmailConfirmed);
            });
        }

        #endregion
    }
}

using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Contains tests for operations related to users using the Unit of Work pattern.
    /// </summary>
    public class UnitOfWorkUserTests : UnitOfWorkTestsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkUserTests"/> class.
        /// </summary>
        /// <param name="output">The output helper instance.</param>
        public UnitOfWorkUserTests(ITestOutputHelper output) : base(output)
        {
        }

        // ====================================
        // CRUD Operations Tests
        // ====================================

        /// <summary>
        /// Tests if inserting a new user with valid data correctly adds the user to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertUser_AddsUserToDatabase()
        {
            // Arrange
            var newUserDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "New",
                Surname = "User",
                Email = "new.user@spendwise.com",
                Password = "password987",
                Date_of_registration = DateTime.UtcNow,
                Photo = new byte[] { }
            };

            // Act
            await _unitOfWork.Users.InsertAsync(newUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var userInDb = await _unitOfWork.Users.GetByIdAsync(newUserDto.Id);
            Assert.NotNull(userInDb);
            DeepAssert.Equal(newUserDto, userInDb);
        }

        /// <summary>
        /// Tests if fetching a user by an existing ID returns the correct user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            var expectedUserDto = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            // Act
            var fetchedUserDto = await _unitOfWork.Users.GetByIdAsync(expectedUserDto.Id);

            // Assert
            Assert.NotNull(fetchedUserDto);
            DeepAssert.Equal(expectedUserDto, fetchedUserDto);
        }

        /// <summary>
        /// Tests if updating a user with valid data correctly updates the user in the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_UpdatesUserInDatabase()
        {
            // Arrange
            var existingUserDto = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            var updatedUserDto = existingUserDto with
            {
                Surname = "UpdatedDoe",
                Email = "updated.john.doe@spendwise.com"
            };

            // Act
            await _unitOfWork.Users.UpdateAsync(updatedUserDto);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var resultUserDto = await _unitOfWork.Users.GetByIdAsync(updatedUserDto.Id);
            Assert.NotNull(resultUserDto);
            DeepAssert.Equal(updatedUserDto, resultUserDto);
        }

        /// <summary>
        /// Tests if deleting a user by an existing ID correctly removes the user from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_RemovesUserFromDatabase()
        {
            // Arrange
            var userDto = _mapper.Map<UserDto>(UserSeeds.UserJaneSmith);

            // Act
            await _unitOfWork.Users.DeleteAsync(userDto.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedUser = await _unitOfWork.Users.GetByIdAsync(userDto.Id);
            Assert.Null(deletedUser);
        }
    }
}

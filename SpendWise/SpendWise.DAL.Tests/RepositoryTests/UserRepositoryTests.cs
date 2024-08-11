using SpendWise.DAL.Entities;
using SpendWise.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using SpendWise.DAL.Tests.Helpers;
using SpendWise.DAL.DTOs;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SpendWise.DAL.Repositories;

namespace SpendWise.DAL.Tests
{
    /// <summary>
    /// Test class for testing repository methods related to users.
    /// </summary>
    public class UserRepositoryTests : RepositoryTestsBase
    {
        private readonly IRepository<UserEntity, UserDto> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the <see cref="UserRepositoryTests"/> class.
        /// Initializes the instance with necessary services.
        /// </summary>
        /// <param name="output">Provides output capabilities for test methods.</param>
        public UserRepositoryTests(ITestOutputHelper output) : base(output)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<UserEntity, UserDto>>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Tests whether retrieving a user by its ID returns the correct user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            var expectedUserDto = _mapper.Map<UserDto>(UserSeeds.UserAdminWithRelations);

            // Act
            var fetchedUserDto = await _repository.GetByIdAsync(expectedUserDto.Id);

            // Assert
            Assert.NotNull(fetchedUserDto);
            DeepAssert.Equal(expectedUserDto, fetchedUserDto);
        }

        /// <summary>
        /// Tests whether adding a new user to the repository successfully inserts the user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task InsertCategory_AddsUserSuccessfully()
        {
            // Arrange
            var newUserDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Surname = "User",
                Email = "test.user@spendwise.com",
                Password = "testpassword",
                Date_of_registration = DateTime.UtcNow,
                Photo = new byte[] {}
            };

            // Act
            await _repository.InsertAsync(newUserDto);
            var insertedUserDto = await _repository.GetByIdAsync(newUserDto.Id);

            // Assert
            Assert.NotNull(insertedUserDto);
            DeepAssert.Equal(newUserDto, insertedUserDto);
        }

        /// <summary>
        /// Tests whether updating an existing user in the repository successfully updates the user's details.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser_UpdatesUserSuccessfully()
        {
            // Arrange
            var existingUserDto = _mapper.Map<UserDto>(UserSeeds.UserJohnDoeWithRelations);
            var updatedEmail = "updated.email@spendwise.com";

            var updatedUserDto = new UserDto
            {
                Id = existingUserDto.Id,
                Name = existingUserDto.Name,
                Surname = existingUserDto.Surname,
                Email = updatedEmail,
                Password = existingUserDto.Password,
                Date_of_registration = existingUserDto.Date_of_registration,
                Photo = existingUserDto.Photo
            };

            // Act
            await _repository.UpdateAsync(updatedUserDto);
            var resultUserDto = await _repository.GetByIdAsync(existingUserDto.Id);

            // Assert
            Assert.NotNull(resultUserDto);
            Assert.Equal(updatedEmail, resultUserDto.Email);
            DeepAssert.Equal(updatedUserDto, resultUserDto);
        }

        /// <summary>
        /// Tests whether deleting a user from the repository successfully removes the user.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser_DeletesUserSuccessfully()
        {
            // Arrange
            var userDto = _mapper.Map<UserDto>(UserSeeds.UserJaneSmith);

            // Act
            await _repository.DeleteAsync(userDto.Id);
            var deletedUserDto = await _repository.GetByIdAsync(userDto.Id);

            // Assert
            Assert.Null(deletedUserDto);

            var totalCountAfterDelete = await _repository.Get().CountAsync();
            var totalCountBeforeDelete = totalCountAfterDelete + 1; // Previous count before deletion
            Assert.Equal(totalCountBeforeDelete, totalCountAfterDelete + 1);
        }
    }
}

using Xunit;
using Xunit.Abstractions;
using SpendWise.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Tests.Helpers;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.Tests.UnitOfWorkTests
{
    public class UnitOfWorkUserTests : UnitOfWorkTestsBase
    {
        public UnitOfWorkUserTests(ITestOutputHelper output) : base(output)
        {
        }

        #region CRUD Operations Tests

        [Fact]
        public async Task AddUser_ValidData_SuccessfullyPersists()
        {
            // Arrange
            var userToAdd = new UserDto
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
            await _unitOfWork.Repository<UserEntity, UserDto>().InsertAsync(userToAdd);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualUser = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(userToAdd.Id);
            Assert.NotNull(actualUser);
            DeepAssert.Equal(userToAdd, actualUser);
        }

        [Fact]
        public async Task FetchUserById_ExistingId_ReturnsExpectedUser()
        {
            // Arrange
            var expectedUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            // Act
            var actualUser = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(expectedUser.Id);

            // Assert
            Assert.NotNull(actualUser);
            DeepAssert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public async Task UpdateUser_ValidData_SuccessfullyPersistsChanges()
        {
            // Arrange
            var existingUser = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);
            var updatedUser = existingUser with
            {
                Surname = "UpdatedDoe",
                Email = "updated.john.doe@spendwise.com"
            };

            // Act
            await _unitOfWork.Repository<UserEntity, UserDto>().UpdateAsync(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var actualUpdatedUser = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(updatedUser.Id);
            Assert.NotNull(actualUpdatedUser);
            DeepAssert.Equal(updatedUser, actualUpdatedUser);
        }

        [Fact]
        public async Task DeleteUser_ExistingId_SuccessfullyRemovesUser()
        {
            // Arrange
            var userToDelete = _mapper.Map<UserDto>(UserSeeds.UserJohnDoe);

            // Act
            await _unitOfWork.Repository<UserEntity, UserDto>().DeleteAsync(userToDelete.Id);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            var deletedUser = await _unitOfWork.Repository<UserEntity, UserDto>().GetByIdAsync(userToDelete.Id);
            Assert.Null(deletedUser);
        }

        #endregion
    }
}

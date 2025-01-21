using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.Common.Tests.Helpers;
using SpendWise.Common.Enums;
using SpendWise.Common.Tests.Seeds;
using SpendWise.Common.Extensions;

namespace SpendWise.BLL.Tests.ServicesTests
{
    /// <summary>
    /// Contains tests for category-related handlers focusing on relations.
    /// </summary>
    public class UserServiceTests : ServicesTestsBase
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceTests"/> class.
        /// </summary>
        /// <param name="output">The test output helper.</param>
        public UserServiceTests(ITestOutputHelper output) : base(output)
        {
            _output = output;
        }

        #region List Users

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByName()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(name: "John");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotName()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList

            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notName: "Alice");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNamePartialMatch()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(namePartialMatch: "Jo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotNamePartialMatch()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notNamePartialMatch: "Jo");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedBySurname()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(surname: "Doe");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotSurname()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notSurname: "Doe");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedBySurnamePartialMatch()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(surnamePartialMatch: "Do");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotSurnamePartialMatch()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notSurnamePartialMatch: "Do");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByEmail()
        {
            // Arrange
            var expectedUsers = ExpectedUserServiceResults.UserCharlieBlackInFamilyList;
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(email: "charlie.black@spendwise.com");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedUsers, result.FirstOrDefault(), propertiesToIgnore: ["Transactions"]);
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotEmail()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notEmail: "charlie.black@spendwise.com");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByPasswordHash()
        {
            // Arrange
            var expectedUsers = ExpectedUserServiceResults.UserCharlieBlackInFamilyList;
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(passwordHash: "hashed_password_4");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedUsers, result.FirstOrDefault(), propertiesToIgnore: ["Transactions"]);
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByDateOfRegistration()
        {
            // Arrange
            var expectedUsers = ExpectedUserServiceResults.UserCharlieBlackInFamilyList;
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(dateOfRegistration: new DateTime(2024, 6, 19, 11, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedUsers, result.FirstOrDefault(), propertiesToIgnore: ["Transactions"]);
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotDateOfRegistration()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notDateOfRegistration: new DateTime(2024, 6, 15, 11, 0, 0, DateTimeKind.Utc));

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByWithPhoto()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(withPhoto: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotWithPhoto()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(withPhoto: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByEmailConfirmed()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(emailConfirmed: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotEmailConfirmed()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(emailConfirmed: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByTwoFactorEnabled()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(twoFactorEnabled: true);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotTwoFactorEnabled()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(twoFactorEnabled: false);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByResetPasswordToken()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(resetPasswordToken: UserSeeds.UserJohnDoe.ResetPasswordToken);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByPreferredTheme()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(preferredTheme: Theme.SystemDefault);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotPreferredTheme()
        {
            // Arrange
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notPreferredTheme: Theme.SystemDefault);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedBySentInvitationId()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(sentInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotSentInvitationId()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
    {
        ExpectedUserServiceResults.UserBobBrownInFamilyList,
        ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
        ExpectedUserServiceResults.UserDianaGreenInFamilyList
    };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notSentInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByReceivedInvitationId()
        {
            // Arrange
            var expectedUsers = ExpectedUserServiceResults.UserCharlieBlackInFamilyList;
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(receivedInvitationId: InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedUsers, result.FirstOrDefault(), propertiesToIgnore: ["Transactions"]);
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotReceivedInvitationId()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notReceivedInvitationId: InvitationSeeds.InvitationJohnToDianaIntoFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByGroupId()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(groupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotGroupId()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notGroupId: GroupSeeds.GroupFamily.Id);

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByFullName()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(fullName: "John Doe");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotFullName()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList,
                ExpectedUserServiceResults.UserDianaGreenInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notFullName: "John Doe");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByEmailDomain()
        {
            // Arrange
            var expectedUsers = new List<UserListDto>
            {
                ExpectedUserServiceResults.UserJohnDoeInFamilyList,
                ExpectedUserServiceResults.UserJohnDoeInFriendsList,
                ExpectedUserServiceResults.UserJohnDoeInWorkList,
                ExpectedUserServiceResults.UserBobBrownInFamilyList,
                ExpectedUserServiceResults.UserCharlieBlackInFamilyList
            };
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(emailDomain: "spendwise.com");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedUsers.Count(), result.Count());
            foreach (var expectedUser in expectedUsers)
            {
                DeepAssert.Contains(expectedUser, result, propertiesToIgnore: ["Transactions"]);
            }
        }

        /// <summary>
        /// Tests the <see cref="GetUsersByCriteriaQueryHandler"/> class.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenQueriedByNotEmailDomain()
        {
            // Arrange
            var expectedUsers = ExpectedUserServiceResults.UserDianaGreenInFamilyList;
            var handler = _serviceProvider.
                GetRequiredService<IGetUsersByCriteriaQueryHandler<UserListDto>>();
            var query = new GetUsersByCriteriaQuery(notEmailDomain: "spendwise.com");

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
            DeepAssert.Equal(expectedUsers, result.FirstOrDefault(), propertiesToIgnore: ["Transactions"]);
        }
        #endregion
    }
}
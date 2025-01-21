using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.BLL.Mappers;
using SpendWise.DAL.Mappers;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for user DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedUserServiceResults
    {
        private static IMapper _BLL_mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TransactionMappingProfile>();
            cfg.AddProfile<CategoryMappingProfile>();
            cfg.AddProfile<GroupMappingProfile>();
            cfg.AddProfile<UserMappingProfile>();
        }).CreateMapper();

        private static IMapper _DAL_mapper => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        }).CreateMapper();
        /// <summary>
        /// Gets the expected result for user John Doe as a list DTO.
        /// </summary>
        public static readonly UserListDto UserJohnDoeInFamilyList = new()
        {
            Id = UserSeeds.UserJohnDoe.Id,
            Role = GroupUserSeeds.GroupUserJohnInFamily.Role,
            Name = UserSeeds.UserJohnDoe.Name,
            Surname = UserSeeds.UserJohnDoe.Surname,
            Photo = UserSeeds.UserJohnDoe.Photo,
            Transactions = new List<TransactionListDto>
            {
                _BLL_mapper.Map<TransactionListDto>(_DAL_mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn)),
            }
        };

        /// <summary>
        /// Gets the expected result for user John Doe as a list DTO.
        /// </summary>
        public static readonly UserListDto UserJohnDoeInWorkList = new()
        {
            Id = UserSeeds.UserJohnDoe.Id,
            Role = GroupUserSeeds.GroupUserJohnInFriends.Role,
            Name = UserSeeds.UserJohnDoe.Name,
            Surname = UserSeeds.UserJohnDoe.Surname,
            Photo = UserSeeds.UserJohnDoe.Photo,
            Transactions = new List<TransactionListDto>
            {
                _BLL_mapper.Map<TransactionListDto>(_DAL_mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserTransportWorkJohn)),
            }
        };

        /// <summary>
        /// Gets the expected result for user John Doe as a list DTO.
        /// </summary>
        public static readonly UserListDto UserJohnDoeInFriendsList = new()
        {
            Id = UserSeeds.UserJohnDoe.Id,
            Role = GroupUserSeeds.GroupUserJohnInFriends.Role,
            Name = UserSeeds.UserJohnDoe.Name,
            Surname = UserSeeds.UserJohnDoe.Surname,
            Photo = UserSeeds.UserJohnDoe.Photo,
            Transactions = new List<TransactionListDto>
            {
                _BLL_mapper.Map<TransactionListDto>(_DAL_mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserTaxiFriendsJohn)),
                _BLL_mapper.Map<TransactionListDto>(_DAL_mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserTransportFriendsJohn))
            }
        };

        /// <summary>
        /// Gets the expected result for user John Doe as a list DTO.
        /// </summary>
        public static readonly UserListDto UserJohnDoeList = UserJohnDoeInFriendsList with { Role = null, Transactions = new List<TransactionListDto>() };

        /// <summary>
        /// Gets the expected result for user Alice Smith as a list DTO.
        /// </summary>
        public static readonly UserListDto UserAliceSmithList = new()
        {
            Id = UserSeeds.UserAliceSmith.Id,
            Role = null,
            Name = UserSeeds.UserAliceSmith.Name,
            Surname = UserSeeds.UserAliceSmith.Surname,
            Photo = UserSeeds.UserAliceSmith.Photo,
            Transactions = new List<TransactionListDto>()
        };

        /// <summary>
        /// Gets the expected result for user Bob Brown as a list DTO.
        /// </summary>
        public static readonly UserListDto UserBobBrownInFamilyList = new()
        {
            Id = UserSeeds.UserBobBrown.Id,
            Role = GroupUserSeeds.GroupUserBobInFamily.Role,
            Name = UserSeeds.UserBobBrown.Name,
            Surname = UserSeeds.UserBobBrown.Surname,
            Photo = UserSeeds.UserBobBrown.Photo,
            Transactions = new List<TransactionListDto>()
        };

        /// <summary>
        /// Gets the expected result for user Bob Brown as a list DTO.
        /// </summary>
        public static readonly UserListDto UserBobBrownList = UserBobBrownInFamilyList with { Role = null };

        /// <summary>
        /// Gets the expected result for user Charlie Black as a list DTO.
        /// </summary>
        public static readonly UserListDto UserCharlieBlackInFamilyList = new()
        {
            Id = UserSeeds.UserCharlieBlack.Id,
            Role = GroupUserSeeds.GroupUserCharlieInFamily.Role,
            Name = UserSeeds.UserCharlieBlack.Name,
            Surname = UserSeeds.UserCharlieBlack.Surname,
            Photo = UserSeeds.UserCharlieBlack.Photo,
            Transactions = new List<TransactionListDto>()
        };

        /// <summary>
        /// Gets the expected result for user Charlie Black as a list DTO.
        /// </summary>
        public static readonly UserListDto UserCharlieBlackList = UserCharlieBlackInFamilyList with { Role = null };

        /// <summary>
        /// Gets the expected result for user Diana Green as a list DTO.
        /// </summary>
        public static readonly UserListDto UserDianaGreenInFamilyList = new()
        {
            Id = UserSeeds.UserDianaGreen.Id,
            Role = GroupUserSeeds.GroupUserDianaInFamily.Role,
            Name = UserSeeds.UserDianaGreen.Name,
            Surname = UserSeeds.UserDianaGreen.Surname,
            Photo = UserSeeds.UserDianaGreen.Photo,
            Transactions = new List<TransactionListDto>
            {
                _BLL_mapper.Map<TransactionListDto>(_DAL_mapper.Map<TransactionGroupUserDto>(TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana)),
            }
        };

        /// <summary>
        /// Gets the expected result for user Diana Green as a list DTO.
        /// </summary>
        public static readonly UserListDto UserDianaGreenList = UserDianaGreenInFamilyList with { Role = null, Transactions = new List<TransactionListDto>() };

        /// <summary>
        /// Gets the expected result for user John Doe as a summary DTO.
        /// </summary>
        public static readonly UserSummaryDto UserJohnDoeSummary = new()
        {
            Id = UserSeeds.UserJohnDoe.Id,
            Name = UserSeeds.UserJohnDoe.Name,
            Surname = UserSeeds.UserJohnDoe.Surname,
            Photo = UserSeeds.UserJohnDoe.Photo,
        };

        /// <summary>
        /// Gets the expected result for user Alice Smith as a summary DTO.
        /// </summary>
        public static readonly UserSummaryDto UserAliceSmithSummary = new()
        {
            Id = UserSeeds.UserAliceSmith.Id,
            Name = UserSeeds.UserAliceSmith.Name,
            Surname = UserSeeds.UserAliceSmith.Surname,
            Photo = UserSeeds.UserAliceSmith.Photo,
        };

        /// <summary>
        /// Gets the expected result for user Bob Brown as a summary DTO.
        /// </summary>
        public static readonly UserSummaryDto UserBobBrownSummary = new()
        {
            Id = UserSeeds.UserBobBrown.Id,
            Name = UserSeeds.UserBobBrown.Name,
            Surname = UserSeeds.UserBobBrown.Surname,
            Photo = UserSeeds.UserBobBrown.Photo,
        };

        /// <summary>
        /// Gets the expected result for user Charlie Black as a summary DTO.
        /// </summary>
        public static readonly UserSummaryDto UserCharlieBlackSummary = new()
        {
            Id = UserSeeds.UserCharlieBlack.Id,
            Name = UserSeeds.UserCharlieBlack.Name,
            Surname = UserSeeds.UserCharlieBlack.Surname,
            Photo = UserSeeds.UserCharlieBlack.Photo,
        };

        /// <summary>
        /// Gets the expected result for user Diana Green as a summary DTO.
        /// </summary>
        public static readonly UserSummaryDto UserDianaGreenSummary = new()
        {
            Id = UserSeeds.UserDianaGreen.Id,
            Name = UserSeeds.UserDianaGreen.Name,
            Surname = UserSeeds.UserDianaGreen.Surname,
            Photo = UserSeeds.UserDianaGreen.Photo,
        };
    }
}
using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.BLL.Mappers;
using SpendWise.DAL.Mappers;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for group DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedGroupServiceResults
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
        /// Gets the expected result for the family group as a detail DTO.
        /// </summary>
        public static readonly GroupDetailDto GroupFamilyDetail = new()
        {
            Id = GroupSeeds.GroupFamily.Id,
            Name = GroupSeeds.GroupFamily.Name,
            Description = GroupSeeds.GroupFamily.Description,
            GroupParticipants = new List<UserListDto>
            {
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserBobInFamily)),
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserCharlieInFamily)),
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserDianaInFamily)),
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnInFamily))
            }
        };

        /// <summary>
        /// Gets the expected result for the friends group as a detail DTO.
        /// </summary>
        public static readonly GroupDetailDto GroupFriendsDetail = new()
        {
            Id = GroupSeeds.GroupFriends.Id,
            Name = GroupSeeds.GroupFriends.Name,
            Description = GroupSeeds.GroupFriends.Description,
            GroupParticipants = new List<UserListDto>
            {
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnInFriends))
            }
        };

        /// <summary>
        /// Gets the expected result for the work group as a detail DTO.
        /// </summary>
        public static readonly GroupDetailDto GroupWorkDetail = new()
        {
            Id = GroupSeeds.GroupWork.Id,
            Name = GroupSeeds.GroupWork.Name,
            Description = GroupSeeds.GroupWork.Description,
            GroupParticipants = new List<UserListDto>
            {
                _BLL_mapper.Map<UserListDto>(_DAL_mapper.Map<GroupUserDto>(GroupUserSeeds.GroupUserJohnInWork))
            }
        };

        /// <summary>
        /// Gets the expected result for the family group as a list DTO.
        /// </summary>
        public static readonly GroupListDto GroupFamilyList = new()
        {
            Id = GroupSeeds.GroupFamily.Id,
            Name = GroupSeeds.GroupFamily.Name,
            Description = GroupSeeds.GroupFamily.Description,
            GroupParticipants = new List<UserSummaryDto>
            {

                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserBobBrown)),
                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserCharlieBlack)),
                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserDianaGreen)),
                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
            }
        };

        /// <summary>
        /// Gets the expected result for the friends group as a list DTO.
        /// </summary>
        public static readonly GroupListDto GroupFriendsList = new()
        {
            Id = GroupSeeds.GroupFriends.Id,
            Name = GroupSeeds.GroupFriends.Name,
            Description = GroupSeeds.GroupFriends.Description,
            GroupParticipants = new List<UserSummaryDto>
            {
                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
            }
        };

        /// <summary>
        /// Gets the expected result for the work group as a list DTO.
        /// </summary>
        public static readonly GroupListDto GroupWorkList = new()
        {
            Id = GroupSeeds.GroupWork.Id,
            Name = GroupSeeds.GroupWork.Name,
            Description = GroupSeeds.GroupWork.Description,
            GroupParticipants = new List<UserSummaryDto>
            {
                _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
            }
        };

        /// <summary>
        /// Gets the expected result for the family group as a summary DTO.
        /// </summary>
        public static readonly GroupSummaryDto GroupFamilySummary = new()
        {
            Id = GroupSeeds.GroupFamily.Id,
            Name = GroupSeeds.GroupFamily.Name
        };

        /// <summary>
        /// Gets the expected result for the friends group as a summary DTO.
        /// </summary>
        public static readonly GroupSummaryDto GroupFriendsSummary = new()
        {
            Id = GroupSeeds.GroupFriends.Id,
            Name = GroupSeeds.GroupFriends.Name
        };

        /// <summary>
        /// Gets the expected result for the work group as a summary DTO.
        /// </summary>
        public static readonly GroupSummaryDto GroupWorkSummary = new()
        {
            Id = GroupSeeds.GroupWork.Id,
            Name = GroupSeeds.GroupWork.Name
        };
    }
}
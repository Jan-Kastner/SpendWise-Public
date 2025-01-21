using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.BLL.Mappers;
using SpendWise.DAL.Mappers;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for transaction DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedTransactionServiceResults
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
        /// Gets the expected result for Diana's dinner transaction as a list DTO.
        /// </summary>
        public static readonly TransactionListDto TransactionDinnerFamilyDianaList = new()
        {
            Id = TransactionSeeds.TransactionDianaDinner.Id,
            Amount = TransactionSeeds.TransactionDianaDinner.Amount,
            Date = TransactionSeeds.TransactionDianaDinner.Date,
            Description = TransactionSeeds.TransactionDianaDinner.Description,
            Type = TransactionSeeds.TransactionDianaDinner.Type,
            IsRead = TransactionGroupUserSeeds.TransactionGroupUserDinnerFamilyDiana.IsRead,
            Category = null,
            CategoryId = null
        };

        /// <summary>
        /// Gets the expected result for John's groceries transaction as a list DTO.
        /// </summary>
        public static readonly TransactionListDto TransactionJohnFoodFamilyList = new()
        {
            Id = TransactionSeeds.TransactionJohnFood.Id,
            Amount = TransactionSeeds.TransactionJohnFood.Amount,
            Date = TransactionSeeds.TransactionJohnFood.Date,
            Description = TransactionSeeds.TransactionJohnFood.Description,
            Type = TransactionSeeds.TransactionJohnFood.Type,
            IsRead = TransactionGroupUserSeeds.TransactionGroupUserFoodFamilyJohn.IsRead,
            Category = _BLL_mapper.Map<CategoryListDto>(_DAL_mapper.Map<CategoryDto>(CategorySeeds.CategoryFood)),
            CategoryId = TransactionSeeds.TransactionJohnFood.CategoryId
        };

        /// <summary>
        /// Gets the expected result for John's taxi ride transaction as a list DTO.
        /// </summary>
        public static readonly TransactionListDto TransactionJohnTaxiFriendsList = new()
        {
            Id = TransactionSeeds.TransactionJohnTaxi.Id,
            Amount = TransactionSeeds.TransactionJohnTaxi.Amount,
            Date = TransactionSeeds.TransactionJohnTaxi.Date,
            Description = TransactionSeeds.TransactionJohnTaxi.Description,
            Type = TransactionSeeds.TransactionJohnTaxi.Type,
            IsRead = TransactionGroupUserSeeds.TransactionGroupUserTaxiFriendsJohn.IsRead,
            Category = _BLL_mapper.Map<CategoryListDto>(_DAL_mapper.Map<CategoryDto>(CategorySeeds.CategoryTransport)),
            CategoryId = TransactionSeeds.TransactionJohnTaxi.CategoryId
        };

        /// <summary>
        /// Gets the expected result for John's public transport transaction as a list DTO.
        /// </summary>
        public static readonly TransactionListDto TransactionJohnTransportFriendsList = new()
        {
            Id = TransactionSeeds.TransactionJohnTransport.Id,
            Amount = TransactionSeeds.TransactionJohnTransport.Amount,
            Date = TransactionSeeds.TransactionJohnTransport.Date,
            Description = TransactionSeeds.TransactionJohnTransport.Description,
            Type = TransactionSeeds.TransactionJohnTransport.Type,
            IsRead = TransactionGroupUserSeeds.TransactionGroupUserTransportFriendsJohn.IsRead,
            Category = _BLL_mapper.Map<CategoryListDto>(_DAL_mapper.Map<CategoryDto>(CategorySeeds.CategoryTransport)),
            CategoryId = TransactionSeeds.TransactionJohnTransport.CategoryId
        };

        /// <summary>
        /// Gets the expected result for John's public transport transaction as a list DTO.
        /// </summary>
        public static readonly TransactionListDto TransactionJohnTransportWorkList = new()
        {
            Id = TransactionSeeds.TransactionJohnTransport.Id,
            Amount = TransactionSeeds.TransactionJohnTransport.Amount,
            Date = TransactionSeeds.TransactionJohnTransport.Date,
            Description = TransactionSeeds.TransactionJohnTransport.Description,
            Type = TransactionSeeds.TransactionJohnTransport.Type,
            IsRead = TransactionGroupUserSeeds.TransactionGroupUserTransportWorkJohn.IsRead,
            Category = _BLL_mapper.Map<CategoryListDto>(_DAL_mapper.Map<CategoryDto>(CategorySeeds.CategoryTransport)),
            CategoryId = TransactionSeeds.TransactionJohnTransport.CategoryId
        };

        /// <summary>
        /// Gets the expected result for Diana's dinner transaction as a summary DTO.
        /// </summary>
        public static readonly TransactionSummaryDto TransactionDianaDinnerSummary = new()
        {
            Id = TransactionSeeds.TransactionDianaDinner.Id,
            Amount = TransactionSeeds.TransactionDianaDinner.Amount,
            Date = TransactionSeeds.TransactionDianaDinner.Date,
            Description = TransactionSeeds.TransactionDianaDinner.Description,
            Type = TransactionSeeds.TransactionDianaDinner.Type,
            CategoryId = null
        };

        /// <summary>
        /// Gets the expected result for John's groceries transaction as a summary DTO.
        /// </summary>
        public static readonly TransactionSummaryDto TransactionJohnFoodSummary = new()
        {
            Id = TransactionSeeds.TransactionJohnFood.Id,
            Amount = TransactionSeeds.TransactionJohnFood.Amount,
            Date = TransactionSeeds.TransactionJohnFood.Date,
            Description = TransactionSeeds.TransactionJohnFood.Description,
            Type = TransactionSeeds.TransactionJohnFood.Type,
            CategoryId = TransactionSeeds.TransactionJohnFood.CategoryId
        };

        /// <summary>
        /// Gets the expected result for John's taxi ride transaction as a summary DTO.
        /// </summary>

        public static readonly TransactionSummaryDto TransactionJohnTaxiSummary = new()
        {
            Id = TransactionSeeds.TransactionJohnTaxi.Id,
            Amount = TransactionSeeds.TransactionJohnTaxi.Amount,
            Date = TransactionSeeds.TransactionJohnTaxi.Date,
            Description = TransactionSeeds.TransactionJohnTaxi.Description,
            Type = TransactionSeeds.TransactionJohnTaxi.Type,
            CategoryId = TransactionSeeds.TransactionJohnTaxi.CategoryId
        };

        /// <summary>
        /// Gets the expected result for John's public transport transaction as a summary DTO.
        /// </summary>

        public static readonly TransactionSummaryDto TransactionJohnTransportSummary = new()
        {
            Id = TransactionSeeds.TransactionJohnTransport.Id,
            Amount = TransactionSeeds.TransactionJohnTransport.Amount,
            Date = TransactionSeeds.TransactionJohnTransport.Date,
            Description = TransactionSeeds.TransactionJohnTransport.Description,
            Type = TransactionSeeds.TransactionJohnTransport.Type,
            CategoryId = TransactionSeeds.TransactionJohnTransport.CategoryId
        };

        /// <summary>
        /// Gets the expected result for Diana's dinner transaction as a detail DTO.
        /// </summary>
        public static readonly TransactionDetailDto TransactionDianaDinnerDetail = new()
        {
            Id = TransactionSeeds.TransactionDianaDinner.Id,
            Amount = TransactionSeeds.TransactionDianaDinner.Amount,
            Date = TransactionSeeds.TransactionDianaDinner.Date,
            Description = TransactionSeeds.TransactionDianaDinner.Description,
            Type = TransactionSeeds.TransactionDianaDinner.Type,
            Category = null,
            CategoryId = null,
            Groups = new List<GroupListDto>
            {
                _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFamily))
            },
            User = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserDianaGreen))
        };

        /// <summary>
        /// Gets the expected result for John's groceries transaction as a detail DTO.
        /// </summary>
        public static readonly TransactionDetailDto TransactionJohnFoodDetail = new()
        {
            Id = TransactionSeeds.TransactionJohnFood.Id,
            Amount = TransactionSeeds.TransactionJohnFood.Amount,
            Date = TransactionSeeds.TransactionJohnFood.Date,
            Description = TransactionSeeds.TransactionJohnFood.Description,
            Type = TransactionSeeds.TransactionJohnFood.Type,
            Category = ExpectedCategoryServiceResults.CategoryFoodSummary,
            CategoryId = TransactionSeeds.TransactionJohnFood.CategoryId,
            Groups = new List<GroupListDto>
            {
                _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFamily))
            },
            User = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
        };

        /// <summary>
        /// Gets the expected result for John's taxi ride transaction as a detail DTO.
        /// </summary>
        public static readonly TransactionDetailDto TransactionJohnTaxiDetail = new()
        {
            Id = TransactionSeeds.TransactionJohnTaxi.Id,
            Amount = TransactionSeeds.TransactionJohnTaxi.Amount,
            Date = TransactionSeeds.TransactionJohnTaxi.Date,
            Description = TransactionSeeds.TransactionJohnTaxi.Description,
            Type = TransactionSeeds.TransactionJohnTaxi.Type,
            Category = ExpectedCategoryServiceResults.CategoryTransportSummary,
            CategoryId = TransactionSeeds.TransactionJohnTaxi.CategoryId,
            Groups = new List<GroupListDto>
            {
                _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFriends))
            },
            User = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
        };

        /// <summary>
        /// Gets the expected result for John's public transport transaction as a detail DTO.
        /// </summary>
        public static readonly TransactionDetailDto TransactionJohnTransportDetail = new()
        {
            Id = TransactionSeeds.TransactionJohnTransport.Id,
            Amount = TransactionSeeds.TransactionJohnTransport.Amount,
            Date = TransactionSeeds.TransactionJohnTransport.Date,
            Description = TransactionSeeds.TransactionJohnTransport.Description,
            Type = TransactionSeeds.TransactionJohnTransport.Type,
            Category = ExpectedCategoryServiceResults.CategoryTransportSummary,
            CategoryId = TransactionSeeds.TransactionJohnTransport.CategoryId,
            Groups = new List<GroupListDto>
            {
                _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFriends)),
                _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupWork))
            },
            User = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe))
        };
    }
}
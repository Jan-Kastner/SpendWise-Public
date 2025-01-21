using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.BLL.Mappers;
using SpendWise.DAL.Mappers;
using SpendWise.Common.Tests.Seeds;

namespace SpendWise.Common.Tests.Helpers
{
    /// <summary>
    /// Provides expected results for invitation DTOs based on seed data for BLL services.
    /// </summary>
    public static class ExpectedInvitationServiceResults
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
        /// Gets the expected result for the invitation from Diana to Charlie into the family group as a detail DTO.
        /// </summary>
        public static readonly InvitationDetailDto InvitationDianaToCharlieIntoFamilyDetail = new()
        {
            Id = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SentDate,
            ResponseDate = InvitationSeeds.InvitationDianaToCharlieIntoFamily.ResponseDate,
            IsAccepted = InvitationSeeds.InvitationDianaToCharlieIntoFamily.IsAccepted,
            Sender = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserDianaGreen)),
            Receiver = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserCharlieBlack)),
            Group = _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFamily))
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the family group as a detail DTO.
        /// </summary>
        public static readonly InvitationDetailDto InvitationJohnToDianaIntoFamilyDetail = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoFamily.SentDate,
            ResponseDate = InvitationSeeds.InvitationJohnToDianaIntoFamily.ResponseDate,
            IsAccepted = InvitationSeeds.InvitationJohnToDianaIntoFamily.IsAccepted,
            Sender = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe)),
            Receiver = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserDianaGreen)),
            Group = _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupFamily))
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the work group as a detail DTO.
        /// </summary>
        public static readonly InvitationDetailDto InvitationJohnToDianaIntoWorkDetail = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoWork.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoWork.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoWork.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoWork.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoWork.SentDate,
            ResponseDate = InvitationSeeds.InvitationJohnToDianaIntoWork.ResponseDate,
            IsAccepted = InvitationSeeds.InvitationJohnToDianaIntoWork.IsAccepted,
            Sender = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserJohnDoe)),
            Receiver = _BLL_mapper.Map<UserSummaryDto>(_DAL_mapper.Map<UserDto>(UserSeeds.UserDianaGreen)),
            Group = _BLL_mapper.Map<GroupListDto>(_DAL_mapper.Map<GroupDto>(GroupSeeds.GroupWork))
        };

        /// <summary>
        /// Gets the expected result for the invitation from Diana to Charlie into the family group as a list DTO.
        /// </summary>
        public static readonly InvitationListDto InvitationDianaToCharlieIntoFamilyList = new()
        {
            Id = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SentDate
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the family group as a list DTO.
        /// </summary>
        public static readonly InvitationListDto InvitationJohnToDianaIntoFamilyList = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoFamily.SentDate
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the work group as a list DTO.
        /// </summary>
        public static readonly InvitationListDto InvitationJohnToDianaIntoWorkList = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoWork.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoWork.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoWork.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoWork.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoWork.SentDate
        };

        /// <summary>
        /// Gets the expected result for the invitation from Diana to Charlie into the family group as a summary DTO.
        /// </summary>
        public static readonly InvitationSummaryDto InvitationDianaToCharlieIntoFamilySummary = new()
        {
            Id = InvitationSeeds.InvitationDianaToCharlieIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationDianaToCharlieIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationDianaToCharlieIntoFamily.SentDate
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the family group as a summary DTO.
        /// </summary>
        public static readonly InvitationSummaryDto InvitationJohnToDianaIntoFamilySummary = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoFamily.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoFamily.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoFamily.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoFamily.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoFamily.SentDate
        };

        /// <summary>
        /// Gets the expected result for the invitation from John to Diana into the work group as a summary DTO.
        /// </summary>
        public static readonly InvitationSummaryDto InvitationJohnToDianaIntoWorkSummary = new()
        {
            Id = InvitationSeeds.InvitationJohnToDianaIntoWork.Id,
            SenderId = InvitationSeeds.InvitationJohnToDianaIntoWork.SenderId,
            ReceiverId = InvitationSeeds.InvitationJohnToDianaIntoWork.ReceiverId,
            GroupId = InvitationSeeds.InvitationJohnToDianaIntoWork.GroupId,
            SentDate = InvitationSeeds.InvitationJohnToDianaIntoWork.SentDate
        };
    }
}
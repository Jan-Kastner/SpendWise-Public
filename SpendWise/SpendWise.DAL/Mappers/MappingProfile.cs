using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between entities and DTOs in the SpendWise application.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// Configures the mappings between entities and their corresponding DTOs.
        /// </summary>
        public MappingProfile()
        {
            // Entity to DTO mappings
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<GroupEntity, GroupDto>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<GroupUserEntity, GroupUserDto>();
            CreateMap<TransactionGroupUserEntity, TransactionGroupUserDto>();
            CreateMap<TransactionEntity, TransactionDto>();
            CreateMap<InvitationEntity, InvitationDto>();

            CreateMap<LimitEntity, LimitDto>().ReverseMap();
            CreateMap<CategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Transactions, opt => opt.Ignore());
            CreateMap<GroupDto, GroupEntity>()
                .ForMember(dest => dest.GroupUsers, opt => opt.Ignore())
                .ForMember(dest => dest.Invitations, opt => opt.Ignore());
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.SentInvitations, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedInvitations, opt => opt.Ignore())
                .ForMember(dest => dest.GroupUsers, opt => opt.Ignore());
            CreateMap<GroupUserDto, GroupUserEntity>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.Limit, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionGroupUsers, opt => opt.Ignore());
            CreateMap<TransactionGroupUserDto, TransactionGroupUserEntity>()
                .ForMember(dest => dest.GroupUser, opt => opt.Ignore())
                .ForMember(dest => dest.Transaction, opt => opt.Ignore());
            CreateMap<TransactionDto, TransactionEntity>()
                .ForMember(dest => dest.TransactionGroupUsers, opt => opt.Ignore());
            CreateMap<InvitationDto, InvitationEntity>()
                .ForMember(dest => dest.Sender, opt => opt.Ignore())
                .ForMember(dest => dest.Receiver, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore());

            // Entity to Entity mappings
            CreateMap<CategoryEntity, CategoryEntity>();
            CreateMap<GroupEntity, GroupEntity>();
            CreateMap<GroupUserEntity, GroupUserEntity>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.GroupId, opt => opt.Ignore());
            CreateMap<InvitationEntity, InvitationEntity>()
                    .ForMember(dest => dest.ReceiverId, opt => opt.Ignore())
                    .ForMember(dest => dest.SenderId, opt => opt.Ignore())
                    .ForMember(dest => dest.GroupId, opt => opt.Ignore())
                    .ForMember(dest => dest.SentDate, opt => opt.Ignore());
            CreateMap<LimitEntity, LimitEntity>()
                    .ForMember(dest => dest.GroupUserId, opt => opt.Ignore());
            CreateMap<TransactionGroupUserEntity, TransactionGroupUserEntity>()
                    .ForMember(dest => dest.GroupUserId, opt => opt.Ignore())
                    .ForMember(dest => dest.TransactionId, opt => opt.Ignore());
            CreateMap<TransactionEntity, TransactionEntity>();
            CreateMap<UserEntity, UserEntity>();
        }
    }
}

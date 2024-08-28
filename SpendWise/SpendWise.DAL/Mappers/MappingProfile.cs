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
            CreateMap<GroupUserEntity, GroupUserDto>();
            CreateMap<InvitationEntity, InvitationDto>();
            CreateMap<LimitEntity, LimitDto>();
            CreateMap<TransactionGroupUserEntity, TransactionGroupUserDto>();
            CreateMap<TransactionEntity, TransactionDto>();
            CreateMap<UserEntity, UserDto>();

            // DTO to Entity mappings
            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<GroupDto, GroupEntity>();
            CreateMap<GroupUserDto, GroupUserEntity>();
            CreateMap<InvitationDto, InvitationEntity>();
            CreateMap<LimitDto, LimitEntity>();
            CreateMap<TransactionGroupUserDto, TransactionGroupUserEntity>();
            CreateMap<TransactionDto, TransactionEntity>();
            CreateMap<UserDto, UserEntity>();

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
            CreateMap<LimitEntity, LimitEntity>();
            CreateMap<TransactionGroupUserEntity, TransactionGroupUserEntity>();
            CreateMap<TransactionEntity, TransactionEntity>();
            CreateMap<UserEntity, UserEntity>();
        }
    }
}

using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Group.
    /// </summary>
    public class GroupMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Group.
        /// </summary>
        public GroupMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<GroupDto, GroupDetailDto>()
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt => opt.MapFrom(src => src.GroupUsers.Any() && src.GroupUsers.First() != null && src.GroupUsers.Select(gu => gu.User).First() != null ? src.GroupUsers : null)
                );
            CreateMap<GroupDto, GroupListDto>()
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt => opt.MapFrom(src => src.GroupUsers.Any() && src.GroupUsers.First() != null && src.GroupUsers.Select(gu => gu.User).First() != null ? src.GroupUsers : null)
                );
            CreateMap<GroupUserDto, GroupListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Group!.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Group!.Description)
                )
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt => opt.MapFrom(src => src.Group != null && src.Group.GroupUsers.Where(gu => gu.User != src.User) != null ? src.Group.GroupUsers.Where(gu => gu.User != src.User) : null)
                );
            CreateMap<TransactionGroupUserDto, GroupListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupUser!.Group!.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.GroupUser!.Group!.Name)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.GroupUser!.Group!.Description)
                )
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt => opt.MapFrom(src => src.GroupUser != null && src.GroupUser.Group != null ? src.GroupUser.Group.GroupUsers.Where(gu => gu.User != src.GroupUser.User) : null)
                );
            CreateMap<GroupDto, GroupSummaryDto>();
            CreateMap<GroupUserDto, GroupSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Group!.Name)
                );
            CreateMap<TransactionGroupUserDto, GroupSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupUser!.Group!.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.GroupUser!.Group!.Name)
                );

            // BLL DTO to DAL DTO mappings
            CreateMap<GroupCreateDto, GroupDto>();
            CreateMap<GroupUpdateDto, GroupDto>();
        }
    }
}
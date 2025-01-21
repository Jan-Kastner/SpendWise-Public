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

            // Mapping from GroupDto to GroupDetailDto
            CreateMap<GroupDto, GroupDetailDto>()
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt =>
                    {
                        // Precondition to ensure GroupUsers is not empty and all users are not null
                        opt.PreCondition(src => src.GroupUsers.Any() && src.GroupUsers.Select(gu => gu.User).All(user => user != null));
                        // Map GroupUsers to GroupParticipants
                        opt.MapFrom(src => src.GroupUsers);
                    }
                );

            // Mapping from GroupDto to GroupListDto
            CreateMap<GroupDto, GroupListDto>()
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt =>
                    {
                        // Precondition to ensure GroupUsers is not empty and all users are not null
                        opt.PreCondition(src => src.GroupUsers.Any() && src.GroupUsers.Select(gu => gu.User).All(user => user != null));
                        // Map GroupUsers to GroupParticipants
                        opt.MapFrom(src => src.GroupUsers);
                    }
                );

            // Mapping from GroupUserDto to GroupListDto
            CreateMap<GroupUserDto, GroupListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure Group is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.Group));
                            }
                            return true;
                        });
                        // Map Group.Name to Name
                        opt.MapFrom(src => src.Group!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Description,
                    opt =>
                    {
                        // Precondition to ensure Group is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.Group));
                            }
                            return true;
                        });
                        // Map Group.Description to Description
                        opt.MapFrom(src => src.Group!.Description);
                    }
                )
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt =>
                    {
                        // Precondition to ensure Group is not null and GroupUsers is not empty and all users are not null
                        opt.PreCondition(src =>
                        {
                            if (src.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.Group));
                            }
                            else if (!src.Group.GroupUsers.Any() || !src.Group.GroupUsers.Select(gu => gu.User).All(user => user != null))
                            {
                                return false;
                            }
                            return true;
                        });
                        // Map Group.GroupUsers to GroupParticipants
                        opt.MapFrom(src => src.Group!.GroupUsers);
                    }
                );

            // Mapping from TransactionGroupUserDto to GroupListDto
            CreateMap<TransactionGroupUserDto, GroupListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Group.Id to Id
                        opt.MapFrom(src => src.GroupUser!.Group!.Id);
                    }
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Group.Name to Name
                        opt.MapFrom(src => src.GroupUser!.Group!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Description,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Group.Description to Description
                        opt.MapFrom(src => src.GroupUser!.Group!.Description);
                    }
                )
                .ForMember(
                    dest => dest.GroupParticipants,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null and GroupUsers is not empty and all users are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            else if (!src.GroupUser.Group.GroupUsers.Any() || !src.GroupUser.Group.GroupUsers.Select(gu => gu.User).All(user => user != null))
                            {
                                return false;
                            }
                            return true;
                        });
                        // Map GroupUser.Group.GroupUsers to GroupParticipants
                        opt.MapFrom(src => src.GroupUser!.Group!.GroupUsers);
                    }
                );

            // Mapping from GroupDto to GroupSummaryDto
            CreateMap<GroupDto, GroupSummaryDto>();

            // Mapping from GroupUserDto to GroupSummaryDto
            CreateMap<GroupUserDto, GroupSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure Group is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.Group));
                            }
                            return true;
                        });
                        // Map Group.Name to Name
                        opt.MapFrom(src => src.Group!.Name);
                    }
                );

            // Mapping from TransactionGroupUserDto to GroupSummaryDto
            CreateMap<TransactionGroupUserDto, GroupSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Group.Id to Id
                        opt.MapFrom(src => src.GroupUser!.Group!.Id);
                    }
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and Group are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser.Group == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Group.Name to Name
                        opt.MapFrom(src => src.GroupUser!.Group!.Name);
                    }
                );

            // BLL DTO to DAL DTO mappings

            // Mapping from GroupCreateDto to GroupDto
            CreateMap<GroupCreateDto, GroupDto>();

            // Mapping from GroupUpdateDto to GroupDto
            CreateMap<GroupUpdateDto, GroupDto>();
        }
    }
}
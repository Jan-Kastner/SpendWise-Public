using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Enums;
using System.Text.RegularExpressions;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for User.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for User.
        /// </summary>
        public UserMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<UserDto, UserDetailDto>()
                .ForMember(
                    dest => dest.Groups,
                    opt => opt.MapFrom(src => src.GroupUsers.Any() && src.GroupUsers.Select(gu => gu.Group).First() != null ? src.GroupUsers : null)
                );
            CreateMap<UserDto, UserListDto>();
            CreateMap<GroupUserDto, UserListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.UserId)
                )
                .ForMember(
                    dest => dest.Role,
                    opt => opt.MapFrom(src => src.Role)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.User!.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.User!.Surname)
                )
                .ForMember(
                    dest => dest.Photo,
                    opt => opt.MapFrom(src => src.User!.Photo)
                )
                .ForMember(
                    dest => dest.Transactions,
                    opt => opt.MapFrom(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.Transaction).First() != null ? src.TransactionGroupUsers : null)
                );
            CreateMap<TransactionGroupUserDto, UserListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Id)
                )
                .ForMember(
                    dest => dest.Role,
                    opt => opt.MapFrom(src => src.GroupUser!.Role)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Surname)
                )
                .ForMember(
                    dest => dest.Photo,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Photo)
                )
                .ForMember(
                    dest => dest.Transactions,
                    opt => opt.MapFrom(src => src.GroupUser != null && src.GroupUser.TransactionGroupUsers.Any() && src.GroupUser.TransactionGroupUsers.Select(tgu => tgu.Transaction).First() != null ? src.GroupUser.TransactionGroupUsers : null)
                );
            CreateMap<UserDto, UserSummaryDto>();
            CreateMap<GroupUserDto, UserSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.UserId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.User!.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.User!.Surname)
                )
                .ForMember(
                    dest => dest.Photo,
                    opt => opt.MapFrom(src => src.User!.Photo)
                );
            CreateMap<TransactionGroupUserDto, UserSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Surname)
                )
                .ForMember(
                    dest => dest.Photo,
                    opt => opt.MapFrom(src => src.GroupUser!.User!.Photo)
                );
            // BLL DTO to DAL DTO mappings
            CreateMap<UserCreateDto, UserDto>();
            CreateMap<UserUpdateDto, UserDto>();
        }
    }
}
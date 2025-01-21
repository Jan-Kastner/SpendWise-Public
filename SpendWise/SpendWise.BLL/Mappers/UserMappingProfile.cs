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

            // Mapping from UserDto to UserDetailDto
            CreateMap<UserDto, UserDetailDto>()
                .ForMember(
                    dest => dest.Groups,
                    opt =>
                    {
                        // Precondition to ensure GroupUsers is not empty and all groups are not null
                        opt.PreCondition(src => src.GroupUsers.Any() && src.GroupUsers.Select(gu => gu.Group).All(group => group != null));
                        // Map GroupUsers to Groups
                        opt.MapFrom(src => src.GroupUsers);
                    });

            // Mapping from UserDto to UserListDto
            CreateMap<UserDto, UserListDto>()
                .ForMember(
                    dest => dest.Role,
                    opt => opt.Ignore() // Ignore Role property
                );

            // Mapping from GroupUserDto to UserListDto
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
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Name to Name
                        opt.MapFrom(src => src.User!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Surname,
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Surname to Surname
                        opt.MapFrom(src => src.User!.Surname);
                    }
                )
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Photo to Photo
                        opt.MapFrom(src => src.User!.Photo);
                    }
                )
                .ForMember(
                    dest => dest.Transactions,
                    opt =>
                    {
                        // Precondition to ensure TransactionGroupUsers is not empty and all transactions are not null
                        opt.PreCondition(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.Transaction).All(transaction => transaction != null));
                        // Map TransactionGroupUsers to Transactions
                        opt.MapFrom(src => src.TransactionGroupUsers);
                    });

            // Mapping from TransactionGroupUserDto to UserListDto
            CreateMap<TransactionGroupUserDto, UserListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Id to Id
                        opt.MapFrom(src => src.GroupUser!.User!.Id);
                    }
                )
                .ForMember(
                    dest => dest.Role,
                    opt =>
                    {
                        // Precondition to ensure GroupUser is not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.Role to Role
                        opt.MapFrom(src => src.GroupUser!.Role);
                    }
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Name to Name
                        opt.MapFrom(src => src.GroupUser!.User!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Surname,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Surname to Surname
                        opt.MapFrom(src => src.GroupUser!.User!.Surname);
                    }
                )
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Photo to Photo
                        opt.MapFrom(src => src.GroupUser!.User!.Photo);
                    }
                )
                .ForMember(
                    dest => dest.Transactions,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and TransactionGroupUsers are not empty and all transactions are not null
                        opt.PreCondition(src => src.GroupUser != null && src.GroupUser.TransactionGroupUsers.Any() && src.GroupUser.TransactionGroupUsers.Select(tgu => tgu.Transaction).All(transaction => transaction != null));
                        // Map GroupUser.TransactionGroupUsers to Transactions
                        opt.MapFrom(src => src.GroupUser!.TransactionGroupUsers);
                    });

            // Mapping from UserDto to UserSummaryDto
            CreateMap<UserDto, UserSummaryDto>();

            // Mapping from GroupUserDto to UserSummaryDto
            CreateMap<GroupUserDto, UserSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.UserId)
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Name to Name
                        opt.MapFrom(src => src.User!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Surname,
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Surname to Surname
                        opt.MapFrom(src => src.User!.Surname);
                    }
                )
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        // Precondition to ensure User is not null
                        opt.PreCondition(src =>
                        {
                            if (src.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.User));
                            }
                            return true;
                        });
                        // Map User.Photo to Photo
                        opt.MapFrom(src => src.User!.Photo);
                    }
                );

            // Mapping from TransactionGroupUserDto to UserSummaryDto
            CreateMap<TransactionGroupUserDto, UserSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Id to Id
                        opt.MapFrom(src => src.GroupUser!.User!.Id);
                    }
                )
                .ForMember(
                    dest => dest.Name,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Name to Name
                        opt.MapFrom(src => src.GroupUser!.User!.Name);
                    }
                )
                .ForMember(
                    dest => dest.Surname,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Surname to Surname
                        opt.MapFrom(src => src.GroupUser!.User!.Surname);
                    }
                )
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        // Precondition to ensure GroupUser and User are not null
                        opt.PreCondition(src =>
                        {
                            if (src.GroupUser == null || src.GroupUser!.User == null)
                            {
                                throw new ArgumentNullException(nameof(src.GroupUser));
                            }
                            return true;
                        });
                        // Map GroupUser.User.Photo to Photo
                        opt.MapFrom(src => src.GroupUser!.User!.Photo);
                    }
                );

            // BLL DTO to DAL DTO mappings

            // Mapping from UserCreateDto to UserDto
            CreateMap<UserCreateDto, UserDto>();

            // Mapping from UserUpdateDto to UserDto
            CreateMap<UserUpdateDto, UserDto>();
        }
    }
}
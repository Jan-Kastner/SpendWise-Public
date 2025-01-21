using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Transaction.
    /// </summary>
    public class TransactionMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Transaction.
        /// </summary>
        public TransactionMappingProfile()
        {
            // DAL DTO to BLL DTO mappings

            // Mapping from TransactionDto to TransactionDetailDto
            CreateMap<TransactionDto, TransactionDetailDto>()
                .ForMember(
                    dest => dest.Groups,
                    opt =>
                    {
                        // Precondition to ensure TransactionGroupUsers is not empty and all GroupUsers and Groups are not null
                        opt.PreCondition(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser).All(groupUser => groupUser != null) && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser!.Group).All(group => group != null));
                        // Map TransactionGroupUsers to Groups
                        opt.MapFrom(src => src.TransactionGroupUsers);
                    }
                )
                .ForMember(
                    dest => dest.User,
                    opt =>
                    {
                        // Precondition to ensure TransactionGroupUsers is not empty and all GroupUsers and Users are not null
                        opt.PreCondition(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser).All(groupUser => groupUser != null) && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser!.User).All(user => user != null));
                        // Map the first TransactionGroupUser to User
                        opt.MapFrom(src => src.TransactionGroupUsers.FirstOrDefault());
                    }
                );

            // Mapping from TransactionDto to TransactionListDto
            CreateMap<TransactionDto, TransactionListDto>()
                .ForMember(
                    dest => dest.IsRead,
                    opt => opt.Ignore() // Ignore IsRead property
                );

            // Mapping from TransactionGroupUserDto to TransactionListDto
            CreateMap<TransactionGroupUserDto, TransactionListDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TransactionId)
                )
                .ForMember(
                    dest => dest.IsRead,
                    opt => opt.MapFrom(src => src.IsRead)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Amount to Amount
                        opt.MapFrom(src => src.Transaction!.Amount);
                    }
                )
                .ForMember(
                    dest => dest.Date,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Date to Date
                        opt.MapFrom(src => src.Transaction!.Date);
                    }
                )
                .ForMember(
                    dest => dest.Description,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Description to Description
                        opt.MapFrom(src => src.Transaction!.Description);
                    }
                )
                .ForMember(
                    dest => dest.Type,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Type to Type
                        opt.MapFrom(src => src.Transaction!.Type);
                    }
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.CategoryId to CategoryId
                        opt.MapFrom(src => src.Transaction!.CategoryId);
                    }
                )
                .ForMember(
                    dest => dest.Category,
                    opt =>
                    {
                        // Precondition to ensure Transaction and Category are not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            if (src.Transaction!.Category == null)
                            {
                                return false;
                            }
                            return true;
                        });
                        // Map Transaction.Category to Category
                        opt.MapFrom(src => src.Transaction!.Category);
                    }
                );

            // Mapping from TransactionDto to TransactionSummaryDto
            CreateMap<TransactionDto, TransactionSummaryDto>();

            // Mapping from TransactionGroupUserDto to TransactionSummaryDto
            CreateMap<TransactionGroupUserDto, TransactionSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TransactionId)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Amount to Amount
                        opt.MapFrom(src => src.Transaction!.Amount);
                    }
                )
                .ForMember(
                    dest => dest.Date,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Date to Date
                        opt.MapFrom(src => src.Transaction!.Date);
                    }
                )
                .ForMember(
                    dest => dest.Description,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Description to Description
                        opt.MapFrom(src => src.Transaction!.Description);
                    }
                )
                .ForMember(
                    dest => dest.Type,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.Type to Type
                        opt.MapFrom(src => src.Transaction!.Type);
                    }
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt =>
                    {
                        // Precondition to ensure Transaction is not null
                        opt.PreCondition(src =>
                        {
                            if (src.Transaction == null)
                            {
                                throw new ArgumentNullException(nameof(src.Transaction));
                            }
                            return true;
                        });
                        // Map Transaction.CategoryId to CategoryId
                        opt.MapFrom(src => src.Transaction!.CategoryId);
                    }
                );

            // BLL DTO to DAL DTO mappings

            // Mapping from TransactionCreateDto to TransactionDto
            CreateMap<TransactionCreateDto, TransactionDto>();

            // Mapping from TransactionUpdateDto to TransactionDto
            CreateMap<TransactionUpdateDto, TransactionDto>();
        }
    }
}
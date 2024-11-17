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
            CreateMap<TransactionDto, TransactionDetailDto>()
                .ForMember(
                    dest => dest.Groups,
                    opt => opt.MapFrom(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser).First() != null && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser!.Group).First() != null ? src.TransactionGroupUsers : null)
                )
                .ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(src => src.TransactionGroupUsers.Any() && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser).First() != null && src.TransactionGroupUsers.Select(tgu => tgu.GroupUser!.User).First() != null ? src.TransactionGroupUsers.FirstOrDefault() : null)
                );
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
                    opt => opt.MapFrom(src => src.Transaction!.Amount)
                )
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Transaction!.Date)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Transaction!.Description)
                )
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.Transaction!.Type)
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.Transaction!.CategoryId)
                )
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Transaction != null && src.Transaction.Category != null ? src.Transaction.Category : null)
                );
            CreateMap<TransactionDto, TransactionSummaryDto>();
            CreateMap<TransactionGroupUserDto, TransactionSummaryDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TransactionId)
                )
                .ForMember(
                    dest => dest.Amount,
                    opt => opt.MapFrom(src => src.Transaction!.Amount)
                )
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Transaction!.Date)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Transaction!.Description)
                )
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.Transaction!.Type)
                )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.Transaction!.CategoryId)
                );

            // BLL DTO to DAL DTO mappings
            CreateMap<TransactionCreateDto, TransactionDto>();
            CreateMap<TransactionUpdateDto, TransactionDto>();
        }
    }
}
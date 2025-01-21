using AutoMapper;
using SpendWise.BLL.Queries;

namespace SpendWise.BLL.Mappers
{
    public class TransactionToTransactionGroupUserCriteriaMappingProfile : Profile
    {
        public TransactionToTransactionGroupUserCriteriaMappingProfile()
        {
            CreateMap<GetTransactionsByCriteriaQuery, GetTransactionGroupUsersByCriteriaQuery>()
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.NotTransactionDate, opt => opt.MapFrom(src => src.NotDate))
                .ForMember(dest => dest.TransactionDateFrom, opt => opt.MapFrom(src => src.DateFrom))
                .ForMember(dest => dest.TransactionDateTo, opt => opt.MapFrom(src => src.DateTo))
                .ForMember(dest => dest.TransactionAmount, opt => opt.MapFrom(src => src.AmountEqual))
                .ForMember(dest => dest.NotTransactionAmount, opt => opt.MapFrom(src => src.NotAmountEqual))
                .ForMember(dest => dest.TransactionAmountGreaterThan, opt => opt.MapFrom(src => src.AmountGreaterThan))
                .ForMember(dest => dest.NotTransactionAmountGreaterThan, opt => opt.MapFrom(src => src.NotAmountGreaterThan))
                .ForMember(dest => dest.TransactionAmountLessThan, opt => opt.MapFrom(src => src.AmountLessThan))
                .ForMember(dest => dest.NotTransactionAmountLessThan, opt => opt.MapFrom(src => src.NotAmountLessThan))
                .ForMember(dest => dest.TransactionDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NotTransactionDescription, opt => opt.MapFrom(src => src.NotDescription))
                .ForMember(dest => dest.TransactionDescriptionPartialMatch, opt => opt.MapFrom(src => src.DescriptionPartialMatch))
                .ForMember(dest => dest.NotTransactionDescriptionPartialMatch, opt => opt.MapFrom(src => src.NotDescriptionPartialMatch))
                .ForMember(dest => dest.WithTransactionDescription, opt => opt.MapFrom(src => src.WithDescription))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.NotTransactionType, opt => opt.MapFrom(src => src.NotType))
                .ForMember(dest => dest.TransactionCategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.NotTransactionCategoryId, opt => opt.MapFrom(src => src.NotCategoryId))
                .ForMember(dest => dest.WithTransactionCategory, opt => opt.MapFrom(src => src.WithCategory))
                .ForMember(dest => dest.IncludeCategory, opt => opt.MapFrom(src => src.IncludeCategory))
                .ForMember(dest => dest.IncludeTransactions, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.And, opt => opt.MapFrom(src => src.And))
                .ForMember(dest => dest.Or, opt => opt.MapFrom(src => src.Or))
                .ForMember(dest => dest.Not, opt => opt.MapFrom(src => src.Not));
        }
    }
}
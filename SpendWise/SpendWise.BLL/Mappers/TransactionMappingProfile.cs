using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

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
            CreateMap<TransactionDto, TransactionDetailDto>();
            CreateMap<TransactionDto, TransactionListDto>();
            CreateMap<TransactionDto, TransactionSummaryDto>();
        }
    }
}
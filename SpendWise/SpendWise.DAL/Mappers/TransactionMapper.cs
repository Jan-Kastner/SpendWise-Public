using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="TransactionEntity"/> and <see cref="TransactionDto"/>.
    /// </summary>
    public class TransactionMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionMapper"/> class.
        /// </summary>
        public TransactionMapper()
        {
            // Create mapping configuration from TransactionEntity to TransactionDto
            CreateMap<TransactionEntity, TransactionDto>();

            // Create mapping configuration from TransactionDto to TransactionEntity
            CreateMap<TransactionDto, TransactionEntity>();
        }
    }
}

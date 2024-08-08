using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="TransactionGroupUserEntity"/> and <see cref="TransactionGroupUserDto"/>.
    /// </summary>
    public class TransactionGroupUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionGroupUserMapper"/> class.
        /// </summary>
        public TransactionGroupUserMapper()
        {
            // Create mapping configuration from TransactionGroupUserEntity to TransactionGroupUserDto
            CreateMap<TransactionGroupUserEntity, TransactionGroupUserDto>();

            // Create mapping configuration from TransactionGroupUserDto to TransactionGroupUserEntity
            CreateMap<TransactionGroupUserDto, TransactionGroupUserEntity>();
        }
    }
}

using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="LimitEntity"/> and <see cref="LimitDto"/>.
    /// </summary>
    public class LimitMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitMapper"/> class.
        /// </summary>
        public LimitMapper()
        {
            // Create mapping configuration from LimitEntity to LimitDto
            CreateMap<LimitEntity, LimitDto>();

            // Create mapping configuration from LimitDto to LimitEntity
            CreateMap<LimitDto, LimitEntity>();
        }
    }
}

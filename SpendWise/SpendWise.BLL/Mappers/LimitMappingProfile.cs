using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Limit.
    /// </summary>
    public class LimitMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Limit.
        /// </summary>
        public LimitMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<LimitDto, LimitDetailDto>();
            CreateMap<LimitDto, LimitListDto>();
            CreateMap<LimitDto, LimitSummaryDto>();

            // BLL DTO to DAL DTO mappings
            CreateMap<LimitCreateDto, LimitDto>();
            CreateMap<LimitUpdateDto, LimitDto>();
        }
    }
}
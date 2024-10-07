using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Group.
    /// </summary>
    public class GroupMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Group.
        /// </summary>
        public GroupMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<GroupDto, GroupDetailDto>();
            CreateMap<GroupDto, GroupListDto>();
            CreateMap<GroupDto, GroupSummaryDto>();

            // BLL DTO to DAL DTO mappings
            CreateMap<GroupCreateDto, GroupDto>();
            CreateMap<GroupUpdateDto, GroupDto>();
        }
    }
}
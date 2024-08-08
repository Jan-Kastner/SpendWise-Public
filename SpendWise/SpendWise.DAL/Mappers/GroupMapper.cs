using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="GroupEntity"/> and <see cref="GroupDto"/>.
    /// </summary>
    public class GroupMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMapper"/> class.
        /// </summary>
        public GroupMapper()
        {
            // Create mapping configuration from GroupEntity to GroupDto
            CreateMap<GroupEntity, GroupDto>();

            // Create mapping configuration from GroupDto to GroupEntity
            CreateMap<GroupDto, GroupEntity>();
        }
    }
}

using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="GroupUserEntity"/> and <see cref="GroupUserDto"/>.
    /// </summary>
    public class GroupUserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUserMapper"/> class.
        /// </summary>
        public GroupUserMapper()
        {
            // Create mapping configuration from GroupUserEntity to GroupUserDto
            CreateMap<GroupUserEntity, GroupUserDto>();

            // Create mapping configuration from GroupUserDto to GroupUserEntity
            CreateMap<GroupUserDto, GroupUserEntity>();
        }
    }
}

using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Group User.
    /// </summary>
    public class GroupUserMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUserMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Group User.
        /// </summary>
        public GroupUserMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<GroupUserDto, GroupUserDetailDto>();
            CreateMap<GroupUserDto, GroupUserListDto>();
        }
    }
}
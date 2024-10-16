using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for User.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for User.
        /// </summary>
        public UserMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<UserDto, UserDetailDto>();
            CreateMap<UserDto, UserListDto>();
        }
    }
}
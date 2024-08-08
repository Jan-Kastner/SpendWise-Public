using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="UserEntity"/> and <see cref="UserDto"/>.
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMapper"/> class.
        /// </summary>
        public UserMapper()
        {
            // Create mapping configuration from UserEntity to UserDto
            CreateMap<UserEntity, UserDto>();

            // Create mapping configuration from UserDto to UserEntity
            CreateMap<UserDto, UserEntity>();
        }
    }
}

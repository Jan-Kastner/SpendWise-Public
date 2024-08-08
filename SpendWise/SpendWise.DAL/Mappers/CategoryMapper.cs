using AutoMapper;
using SpendWise.DAL.Entities;
using SpendWise.DAL.DTOs;

namespace SpendWise.DAL.Mappings
{
    /// <summary>
    /// AutoMapper profile configuration for mapping between <see cref="CategoryEntity"/> and <see cref="CategoryDto"/>.
    /// </summary>
    public class CategoryMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapper"/> class.
        /// </summary>
        public CategoryMapper()
        {
            // Create mapping configuration from CategoryEntity to CategoryDto
            CreateMap<CategoryEntity, CategoryDto>();

            // Create mapping configuration from CategoryDto to CategoryEntity
            CreateMap<CategoryDto, CategoryEntity>();
        }
    }
}

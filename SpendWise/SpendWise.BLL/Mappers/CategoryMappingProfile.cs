using AutoMapper;
using SpendWise.BLL.DTOs.Category;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Mappers
{
    /// <summary>
    /// Represents the AutoMapper profile for mapping between DAL DTOs and BLL DTOs for Category.
    /// </summary>
    public class CategoryMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMappingProfile"/> class.
        /// Configures the mappings between DAL DTOs and BLL DTOs for Category.
        /// </summary>
        public CategoryMappingProfile()
        {
            // DAL DTO to BLL DTO mappings
            CreateMap<CategoryDto, CategoryDetailDto>();
            CreateMap<CategoryDto, CategoryListDto>();
            CreateMap<CategoryDto, CategorySummaryDto>();

            // BLL DTO to DAL DTO mappings
            CreateMap<CategoryCreateDto, CategoryDto>();
            CreateMap<CategoryUpdateDto, CategoryDto>();
        }
    }
}
using SpendWise.BLL.DTOs.Category;

namespace SpendWise.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDetailDto> AddCategoryAsync(CategoryCreateDto category);
        Task<CategoryDetailDto> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryListDto>> GetAllCategoriesAsync();
        Task<IEnumerable<CategoryListDto>> GetCategoriesByNameAsync(string name);
        Task<IEnumerable<CategoryListDto>> GetCategoriesByDescriptionAsync(string description);
        Task<IEnumerable<CategoryListDto>> GetCategoriesByColorAsync(string color);
        Task<IEnumerable<CategoryListDto>> GetCategoriesWithIconAsync();
        Task<IEnumerable<CategoryListDto>> GetCategoriesWithoutIconAsync();
        Task UpdateCategoryAsync(CategoryUpdateDto category);
        Task DeleteCategoryAsync(Guid id);
    }
}
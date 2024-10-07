using SpendWise.BLL.Queries;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Defines a service for managing categories, including creating, updating, deleting, and retrieving categories.
    /// </summary>
    public interface ICategoryService : IService<CategoryCreateDto, CategoryUpdateDto>
    {
        /// <summary>
        /// Retrieves all categories based on the specified query.
        /// </summary>
        /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the categories. Must implement <see cref="IQueryableDto"/>.</typeparam>
        /// <param name="queryObject">The query object used to filter categories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of <typeparamref name="TDto"/>.</returns>
        Task<IEnumerable<TDto>> GetCategoriesAsync<TDto>(GetAllItemsQuery queryObject) where TDto : class, IQueryableDto;

        /// <summary>
        /// Retrieves a category by its identifier.
        /// </summary>
        /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the category. Must implement <see cref="IQueryableDto"/>.</typeparam>
        /// <param name="categoryId">The unique identifier of the category to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <typeparamref name="TDto"/>.</returns>
        Task<TDto> GetCategoryByIdAsync<TDto>(Guid categoryId) where TDto : class, IQueryableDto;
    }
}
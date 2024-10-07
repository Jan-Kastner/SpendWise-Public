using SpendWise.BLL.Services;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries;
using SpendWise.BLL.Handlers.Categories;

namespace SpendWise.BLL.Handlers.Categories
{
    /// <summary>
    /// Handles the retrieval of a category by its identifier.
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the category. Must implement <see cref="IQueryableDto"/>.</typeparam>
    public class GetCategoryByIdHandler<TDto> : IGetCategoryByIdHandler<TDto>
        where TDto : class, IQueryableDto
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdHandler{TDto}"/> class.
        /// </summary>
        /// <param name="categoryService">The service used to retrieve the category.</param>
        public GetCategoryByIdHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Handles the specified query to retrieve a category by its identifier.
        /// </summary>
        /// <param name="query">The query to retrieve the category by its identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <typeparamref name="TDto"/>.</returns>
        public async Task<TDto> Handle(GetItemByIdQuery query)
        {
            return await _categoryService.GetCategoryByIdAsync<TDto>(query.Id);
        }
    }
}
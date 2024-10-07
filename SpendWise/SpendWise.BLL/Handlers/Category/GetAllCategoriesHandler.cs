using System.Collections.Generic;
using System.Threading.Tasks;
using SpendWise.BLL.Queries;
using SpendWise.BLL.Services;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers.Categories
{
    /// <summary>
    /// Handles the retrieval of all categories.
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the categories. Must implement <see cref="IQueryableDto"/>.</typeparam>
    public class GetAllCategoriesHandler<TDto> : IGetAllCategoriesHandler<TDto>
        where TDto : class, IQueryableDto
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCategoriesHandler{TDto}"/> class.
        /// </summary>
        /// <param name="categoryService">The service used to retrieve categories.</param>
        public GetAllCategoriesHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Handles the specified query to retrieve all categories.
        /// </summary>
        /// <param name="query">The query to retrieve all categories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of <typeparamref name="TDto"/>.</returns>
        public async Task<IEnumerable<TDto>> Handle(GetAllItemsQuery query)
        {
            return await _categoryService.GetCategoriesAsync<TDto>(query);
        }
    }
}
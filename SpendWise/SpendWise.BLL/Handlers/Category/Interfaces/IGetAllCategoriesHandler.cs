using System.Collections.Generic;
using System.Threading.Tasks;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries;

namespace SpendWise.BLL.Handlers.Categories
{
    /// <summary>
    /// Defines a handler for retrieving all categories.
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the categories. Must implement <see cref="IQueryableDto"/>.</typeparam>
    public interface IGetAllCategoriesHandler<TDto>
        where TDto : class, IQueryableDto
    {
        /// <summary>
        /// Handles the specified query to retrieve all categories.
        /// </summary>
        /// <param name="query">The query to retrieve all categories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of <typeparamref name="TDto"/>.</returns>
        Task<IEnumerable<TDto>> Handle(GetAllItemsQuery query);
    }
}
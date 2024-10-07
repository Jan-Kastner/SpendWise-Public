using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries;

namespace SpendWise.BLL.Handlers.Categories
{
    /// <summary>
    /// Defines a handler for retrieving a category by its identifier.
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the category. Must implement <see cref="IQueryableDto"/>.</typeparam>
    public interface IGetCategoryByIdHandler<TDto>
        where TDto : class, IQueryableDto
    {
        /// <summary>
        /// Handles the specified query to retrieve a category by its identifier.
        /// </summary>
        /// <param name="query">The query to retrieve the category by its identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <typeparamref name="TDto"/>.</returns>
        Task<TDto> Handle(GetItemByIdQuery query);
    }
}
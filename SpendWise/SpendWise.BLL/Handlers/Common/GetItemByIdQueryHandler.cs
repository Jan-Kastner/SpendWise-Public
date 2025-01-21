using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Handles the retrieval of an entity by its identifier.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object. Must implement <see cref="ICriteriaQuery"/>.</typeparam>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the entity. Must implement <see cref="IQueryableDto"/> and be a reference type.</typeparam>
    public abstract class GetItemByIdQueryHandler<TCreateDto, TUpdateDto, TCriteriaQuery, TDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
        where TDto : class, IQueryableDto
    {
        protected readonly IService<TCreateDto, TUpdateDto, TCriteriaQuery> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemByIdQueryHandler{TCreateDto, TUpdateDto, TCriteriaQuery, TDto}"/> class.
        /// </summary>
        /// <param name="service">The service used to retrieve the entity.</param>
        protected GetItemByIdQueryHandler(IService<TCreateDto, TUpdateDto, TCriteriaQuery> service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified query to retrieve an entity by its identifier.
        /// </summary>
        /// <param name="query">The query to retrieve the entity by its identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <typeparamref name="TDto"/>.</returns>
        public async Task<TDto> Handle(IIdQuery query)
        {
            return await _service.GetByIdAsync<TDto>(query);
        }
    }
}
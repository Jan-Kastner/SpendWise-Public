using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Handles the retrieval of entities based on specified criteria.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object. Must implement <see cref="ICriteriaQuery"/>.</typeparam>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the entity. Must implement <see cref="IQueryableDto"/> and be a reference type.</typeparam>
    public abstract class GetItemsByCriteriaQueryHandler<TCreateDto, TUpdateDto, TCriteriaQuery, TDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
        where TDto : class, IQueryableDto
    {
        protected readonly IService<TCreateDto, TUpdateDto, TCriteriaQuery> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemsByCriteriaQueryHandler{TCreateDto, TUpdateDto, TCriteriaQuery, TDto}"/> class.
        /// </summary>
        /// <param name="service">The service used to retrieve entities based on criteria.</param>
        protected GetItemsByCriteriaQueryHandler(IService<TCreateDto, TUpdateDto, TCriteriaQuery> service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified query to retrieve entities based on criteria.
        /// </summary>
        /// <param name="queryObject">The criteria query object.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <typeparamref name="TDto"/>.</returns>
        public async Task<IEnumerable<TDto>> Handle(TCriteriaQuery queryObject)
        {
            return await _service.GetAsync<TDto>(queryObject);
        }
    }
}
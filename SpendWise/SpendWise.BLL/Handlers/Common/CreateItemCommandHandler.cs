using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Abstract class that handles the creation of entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object. Must implement <see cref="ICriteriaQuery"/>.</typeparam>
    public abstract class CreateItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : IUpdatableDto
        where TCriteriaQuery : ICriteriaQuery
    {
        protected readonly IService<TCreateDto, TUpdateDto, TCriteriaQuery> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateItemCommandHandler{TCreateDto, TUpdateDto, TCriteriaQuery}"/> class.
        /// </summary>
        /// <param name="service">The service used to create entities.</param>
        protected CreateItemCommandHandler(IService<TCreateDto, TUpdateDto, TCriteriaQuery> service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified create command.
        /// </summary>
        /// <param name="command">The create command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Handle(CreateCommand<TCreateDto> command)
        {
            await _service.CreateAsync(command.Dto);
        }
    }
}
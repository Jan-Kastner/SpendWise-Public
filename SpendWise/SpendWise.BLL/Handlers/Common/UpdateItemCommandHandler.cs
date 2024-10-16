using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Abstract class that handles the updating of entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object. Must implement <see cref="ICriteriaQuery"/>.</typeparam>
    public abstract class UpdateItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : ICriteriaQuery
    {
        protected readonly IService<TCreateDto, TUpdateDto, TCriteriaQuery> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemCommandHandler{TCreateDto, TUpdateDto, TCriteriaQuery}"/> class.
        /// </summary>
        /// <param name="service">The service used to update entities.</param>
        protected UpdateItemCommandHandler(IService<TCreateDto, TUpdateDto, TCriteriaQuery> service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified update command.
        /// </summary>
        /// <param name="command">The update command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Handle(UpdateCommand<TUpdateDto> command)
        {
            await _service.UpdateAsync(command.Dto);
        }
    }
}
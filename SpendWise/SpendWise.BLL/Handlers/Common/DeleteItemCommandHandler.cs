using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Handles the deletion of entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/> and be a reference type.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object. Must implement <see cref="ICriteriaQuery"/>.</typeparam>
    public abstract class DeleteItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
    {
        protected readonly IService<TCreateDto, TUpdateDto, TCriteriaQuery> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteItemCommandHandler{TCreateDto, TUpdateDto, TCriteriaQuery}"/> class.
        /// </summary>
        /// <param name="service">The service used to delete entities.</param>
        protected DeleteItemCommandHandler(IService<TCreateDto, TUpdateDto, TCriteriaQuery> service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles the specified delete command.
        /// </summary>
        /// <param name="command">The delete command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Handle(DeleteCommand command)
        {
            await _service.DeleteAsync(command.Id);
        }
    }
}
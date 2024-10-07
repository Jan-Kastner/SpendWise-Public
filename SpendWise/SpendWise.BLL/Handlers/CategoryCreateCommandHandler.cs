using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Categories;
using SpendWise.BLL.Services;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Handles the creation of entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public class CreateCommandHandler<TCreateDto, TUpdateDto> : ICreateCommandHandler<TCreateDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : IUpdatableDto
    {
        private readonly IService<TCreateDto, TUpdateDto> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommandHandler{TCreateDto, TUpdateDto}"/> class.
        /// </summary>
        /// <param name="service">The service used to create entities.</param>
        public CreateCommandHandler(IService<TCreateDto, TUpdateDto> service)
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
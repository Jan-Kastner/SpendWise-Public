using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Services;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Handles the updating of entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public class UpdateCommandHandler<TCreateDto, TUpdateDto> : IUpdateCommandHandler<TUpdateDto>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
    {
        private readonly IService<TCreateDto, TUpdateDto> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommandHandler{TCreateDto, TUpdateDto}"/> class.
        /// </summary>
        /// <param name="service">The service used to update entities.</param>
        public UpdateCommandHandler(IService<TCreateDto, TUpdateDto> service)
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
using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Defines a handler for processing create commands.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    public interface ICreateCommandHandler<TCreateDto>
        where TCreateDto : class, ICreatableDto
    {
        /// <summary>
        /// Handles the specified create command.
        /// </summary>
        /// <param name="command">The create command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Handle(CreateCommand<TCreateDto> command);
    }
}
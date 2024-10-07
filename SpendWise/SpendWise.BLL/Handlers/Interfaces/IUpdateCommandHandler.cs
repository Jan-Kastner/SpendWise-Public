using System.Threading.Tasks;
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Handlers
{
    /// <summary>
    /// Defines a handler for processing update commands.
    /// </summary>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public interface IUpdateCommandHandler<TUpdateDto>
        where TUpdateDto : class, IUpdatableDto
    {
        /// <summary>
        /// Handles the specified update command.
        /// </summary>
        /// <param name="command">The update command to handle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Handle(UpdateCommand<TUpdateDto> command);
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.Commands
{
    /// <summary>
    /// Represents a command to update an entity using a Data Transfer Object (DTO).
    /// </summary>
    /// <typeparam name="TUpdateDto">The type of the DTO used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public class UpdateCommand<TUpdateDto>
        where TUpdateDto : class, IUpdatableDto
    {
        /// <summary>
        /// Gets the DTO used for updating.
        /// </summary>
        public TUpdateDto Dto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommand{TUpdateDto}"/> class.
        /// </summary>
        /// <param name="dto">The DTO used for updating.</param>
        public UpdateCommand(TUpdateDto dto)
        {
            Dto = dto;
        }
    }
}
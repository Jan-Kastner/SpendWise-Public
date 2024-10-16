using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.Commands
{
    /// <summary>
    /// Represents a command to create an entity using a Data Transfer Object (DTO).
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the DTO used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    public class CreateCommand<TCreateDto>
        where TCreateDto : class, ICreatableDto
    {
        /// <summary>
        /// Gets the DTO used for creation.
        /// </summary>
        public TCreateDto Dto { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommand{TCreateDto}"/> class.
        /// </summary>
        /// <param name="dto">The DTO used for creation.</param>
        public CreateCommand(TCreateDto dto)
        {
            Dto = dto;
        }
    }
}
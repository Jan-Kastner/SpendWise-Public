using System.ComponentModel.DataAnnotations;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary data transfer object (DTO) for a user.
    /// </summary>
    public record UserSummaryDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public required Guid Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Name { get; init; }

        /// <summary>
        /// Gets or sets the surname of the user. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        public required string Surname { get; init; }

        /// <summary>
        /// Gets or sets the photo of the user. Can be null.
        /// </summary>
        public required byte[] Photo { get; init; }
    }
}
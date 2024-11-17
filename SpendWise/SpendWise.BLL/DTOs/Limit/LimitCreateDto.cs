using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for creating a limit.
    /// </summary>
    public record LimitCreateDto : ICreatableDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; init; }

        /// <summary>
        /// Gets or sets the amount of the limit.
        /// </summary>
        public required decimal Amount { get; init; }

        /// <summary>
        /// Gets or sets the type of notice associated with the limit.
        /// </summary>
        public required NoticeType NoticeType { get; init; } = NoticeType.InApp;
    }
}
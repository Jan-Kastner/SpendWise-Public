using SpendWise.Common.Enums;
using SpendWise.DAL.Entities.Interfaces;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a limit entity within the SpendWise application.
    /// </summary>
    public record LimitEntity : ILimitEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the limit.
        /// </summary>
        public required Guid Id { get; init; }

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

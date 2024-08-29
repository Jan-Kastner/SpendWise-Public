using SpendWise.Common.Enums;

namespace SpendWise.DAL.DTOs
{
    public record LimitDto : IDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the limit.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        public required Guid GroupUserId { get; set; }

        /// <summary>
        /// Gets or sets the amount of the limit.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type of notice associated with the limit.
        /// </summary>
        public required NoticeType NoticeType { get; set; } = NoticeType.InApp;
    }
}

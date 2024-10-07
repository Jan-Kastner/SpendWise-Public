using SpendWise.Common.Enums;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents a summary of a limit for listing purposes.
    /// </summary>
    public record LimitListDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the limit.
        /// </summary>
        public required Guid Id { get; set; }

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
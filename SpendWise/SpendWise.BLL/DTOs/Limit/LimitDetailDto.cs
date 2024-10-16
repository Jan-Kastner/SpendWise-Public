using SpendWise.Common.Enums;
using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a limit.
    /// </summary>
    public record LimitDetailDto : IQueryableDto
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
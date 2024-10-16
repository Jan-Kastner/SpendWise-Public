using SpendWise.BLL.DTOs.Interfaces;

namespace SpendWise.BLL.DTOs
{
    /// <summary>
    /// Represents detailed information about a category.
    /// </summary>
    public record CategoryDetailDto : IQueryableDto, ITransactionsDto<TransactionSummaryDto>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the color associated with the category.
        /// </summary>
        public required string Color { get; set; }

        /// <summary>
        /// Gets or sets the icon representing the category.
        /// </summary>
        public required byte[] Icon { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions associated with the category.
        /// </summary>
        public IEnumerable<TransactionSummaryDto> Transactions { get; set; } = new List<TransactionSummaryDto>();
    }
}
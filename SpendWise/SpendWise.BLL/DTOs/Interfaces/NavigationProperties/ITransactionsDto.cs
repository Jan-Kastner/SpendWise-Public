namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of transactions.
    /// </summary>
    /// <typeparam name="TTransactionDto">The type of the transaction DTO.</typeparam>
    public interface ITransactionsDto<TTransactionDto> where TTransactionDto : IQueryableDto
    {
        /// <summary>
        /// Gets the list of transactions associated with the category.
        /// </summary>
        IEnumerable<TTransactionDto> Transactions { get; set; }
    }
}

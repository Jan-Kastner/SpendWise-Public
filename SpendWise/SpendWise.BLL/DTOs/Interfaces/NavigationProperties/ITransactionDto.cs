namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a transaction.
    /// </summary>
    /// <typeparam name="TTransactionDto">The type of the transaction DTO.</typeparam>
    public interface ITransactionDto<TTransactionDto> where TTransactionDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the transaction associated with the entity.
        /// </summary>
        TTransactionDto Transaction { get; set; }
    }
}
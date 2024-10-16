namespace SpendWise.BLL.DTOs.Interfaces
{
    /// <summary>
    /// Represents a generic interface for DTOs that include a list of transaction group users.
    /// </summary>
    /// <typeparam name="TTransactionGroupUserDto">The type of the transaction group user DTO.</typeparam>
    public interface ITransactionGroupUsersDto<TTransactionGroupUserDto> where TTransactionGroupUserDto : IQueryableDto
    {
        /// <summary>
        /// Gets or sets the list of transaction group users associated with the entity.
        /// </summary>
        IEnumerable<TTransactionGroupUserDto> TransactionGroupUsers { get; set; }
    }
}
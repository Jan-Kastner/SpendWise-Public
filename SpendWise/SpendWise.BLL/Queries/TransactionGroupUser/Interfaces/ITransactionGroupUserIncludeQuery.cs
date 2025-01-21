namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for transaction group users.
    /// </summary>
    internal interface ITransactionGroupUserIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        bool IncludeTransactions { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include user in the query result.
        /// </summary>
        bool IncludeCategory { get; set; }
    }
}
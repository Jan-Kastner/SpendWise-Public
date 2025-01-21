namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for group users.
    /// </summary>
    internal interface IGroupUserIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        bool IncludeTransactions { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include user in the query result.
        /// </summary>
        bool IncludeUser { get; set; }
    }
}
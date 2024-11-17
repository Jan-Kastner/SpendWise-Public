namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for groups.
    /// </summary>
    public interface IGroupIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include users in the query result.
        /// </summary>
        bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        bool IncludeTransactions { get; }

        /// <summary>
        /// Gets a value indicating whether to include categories in the query result.
        /// </summary>
        bool IncludeCategories { get; }
    }
}
namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Interface for queries that support includes for transactions.
    /// </summary>
    public interface ITransactionIncludeQuery
    {
        /// <summary>
        /// Gets a value indicating whether to include the category in the query result.
        /// </summary>
        bool IncludeCategory { get; }

        /// <summary>
        /// Gets a value indicating whether to include the transaction group users in the query result.
        /// </summary>
        bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the user in the query result.
        /// </summary>
        bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include the participants in the query result.
        /// </summary>
        bool IncludeParticipants { get; }
    }
}
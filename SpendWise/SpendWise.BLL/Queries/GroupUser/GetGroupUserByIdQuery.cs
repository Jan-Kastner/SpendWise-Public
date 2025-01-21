using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving a group user by its unique identifier.
    /// </summary>
    internal class GetGroupUserByIdQuery : IIdQuery, IGroupUserIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; set; }

        /// <summary>
        /// Gets a value indicating whether to include user in the query result.
        /// </summary>
        public bool IncludeUser { get; set; }
    }
}
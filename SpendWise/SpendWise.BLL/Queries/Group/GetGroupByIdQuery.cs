using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving a group by its unique identifier.
    /// </summary>
    public class GetGroupByIdQuery : IIdQuery, IGroupIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether to include users in the query result.
        /// </summary>
        public bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include categories in the query result.
        /// </summary>
        public bool IncludeCategories { get; }

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGroupByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="includeUser">A value indicating whether to include users in the query result. Default is false.</param>
        /// <param name="includeCategories">A value indicating whether to include categories in the query result. Default is false.</param>
        /// <param name="includeTransactions">A value indicating whether to include transactions in the query result. Default is false.</param>
        public GetGroupByIdQuery(Guid id, bool includeUser = false, bool includeCategories = false, bool includeTransactions = false)
        {
            Id = id;
            IncludeUser = includeUser;
            IncludeCategories = includeCategories;
            IncludeTransactions = includeTransactions;
        }
    }
}
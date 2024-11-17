using System;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving a transaction by its unique identifier.
    /// </summary>
    public class GetTransactionByIdQuery : IIdQuery, ITransactionIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether to include the category in the query result.
        /// </summary>
        public bool IncludeCategory { get; }

        /// <summary>
        /// Gets a value indicating whether to include the transaction group users in the query result.
        /// </summary>
        public bool IncludeGroups { get; }

        /// <summary>
        /// Gets a value indicating whether to include the user in the query result.
        /// </summary>
        public bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include the participants in the query result.
        /// </summary>
        public bool IncludeParticipants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="includeCategory">A value indicating whether to include the category in the query result. Default is false.</param>
        /// <param name="includeGroups">A value indicating whether to include the transaction group users in the query result. Default is false.</param>
        /// <param name="includeUser">A value indicating whether to include the user in the query result. Default is false.</param>
        /// <param name="includeParticipants">A value indicating whether to include the participants in the query result. Default is false.</param>
        public GetTransactionByIdQuery(Guid id, bool includeCategory = false, bool includeGroups = false, bool includeUser = false, bool includeParticipants = false)
        {
            Id = id;
            IncludeCategory = includeCategory;
            IncludeGroups = includeGroups;
            IncludeUser = includeUser;
            IncludeParticipants = includeParticipants;
        }
    }
}
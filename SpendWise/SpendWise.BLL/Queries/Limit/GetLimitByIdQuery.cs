using SpendWise.BLL.Queries.Interfaces;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query to get a limit by its ID.
    /// </summary>
    public class GetLimitByIdQuery : IIdQuery, ILimitIncludeQuery
    {
        /// <summary>
        /// Gets the ID of the limit.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLimitByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The ID of the limit.</param>
        public GetLimitByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
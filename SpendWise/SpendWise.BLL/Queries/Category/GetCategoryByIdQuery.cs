using SpendWise.BLL.Queries.Interfaces;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query to get a category by its ID.
    /// </summary>
    public class GetCategoryByIdQuery : ICategoryIncludeQuery, IIdQuery
    {
        /// <summary>
        /// Gets the ID of the category.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <param name="includeTransactions">A value indicating whether to include transactions in the query result. Default is false.</param>
        public GetCategoryByIdQuery(Guid id, bool includeTransactions = false)
        {
            Id = id;
            IncludeTransactions = includeTransactions;
        }
    }
}
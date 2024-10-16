using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a base query object for retrieving entities by their unique identifier.
    /// </summary>
    public abstract class BaseIdQuery : IIdQuery
    {
        /// <summary>
        /// Gets the unique identifier of the entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        protected BaseIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
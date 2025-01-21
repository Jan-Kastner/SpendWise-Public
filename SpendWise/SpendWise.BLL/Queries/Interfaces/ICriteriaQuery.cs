namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for criteria-based queries.
    /// </summary>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query.</typeparam>
    public interface ICriteriaQuery<TCriteriaQuery> where TCriteriaQuery : class
    {
        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        List<TCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        List<TCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        List<TCriteriaQuery>? Not { get; }
    }
}
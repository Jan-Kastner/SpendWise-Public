namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query to retrieve an item by its identifier.
    /// </summary>
    public class GetItemByIdQuery
    {
        /// <summary>
        /// Gets the unique identifier of the item to be retrieved.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the item to be retrieved.</param>
        public GetItemByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
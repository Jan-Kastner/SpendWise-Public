namespace SpendWise.BLL.Queries.Categories
{
    /// <summary>
    /// Represents a query to retrieve a category by its name.
    /// </summary>
    public class GetCategoryByNameQuery
    {
        /// <summary>
        /// Gets the name used to filter categories.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByNameQuery"/> class.
        /// </summary>
        /// <param name="name">The name used to filter categories.</param>
        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
    }
}
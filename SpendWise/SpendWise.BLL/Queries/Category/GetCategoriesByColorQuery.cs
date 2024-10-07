namespace SpendWise.BLL.Queries.Categories
{
    /// <summary>
    /// Represents a query to retrieve categories by their color.
    /// </summary>
    public class GetCategoriesByColorQuery
    {
        /// <summary>
        /// Gets the color used to filter categories.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoriesByColorQuery"/> class.
        /// </summary>
        /// <param name="color">The color used to filter categories.</param>
        public GetCategoriesByColorQuery(string color)
        {
            Color = color;
        }
    }
}
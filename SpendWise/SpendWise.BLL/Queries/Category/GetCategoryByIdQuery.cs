namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving a category by its unique identifier.
    /// </summary>
    public class GetCategoryByIdQuery : BaseIdQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdQuery"/> class.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category.</param>
        public GetCategoryByIdQuery(Guid categoryId) : base(categoryId)
        {
        }
    }
}
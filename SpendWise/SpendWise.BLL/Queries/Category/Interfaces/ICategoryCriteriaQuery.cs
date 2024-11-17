namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for category criteria-based queries.
    /// </summary>
    public interface ICategoryCriteriaQuery : ICriteriaQuery
    {
        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Gets the partial match for the category name.
        /// </summary>
        string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the name that should not match the category name.
        /// </summary>
        string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the category name.
        /// </summary>
        string? NotNamePartialMatch { get; }

        /// <summary>
        /// Gets the description of the category.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// Gets the partial match for the category description.
        /// </summary>
        string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the category description.
        /// </summary>
        string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the category description.
        /// </summary>
        string? NotDescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the color associated with the category.
        /// </summary>
        string? Color { get; }

        /// <summary>
        /// Gets the color that should not match the category color.
        /// </summary>
        string? NotColor { get; }

        /// <summary>
        /// Gets a value indicating whether the category should be without a description.
        /// </summary>
        bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the category should not be without a description.
        /// </summary>
        bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the category should be without an icon.
        /// </summary>
        bool? WithoutIcon { get; }

        /// <summary>
        /// Gets a value indicating whether the category should not be without an icon.
        /// </summary>
        bool? NotWithoutIcon { get; }
    }
}
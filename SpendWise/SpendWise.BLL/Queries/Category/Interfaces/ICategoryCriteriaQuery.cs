namespace SpendWise.BLL.Queries.Interfaces
{
    /// <summary>
    /// Represents an interface for category criteria-based queries.
    /// </summary>
    public interface ICategoryCriteriaQuery : ICriteriaQuery<ICategoryCriteriaQuery>
    {
        #region Name

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

        #endregion

        #region Description

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

        #endregion

        #region Color

        /// <summary>
        /// Gets the color associated with the category.
        /// </summary>
        string? Color { get; }

        /// <summary>
        /// Gets the color that should not match the category color.
        /// </summary>
        string? NotColor { get; }

        #endregion

        #region WithDescription

        /// <summary>
        /// Gets a value indicating whether the category should be with a description.
        /// </summary>
        bool? WithDescription { get; }

        #endregion

        #region WithIcon

        /// <summary>
        /// Gets a value indicating whether the category should be with an icon.
        /// </summary>
        bool? WithIcon { get; }

        #endregion
    }
}
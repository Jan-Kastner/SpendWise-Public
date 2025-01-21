using SpendWise.BLL.Queries.Interfaces;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving categories based on various criteria.
    /// </summary>
    public class GetCategoriesByCriteriaQuery : ICategoryIncludeQuery, ICategoryCriteriaQuery
    {
        #region Name

        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the partial match for the category name.
        /// </summary>
        public string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the name that should not match the category name.
        /// </summary>
        public string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the category name.
        /// </summary>
        public string? NotNamePartialMatch { get; }

        #endregion

        #region Description

        /// <summary>
        /// Gets the description of the category.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets the partial match for the category description.
        /// </summary>
        public string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the category description.
        /// </summary>
        public string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the category description.
        /// </summary>
        public string? NotDescriptionPartialMatch { get; }

        #endregion

        #region Color

        /// <summary>
        /// Gets the color associated with the category.
        /// </summary>
        public string? Color { get; }

        /// <summary>
        /// Gets the color that should not match the category color.
        /// </summary>
        public string? NotColor { get; }

        #endregion

        #region WithDescription

        /// <summary>
        /// Gets a value indicating whether the category should be without a description.
        /// </summary>
        public bool? WithDescription { get; }

        #endregion

        #region WithIcon

        /// <summary>
        /// Gets a value indicating whether the category should be without an icon.
        /// </summary>
        public bool? WithIcon { get; }

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<ICategoryCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<ICategoryCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<ICategoryCriteriaQuery>? Not { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoriesByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="namePartialMatch">The partial match for the category name.</param>
        /// <param name="notName">The name that should not match the category name.</param>
        /// <param name="notNamePartialMatch">The partial match for the name that should not match the category name.</param>
        /// <param name="description">The description of the category.</param>
        /// <param name="descriptionPartialMatch">The partial match for the category description.</param>
        /// <param name="notDescription">The description that should not match the category description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the category description.</param>
        /// <param name="color">The color associated with the category.</param>
        /// <param name="notColor">The color that should not match the category color.</param>
        /// <param name="withDescription">A value indicating whether the category should be without a description.</param>
        /// <param name="withIcon">A value indicating whether the category should be without an icon.</param>
        /// <param name="and">The list of query objects to combine with AND.</param>
        /// <param name="or">The list of query objects to combine with OR.</param>
        /// <param name="not">The list of query objects to negate.</param>
        public GetCategoriesByCriteriaQuery(
            string? name = null,
            string? namePartialMatch = null,
            string? notName = null,
            string? notNamePartialMatch = null,
            string? description = null,
            string? descriptionPartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            string? color = null,
            string? notColor = null,
            bool? withDescription = null,
            bool? withIcon = null,
            List<GetCategoriesByCriteriaQuery>? and = null,
            List<GetCategoriesByCriteriaQuery>? or = null,
            List<GetCategoriesByCriteriaQuery>? not = null)
        {
            Name = name;
            NamePartialMatch = namePartialMatch;
            NotName = notName;
            NotNamePartialMatch = notNamePartialMatch;
            Description = description;
            DescriptionPartialMatch = descriptionPartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            Color = color;
            NotColor = notColor;
            WithDescription = withDescription;
            WithIcon = withIcon;
            And = and?.Cast<ICategoryCriteriaQuery>().ToList();
            Or = or?.Cast<ICategoryCriteriaQuery>().ToList();
            Not = not?.Cast<ICategoryCriteriaQuery>().ToList();
        }
    }
}
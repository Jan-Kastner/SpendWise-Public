using SpendWise.BLL.Queries.Interfaces;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving categories based on various criteria.
    /// </summary>
    public class GetCategoriesByCriteriaQuery : ICategoryCriteriaQuery
    {
        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the unique identifier of the category.
        /// </summary>
        public Guid? Id { get; }

        /// <summary>
        /// Gets the description of the category.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets the color associated with the category.
        /// </summary>
        public string? Color { get; }

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

        /// <summary>
        /// Gets the description that should not match the category description.
        /// </summary>
        public string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the category description.
        /// </summary>
        public string? NotDescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the color that should not match the category color.
        /// </summary>
        public string? NotColor { get; }

        /// <summary>
        /// Gets a value indicating whether the category should be without a description.
        /// </summary>
        public bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the category should not be without a description.
        /// </summary>
        public bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the category should be without an icon.
        /// </summary>
        public bool? WithoutIcon { get; }

        /// <summary>
        /// Gets a value indicating whether the category should not be without an icon.
        /// </summary>
        public bool? NotWithoutIcon { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoriesByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="id">The unique identifier of the category.</param>
        /// <param name="description">The description of the category.</param>
        /// <param name="color">The color associated with the category.</param>
        /// <param name="namePartialMatch">The partial match for the category name.</param>
        /// <param name="notName">The name that should not match the category name.</param>
        /// <param name="notNamePartialMatch">The partial match for the name that should not match the category name.</param>
        /// <param name="notDescription">The description that should not match the category description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the category description.</param>
        /// <param name="notColor">The color that should not match the category color.</param>
        /// <param name="withoutDescription">Indicates whether the category should be without a description.</param>
        /// <param name="notWithoutDescription">Indicates whether the category should not be without a description.</param>
        /// <param name="withoutIcon">Indicates whether the category should be without an icon.</param>
        /// <param name="notWithoutIcon">Indicates whether the category should not be without an icon.</param>
        public GetCategoriesByCriteriaQuery(
            string? name = null,
            Guid? id = null,
            string? description = null,
            string? color = null,
            string? namePartialMatch = null,
            string? notName = null,
            string? notNamePartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            string? notColor = null,
            bool? withoutDescription = null,
            bool? notWithoutDescription = null,
            bool? withoutIcon = null,
            bool? notWithoutIcon = null)
        {
            Name = name;
            Id = id;
            Description = description;
            Color = color;
            NamePartialMatch = namePartialMatch;
            NotName = notName;
            NotNamePartialMatch = notNamePartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            NotColor = notColor;
            WithoutDescription = withoutDescription;
            NotWithoutDescription = notWithoutDescription;
            WithoutIcon = withoutIcon;
            NotWithoutIcon = notWithoutIcon;
        }
    }
}
using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="CategoryEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class CategoryQueryObject : BaseQueryObject<CategoryEntity, CategoryQueryObject>, ICategoryQueryObject<CategoryQueryObject>
    {
        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithId(Guid id) => base.WithId(id);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithId(Guid id) => base.OrWithId(id);

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithId(Guid id) => base.NotWithId(id);

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithName(string name) => base.WithName(name);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithName(string name) => base.OrWithName(name);

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithName(string name) => base.NotWithName(name);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithNamePartialMatch(string text) => base.WithNamePartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithNamePartialMatch(string text) => base.OrWithNamePartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithNamePartialMatch(string text) => base.NotWithNamePartialMatch(text);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithDescription(string? description) => base.WithDescription(description);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithDescription(string? description) => base.OrWithDescription(description);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithDescription(string? description) => base.NotWithDescription(description);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithDescriptionPartialMatch(string text) => base.WithDescriptionPartialMatch(text);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithDescriptionPartialMatch(string text) => base.OrWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithDescriptionPartialMatch(string text) => base.NotWithDescriptionPartialMatch(text);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithoutDescription() => base.WithoutDescription();

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithoutDescription() => base.OrWithoutDescription();

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithoutDescription() => base.NotWithoutDescription();

        #endregion

        #region IColorQuery

        /// <summary>
        /// Filters the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithColor(string color) => base.WithColor(color);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithColor(string color) => base.OrWithColor(color);

        /// <summary>
        /// Filters the query to exclude items with the specified color.
        /// </summary>
        /// <param name="color">The color to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithColor(string color) => base.NotWithColor(color);

        #endregion

        #region IIconQuery

        /// <summary>
        /// Filters the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithIcon() => base.WithIcon();

        /// <summary>
        /// Adds an OR condition to the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithIcon() => base.OrWithIcon();

        /// <summary>
        /// Filters the query to exclude items with an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithIcon() => base.NotWithIcon();

        /// <summary>
        /// Filters the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public new CategoryQueryObject WithoutIcon() => base.WithoutIcon();

        /// <summary>
        /// Adds an OR condition to the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public new CategoryQueryObject OrWithoutIcon() => base.OrWithoutIcon();

        /// <summary>
        /// Filters the query to exclude items without an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public new CategoryQueryObject NotWithoutIcon() => base.NotWithoutIcon();

        #endregion
    }
}
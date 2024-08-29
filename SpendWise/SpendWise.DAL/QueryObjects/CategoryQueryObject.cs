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
    public class CategoryQueryObject : QueryObject<CategoryEntity>
    {
        #region AND

        /// <summary>
        /// Adds a condition to compare the category ID using an AND operation.
        /// </summary>
        /// <param name="id">The category ID to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category name using an AND operation.
        /// </summary>
        /// <param name="name">The category name to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category color using an AND operation.
        /// </summary>
        /// <param name="color">The category color to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithColor(string color)
        {
            // Ensure that both sides of the comparison are converted to lowercase
            And(entity => entity.Color.ToLower() == color.ToLower());
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category description using an AND operation.
        /// </summary>
        /// <param name="description">The category description to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithDescription(string? description)
        {
            if (description != null)
            {
                And(entity => entity.Description != null && entity.Description.Contains(description));
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories with a null description using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories with an icon using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithIcon()
        {
            And(entity => entity.Icon.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories without an icon using an AND operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithoutIcon()
        {
            And(entity => entity.Icon.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category name for partial matches using an AND operation.
        /// </summary>
        /// <param name="text">The text to search within the category name.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithNamePartialMatch(string text)
        {
            And(entity => entity.Name.Contains(text));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category description for partial matches using an AND operation.
        /// </summary>
        /// <param name="text">The text to search within the category description.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject WithDescriptionPartialMatch(string text)
        {
            And(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }

        #endregion

        #region OR

        /// <summary>
        /// Adds a condition to compare the category ID using an OR operation.
        /// </summary>
        /// <param name="id">The category ID to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category name using an OR operation.
        /// </summary>
        /// <param name="name">The category name to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category color using an OR operation.
        /// </summary>
        /// <param name="color">The category color to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithColor(string color)
        {
            Or(entity => entity.Color.ToLower() == color.ToLower());
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category description using an OR operation.
        /// </summary>
        /// <param name="description">The category description to compare.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithDescription(string? description)
        {
            if (description != null)
            {
                Or(entity => entity.Description != null && entity.Description.Contains(description));
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories with a null description using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithNullDescription()
        {
            Or(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories with an icon using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithIcon()
        {
            Or(entity => entity.Icon.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to include categories without an icon using an OR operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithoutIcon()
        {
            Or(entity => entity.Icon.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category name for partial matches using an OR operation.
        /// </summary>
        /// <param name="text">The text to search within the category name.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithNamePartialMatch(string text)
        {
            Or(entity => entity.Name.Contains(text));
            return this;
        }

        /// <summary>
        /// Adds a condition to compare the category description for partial matches using an OR operation.
        /// </summary>
        /// <param name="text">The text to search within the category description.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject OrWithDescriptionPartialMatch(string text)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }

        #endregion

        #region NOT

        /// <summary>
        /// Adds a condition to exclude categories with a specific ID using a NOT operation.
        /// </summary>
        /// <param name="id">The category ID to exclude.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a specific name using a NOT operation.
        /// </summary>
        /// <param name="name">The category name to exclude.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a specific color using a NOT operation.
        /// </summary>
        /// <param name="color">The category color to exclude.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithColor(string color)
        {
            Not(entity => entity.Color.ToLower() == color.ToLower());
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a specific description using a NOT operation.
        /// </summary>
        /// <param name="description">The category description to exclude.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithDescription(string? description)
        {
            if (description != null)
            {
                Not(entity => entity.Description != null && entity.Description.Contains(description));
            }
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a null description using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithNullDescription()
        {
            Not(entity => entity.Description == null);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with an icon using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithIcon()
        {
            Not(entity => entity.Icon.Length > 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories without an icon using a NOT operation.
        /// </summary>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithoutIcon()
        {
            Not(entity => entity.Icon.Length == 0);
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a partial name match using a NOT operation.
        /// </summary>
        /// <param name="text">The text to exclude from the category name.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithNamePartialMatch(string text)
        {
            Not(entity => entity.Name.Contains(text));
            return this;
        }

        /// <summary>
        /// Adds a condition to exclude categories with a partial description match using a NOT operation.
        /// </summary>
        /// <param name="text">The text to exclude from the category description.</param>
        /// <returns>The current instance of <see cref="CategoryQueryObject"/>.</returns>
        public CategoryQueryObject NotWithDescriptionPartialMatch(string text)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }

        #endregion
    }
}

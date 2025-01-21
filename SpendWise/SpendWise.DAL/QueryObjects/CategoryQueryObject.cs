using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects.Interfaces;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object for the <see cref="CategoryEntity"/>.
    /// Enables query construction using methods for AND, OR, and NOT operations.
    /// </summary>
    public class CategoryQueryObject : BaseQueryObject<CategoryEntity, CategoryQueryObject>, ICategoryQueryObject
    {
        /// <summary>
        /// Gets the collection of include directives used by the RelationConfigGenerator
        /// to generate EntityRelationsConfiguration, which acts as a state machine for managing includes.
        /// </summary>
        public override ICollection<Func<CategoryEntity, object>> IncludeDirectives { get; } = new List<Func<CategoryEntity, object>>
        {
        };

        #region IIdQuery

        /// <summary>
        /// Filters the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithId(Guid id) => ApplyIdFilter(id, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithId(Guid id) => ApplyIdFilter(id, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified ID.
        /// </summary>
        /// <param name="id">The ID to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithId(Guid id) => ApplyIdFilter(id, filter => Not(filter));

        #endregion

        #region INameQuery

        /// <summary>
        /// Filters the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithName(string name) => ApplyNameFilter(name, entity => entity.Name, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithNamePartialMatch(string text) => ApplyNameFilter(text, entity => entity.Name, filter => Not(filter), true);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithDescription(string? description) => ApplyDescriptionFilter(description, entity => entity.Description, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, entity => entity.Description, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Or(filter), false, true);

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithoutDescription() => ApplyDescriptionFilter(null, entity => entity.Description, filter => Not(filter), false, true);

        #endregion

        #region IColorQuery

        /// <summary>
        /// Filters the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithColor(string color) => ApplyColorFilter(entity => entity.Color, color, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithColor(string color) => ApplyColorFilter(entity => entity.Color, color, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified color.
        /// </summary>
        /// <param name="color">The color to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithColor(string color) => ApplyColorFilter(entity => entity.Color, color, filter => Not(filter));

        #endregion

        #region IIconQuery

        /// <summary>
        /// Filters the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithIcon() => ApplyIconFilter(entity => entity.Icon, true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithIcon() => ApplyIconFilter(entity => entity.Icon, true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithIcon() => ApplyIconFilter(entity => entity.Icon, true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithoutIcon() => ApplyIconFilter(entity => entity.Icon, false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithoutIcon() => ApplyIconFilter(entity => entity.Icon, false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithoutIcon() => ApplyIconFilter(entity => entity.Icon, false, filter => Not(filter));

        #endregion
    }
}
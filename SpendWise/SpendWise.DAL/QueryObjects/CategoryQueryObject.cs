using SpendWise.DAL.Entities;

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
        public CategoryQueryObject WithName(string name) => ApplyNameFilter(name, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified name.
        /// </summary>
        /// <param name="name">The name to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithName(string name) => ApplyNameFilter(name, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified name.
        /// </summary>
        /// <param name="name">The name to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithName(string name) => ApplyNameFilter(name, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithNamePartialMatch(string text) => ApplyNameFilter(text, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithNamePartialMatch(string text) => ApplyNameFilter(text, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the name.
        /// </summary>
        /// <param name="text">The text to partially match in the name.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithNamePartialMatch(string text) => ApplyNameFilter(text, filter => Not(filter), true);

        #endregion

        #region IDescriptionQuery

        /// <summary>
        /// Filters the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithDescription(string? description) => ApplyDescriptionFilter(description, filter => And(filter), false);

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified description.
        /// </summary>
        /// <param name="description">The description to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithDescription(string? description) => ApplyDescriptionFilter(description, filter => Or(filter), false);

        /// <summary>
        /// Filters the query to exclude items with the specified description.
        /// </summary>
        /// <param name="description">The description to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithDescription(string? description) => ApplyDescriptionFilter(description, filter => Not(filter), false);

        /// <summary>
        /// Filters the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => And(filter), true);

        /// <summary>
        /// Adds an OR condition to the query to include items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => Or(filter), true);

        /// <summary>
        /// Filters the query to exclude items with a partial match of the specified text in the description.
        /// </summary>
        /// <param name="text">The text to partially match in the description.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithDescriptionPartialMatch(string text) => ApplyDescriptionFilter(text, filter => Not(filter), true);

        /// <summary>
        /// Filters the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithoutDescription() => ApplyDescriptionFilter(null, filter => And(filter), false, true);

        /// <summary>
        /// Adds an OR condition to the query to include items without a description.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithoutDescription() => ApplyDescriptionFilter(null, filter => Or(filter), false, true);

        /// <summary>
        /// Filters the query to exclude items without a description.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithoutDescription() => ApplyDescriptionFilter(null, filter => Not(filter), false, true);

        #endregion

        #region IColorQuery

        /// <summary>
        /// Filters the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithColor(string color) => ApplyColorFilter(color, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with the specified color.
        /// </summary>
        /// <param name="color">The color to filter by.</param>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithColor(string color) => ApplyColorFilter(color, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with the specified color.
        /// </summary>
        /// <param name="color">The color to exclude.</param>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithColor(string color) => ApplyColorFilter(color, filter => Not(filter));

        #endregion

        #region IIconQuery

        /// <summary>
        /// Filters the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithIcon() => ApplyIconFilter(true, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items with an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithIcon() => ApplyIconFilter(true, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items with an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithIcon() => ApplyIconFilter(true, filter => Not(filter));

        /// <summary>
        /// Filters the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied filter.</returns>
        public CategoryQueryObject WithoutIcon() => ApplyIconFilter(false, filter => And(filter));

        /// <summary>
        /// Adds an OR condition to the query to include items without an icon.
        /// </summary>
        /// <returns>The query object with the applied OR condition.</returns>
        public CategoryQueryObject OrWithoutIcon() => ApplyIconFilter(false, filter => Or(filter));

        /// <summary>
        /// Filters the query to exclude items without an icon.
        /// </summary>
        /// <returns>The query object with the applied exclusion filter.</returns>
        public CategoryQueryObject NotWithoutIcon() => ApplyIconFilter(false, filter => Not(filter));

        #endregion
    }
}
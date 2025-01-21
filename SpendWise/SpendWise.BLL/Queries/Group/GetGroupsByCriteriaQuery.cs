using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving groups based on various criteria.
    /// </summary>
    public class GetGroupsByCriteriaQuery : IGroupCriteriaQuery, IGroupIncludeQuery
    {
        #region Name

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the partial match for the group name.
        /// </summary>
        public string? NamePartialMatch { get; }

        /// <summary>
        /// Gets the name that should not match the group name.
        /// </summary>
        public string? NotName { get; }

        /// <summary>
        /// Gets the partial match for the name that should not match the group name.
        /// </summary>
        public string? NotNamePartialMatch { get; }

        #endregion

        #region Description

        /// <summary>
        /// Gets the description of the group.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets the partial match for the group description.
        /// </summary>
        public string? DescriptionPartialMatch { get; }

        /// <summary>
        /// Gets the description that should not match the group description.
        /// </summary>
        public string? NotDescription { get; }

        /// <summary>
        /// Gets the partial match for the description that should not match the group description.
        /// </summary>
        public string? NotDescriptionPartialMatch { get; }

        #endregion

        #region WithDescription

        /// <summary>
        /// Gets a value indicating whether the group has a description.
        /// </summary>
        public bool? WithDescription { get; }


        #endregion

        #region InvitationId

        /// <summary>
        /// Gets the unique identifier of the invitation.
        /// </summary>
        public Guid? InvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        public Guid? NotInvitationId { get; }

        #endregion

        #region IncludeOptions

        /// <summary>
        /// Gets a value indicating whether to include users in the query result.
        /// </summary>
        public bool IncludeUser { get; }

        /// <summary>
        /// Gets a value indicating whether to include categories in the query result.
        /// </summary>
        public bool IncludeCategories { get; }

        /// <summary>
        /// Gets a value indicating whether to include transactions in the query result.
        /// </summary>
        public bool IncludeTransactions { get; }

        #endregion

        #region LogicalOperators

        /// <summary>
        /// Gets the list of query objects to combine with AND.
        /// </summary>
        public List<IGroupCriteriaQuery>? And { get; }

        /// <summary>
        /// Gets the list of query objects to combine with OR.
        /// </summary>
        public List<IGroupCriteriaQuery>? Or { get; }

        /// <summary>
        /// Gets the list of query objects to negate.
        /// </summary>
        public List<IGroupCriteriaQuery>? Not { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGroupsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="name">The name of the group.</param>
        /// <param name="namePartialMatch">The partial match for the group name.</param>
        /// <param name="notName">The name that should not match the group name.</param>
        /// <param name="notNamePartialMatch">The partial match for the name that should not match the group name.</param>
        /// <param name="description">The description of the group.</param>
        /// <param name="descriptionPartialMatch">The partial match for the group description.</param>
        /// <param name="notDescription">The description that should not match the group description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the group description.</param>
        /// <param name="withDescription">A value indicating whether the group has a description.</param>
        /// <param name="invitationId">The unique identifier of the invitation.</param>
        /// <param name="notInvitationId">The unique identifier of the invitation that should not match.</param>
        /// <param name="includeUser">A value indicating whether to include users in the query result. Default is false.</param>
        /// <param name="includeCategories">A value indicating whether to include categories in the query result. Default is false.</param>
        /// <param name="includeTransactions">A value indicating whether to include transactions in the query result. Default is false.</param>
        /// <param name="and">The list of query objects to combine with AND.</param>
        /// <param name="or">The list of query objects to combine with OR.</param>
        /// <param name="not">The list of query objects to negate.</param>
        public GetGroupsByCriteriaQuery(
            string? name = null,
            string? namePartialMatch = null,
            string? notName = null,
            string? notNamePartialMatch = null,
            string? description = null,
            string? descriptionPartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            bool? withDescription = null,
            Guid? invitationId = null,
            Guid? notInvitationId = null,
            bool includeUser = false,
            bool includeCategories = false,
            bool includeTransactions = false,
            List<IGroupCriteriaQuery>? and = null,
            List<IGroupCriteriaQuery>? or = null,
            List<IGroupCriteriaQuery>? not = null)
        {
            Name = name;
            NamePartialMatch = namePartialMatch;
            NotName = notName;
            NotNamePartialMatch = notNamePartialMatch;
            Description = description;
            DescriptionPartialMatch = descriptionPartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            WithDescription = withDescription;
            InvitationId = invitationId;
            NotInvitationId = notInvitationId;
            IncludeUser = includeUser;
            IncludeCategories = includeCategories;
            IncludeTransactions = includeTransactions;
            And = and;
            Or = or;
            Not = not;
        }
    }
}
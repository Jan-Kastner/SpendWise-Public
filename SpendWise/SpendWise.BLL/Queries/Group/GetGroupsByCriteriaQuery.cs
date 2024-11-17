using SpendWise.BLL.Queries.Interfaces;
using System;

namespace SpendWise.BLL.Queries
{
    /// <summary>
    /// Represents a query object for retrieving groups based on various criteria.
    /// </summary>
    public class GetGroupsByCriteriaQuery : IGroupCriteriaQuery, IGroupIncludeQuery
    {
        /// <summary>
        /// Gets the unique identifier of the category.
        /// </summary>
        public Guid? Id { get; }

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

        /// <summary>
        /// Gets a value indicating whether the group should be without a description.
        /// </summary>
        public bool? WithoutDescription { get; }

        /// <summary>
        /// Gets a value indicating whether the group should not be without a description.
        /// </summary>
        public bool? NotWithoutDescription { get; }

        /// <summary>
        /// Gets the unique identifier of the group user.
        /// </summary>
        public Guid? GroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the group user that should not match.
        /// </summary>
        public Guid? NotGroupUserId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation.
        /// </summary>
        public Guid? InvitationId { get; }

        /// <summary>
        /// Gets the unique identifier of the invitation that should not match.
        /// </summary>
        public Guid? NotInvitationId { get; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGroupsByCriteriaQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <param name="name">The name of the group.</param>
        /// <param name="namePartialMatch">The partial match for the group name.</param>
        /// <param name="notName">The name that should not match the group name.</param>
        /// <param name="notNamePartialMatch">The partial match for the name that should not match the group name.</param>
        /// <param name="description">The description of the group.</param>
        /// <param name="descriptionPartialMatch">The partial match for the group description.</param>
        /// <param name="notDescription">The description that should not match the group description.</param>
        /// <param name="notDescriptionPartialMatch">The partial match for the description that should not match the group description.</param>
        /// <param name="withoutDescription">Indicates whether the group should be without a description.</param>
        /// <param name="notWithoutDescription">Indicates whether the group should not be without a description.</param>
        /// <param name="groupUserId">The unique identifier of the group user.</param>
        /// <param name="notGroupUserId">The unique identifier of the group user that should not match.</param>
        /// <param name="invitationId">The unique identifier of the invitation.</param>
        /// <param name="notInvitationId">The unique identifier of the invitation that should not match.</param>
        /// <param name="includeUser">A value indicating whether to include users in the query result. Default is false.</param>
        /// <param name="includeCategories">A value indicating whether to include categories in the query result. Default is false.</param>
        /// <param name="includeTransactions">A value indicating whether to include transactions in the query result. Default is false.</param>
        public GetGroupsByCriteriaQuery(
            Guid? id = null,
            string? name = null,
            string? namePartialMatch = null,
            string? notName = null,
            string? notNamePartialMatch = null,
            string? description = null,
            string? descriptionPartialMatch = null,
            string? notDescription = null,
            string? notDescriptionPartialMatch = null,
            bool? withoutDescription = null,
            bool? notWithoutDescription = null,
            Guid? groupUserId = null,
            Guid? notGroupUserId = null,
            Guid? invitationId = null,
            Guid? notInvitationId = null,
            bool includeUser = false,
            bool includeCategories = false,
            bool includeTransactions = false)
        {
            Id = id;
            Name = name;
            NamePartialMatch = namePartialMatch;
            NotName = notName;
            NotNamePartialMatch = notNamePartialMatch;
            Description = description;
            DescriptionPartialMatch = descriptionPartialMatch;
            NotDescription = notDescription;
            NotDescriptionPartialMatch = notDescriptionPartialMatch;
            WithoutDescription = withoutDescription;
            NotWithoutDescription = notWithoutDescription;
            GroupUserId = groupUserId;
            NotGroupUserId = notGroupUserId;
            InvitationId = invitationId;
            NotInvitationId = notInvitationId;
            IncludeUser = includeUser;
            IncludeCategories = includeCategories;
            IncludeTransactions = includeTransactions;
        }
    }
}
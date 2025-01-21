using System;
using System.Collections.Generic;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for group-user relationship entities within the SpendWise application.
    /// </summary>
    public interface IGroupUserEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the user's role within the application (e.g., Admin, User).
        /// </summary>
        UserRole Role { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        Guid UserId { get; init; }

        /// <summary>
        /// Gets or sets the user entity associated with this group-user relationship.
        /// </summary>
        UserEntity User { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the group.
        /// </summary>
        Guid GroupId { get; init; }

        /// <summary>
        /// Gets or sets the group entity associated with this group-user relationship.
        /// </summary>
        GroupEntity Group { get; init; }

        /// <summary>
        /// Gets or sets the unique identifier for the associated limit entity, if any.
        /// </summary>
        Guid? LimitId { get; init; }

        /// <summary>
        /// Gets or sets the limit entity associated with this group-user relationship. Can be null.
        /// </summary>
        LimitEntity? Limit { get; init; }

        /// <summary>
        /// Gets the collection of transaction group-user relationships associated with this group-user relationship.
        /// </summary>
        ICollection<TransactionGroupUserEntity> TransactionGroupUsers { get; init; }
    }
}
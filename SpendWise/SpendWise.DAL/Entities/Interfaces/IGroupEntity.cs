using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for group entities within the SpendWise application.
    /// </summary>
    public interface IGroupEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the group. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the group. Can be null.
        /// </summary>
        string? Description { get; init; }

        /// <summary>
        /// Gets the collection of users associated with this group.
        /// </summary>
        ICollection<GroupUserEntity> GroupUsers { get; init; }

        /// <summary>
        /// Gets the collection of invitations associated with this group.
        /// </summary>
        ICollection<InvitationEntity> Invitations { get; init; }
    }
}
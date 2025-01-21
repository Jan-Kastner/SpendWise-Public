using System;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for limit entities within the SpendWise application.
    /// </summary>
    public interface ILimitEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the associated group-user relationship.
        /// </summary>
        Guid GroupUserId { get; init; }

        /// <summary>
        /// Gets or sets the amount of the limit.
        /// </summary>
        decimal Amount { get; init; }

        /// <summary>
        /// Gets or sets the type of notice associated with the limit.
        /// </summary>
        NoticeType NoticeType { get; init; }
    }
}
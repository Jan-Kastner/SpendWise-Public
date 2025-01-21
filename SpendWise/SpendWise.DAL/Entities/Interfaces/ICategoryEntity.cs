using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpendWise.DAL.Entities.Interfaces
{
    /// <summary>
    /// Represents an interface for category entities within the SpendWise application.
    /// </summary>
    public interface ICategoryEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the name of the category. Must be at least 2 characters long.
        /// </summary>
        [MinLength(2)]
        string Name { get; init; }

        /// <summary>
        /// Gets or sets the description of the category. Can be null.
        /// </summary>
        string? Description { get; init; }

        /// <summary>
        /// Gets or sets the color associated with the category. Must be at most 9 characters long.
        /// </summary>
        [MaxLength(9)]
        string Color { get; init; }

        /// <summary>
        /// Gets or sets the icon for the category. Can be null.
        /// </summary>
        byte[] Icon { get; init; }

        /// <summary>
        /// Gets the collection of transactions associated with this category.
        /// </summary>
        ICollection<TransactionEntity> Transactions { get; init; }
    }
}
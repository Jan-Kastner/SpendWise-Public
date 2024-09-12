using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a user role.
    /// </summary>
    public interface IUserRole
    {
        /// <summary>
        /// Gets or sets the user role of the entity.
        /// </summary>
        UserRole Role { get; set; }
    }
}
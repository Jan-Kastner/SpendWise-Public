using SpendWise.Common.Enums;

namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a preferred theme.
    /// </summary>
    public interface IPreferredTheme
    {
        /// <summary>
        /// Gets or sets the preferred theme of the entity.
        /// </summary>
        Theme PreferredTheme { get; set; }
    }
}
namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has an icon.
    /// </summary>
    public interface IIcon
    {
        /// <summary>
        /// Gets or sets the icon of the entity.
        /// </summary>
        byte[] Icon { get; init; }
    }
}
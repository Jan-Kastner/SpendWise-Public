namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a color.
    /// </summary>
    public interface IColor
    {
        /// <summary>
        /// Gets or sets the color of the entity.
        /// </summary>
        string Color { get; set; }
    }
}
namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a photo.
    /// </summary>
    public interface IPhoto
    {
        /// <summary>
        /// Gets or sets the photo of the entity.
        /// </summary>
        byte[] Photo { get; init; }
    }
}
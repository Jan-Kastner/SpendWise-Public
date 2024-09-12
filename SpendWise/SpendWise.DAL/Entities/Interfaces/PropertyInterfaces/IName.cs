namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents an entity that has a name.
    /// </summary>
    public interface IName
    {
        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        string Name { get; set; }
    }
}
namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a category entity with various properties and behaviors.
    /// </summary>
    public interface ICategoryEntity : IEntity, IName, IDescription, IColor, IIcon
    {
    }
}
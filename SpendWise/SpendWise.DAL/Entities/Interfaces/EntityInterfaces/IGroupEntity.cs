namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a group entity with various properties and behaviors.
    /// </summary>
    public interface IGroupEntity : IEntity, IName, IDescription, IGroupUsers, IInvitations
    {
    }
}
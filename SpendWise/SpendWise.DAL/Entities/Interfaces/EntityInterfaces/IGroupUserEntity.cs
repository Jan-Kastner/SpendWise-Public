namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a group user entity with various properties and behaviors.
    /// </summary>
    public interface IGroupUserEntity : IEntity, IUserRole, IUserId, IGroupId, ILimitId
    {
    }
}
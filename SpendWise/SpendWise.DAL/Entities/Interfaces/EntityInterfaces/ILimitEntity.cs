namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a limit entity with various properties.
    /// </summary>
    public interface ILimitEntity : IEntity, IGroupUserId, IAmount, INoticeType
    {
    }
}
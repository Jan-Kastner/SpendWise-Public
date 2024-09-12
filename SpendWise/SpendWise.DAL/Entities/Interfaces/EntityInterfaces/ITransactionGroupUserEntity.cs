// create interface itransactiongroupuserentity
namespace SpendWise.DAL.Entities
{
    /// <summary>
    /// Represents a transaction entity with various properties.
    /// </summary>
    public interface ITransactionGroupUserEntity : IEntity, ITransactionId, IGroupUserId, IIsRead
    {
    }
}
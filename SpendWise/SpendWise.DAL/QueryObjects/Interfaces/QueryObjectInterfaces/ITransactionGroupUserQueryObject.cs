using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for transaction group users.
    /// Provides methods for querying transaction group users by various properties.
    /// </summary>
    public interface ITransactionGroupUserQueryObject : IQueryObject, IIdQuery<TransactionGroupUserQueryObject>, IIsReadQuery<TransactionGroupUserQueryObject>, IUserIdQuery<TransactionGroupUserQueryObject>, ITransactionQuery<TransactionGroupUserQueryObject>, IGroupUserIdQuery<TransactionGroupUserQueryObject>
    {
    }
}
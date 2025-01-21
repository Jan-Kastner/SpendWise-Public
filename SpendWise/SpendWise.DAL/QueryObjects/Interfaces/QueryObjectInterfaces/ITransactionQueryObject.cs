using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;

namespace SpendWise.DAL.QueryObjects.Interfaces
{
    /// <summary>
    /// Represents a query object interface for transactions.
    /// Provides methods for querying transactions by various properties.
    /// </summary>
    public interface ITransactionQueryObject : IQueryObject, IIdQuery<TransactionQueryObject>, IDescriptionQuery<TransactionQueryObject>, IAmountQuery<TransactionQueryObject>, ITransactionGroupUserIdQuery<TransactionQueryObject>, IDateQuery<TransactionQueryObject>, ITransactionTypeQuery<TransactionQueryObject>, ICategoryQuery<TransactionQueryObject>, IUserIdQuery<TransactionQueryObject>, IGroupIdQuery<TransactionQueryObject>
    {
    }
}
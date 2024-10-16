using SpendWise.DAL.QueryObjects.Interfaces.QueryPropertyInterfaces;
using SpendWise.Common.Enums;

namespace SpendWise.DAL.QueryObjects
{
    /// <summary>
    /// Represents a query object interface for transactions.
    /// Provides methods for querying transactions by various properties.
    /// </summary>
    public interface ITransactionQueryObject : IQueryObject, IIdQuery<TransactionQueryObject>, IDescriptionQuery<TransactionQueryObject>, IAmountQuery<TransactionQueryObject>, ITransactionGroupUserQuery<TransactionQueryObject>, IDateQuery<TransactionQueryObject>, ITransactionTypeQuery<TransactionQueryObject>, ICategoryQuery<TransactionQueryObject>
    {
    }
}
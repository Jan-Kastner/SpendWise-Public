using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing transactions.
    /// </summary>
    public interface ITransactionService : IService<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery>
    {
    }
}
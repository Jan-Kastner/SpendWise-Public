using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface ICreateTransactionCommandHandler : ICreateItemCommandHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery>
    {
    }
}
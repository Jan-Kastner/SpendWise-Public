using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class DeleteTransactionCommandHandler : DeleteItemCommandHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery>, IDeleteTransactionCommandHandler
    {
        public DeleteTransactionCommandHandler(ITransactionService service) : base(service)
        {
        }
    }
}
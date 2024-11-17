using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateTransactionCommandHandler : UpdateItemCommandHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery>, IUpdateTransactionCommandHandler
    {
        public UpdateTransactionCommandHandler(ITransactionService service) : base(service)
        {
        }
    }
}
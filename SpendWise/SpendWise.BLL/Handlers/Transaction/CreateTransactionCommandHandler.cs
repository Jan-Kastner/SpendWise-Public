using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class CreateTransactionCommandHandler : CreateItemCommandHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery>, ICreateTransactionCommandHandler
    {
        public CreateTransactionCommandHandler(ITransactionService service) : base(service)
        {
        }
    }
}
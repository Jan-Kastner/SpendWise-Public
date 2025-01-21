using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class DeleteTransactionGroupUserCommandHandler : DeleteItemCommandHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery>, IDeleteTransactionGroupUserCommandHandler
    {
        public DeleteTransactionGroupUserCommandHandler(ITransactionGroupUserService service) : base(service)
        {
        }
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class UpdateTransactionGroupUserCommandHandler : UpdateItemCommandHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery>, IUpdateTransactionGroupUserCommandHandler
    {
        public UpdateTransactionGroupUserCommandHandler(ITransactionGroupUserService service) : base(service)
        {
        }
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class CreateTransactionGroupUserCommandHandler : CreateItemCommandHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery>, ICreateTransactionGroupUserCommandHandler
    {
        public CreateTransactionGroupUserCommandHandler(ITransactionGroupUserService service) : base(service)
        {
        }
    }
}
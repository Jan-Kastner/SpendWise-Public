using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    internal interface ICreateTransactionGroupUserCommandHandler : ICreateItemCommandHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery>
    {
    }
}

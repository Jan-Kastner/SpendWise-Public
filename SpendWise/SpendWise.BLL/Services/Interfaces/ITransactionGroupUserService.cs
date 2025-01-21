using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing transaction group users.
    /// </summary>
    internal interface ITransactionGroupUserService : IService<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery>
    {
    }
}
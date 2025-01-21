using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    internal interface IGetTransactionGroupUsersByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
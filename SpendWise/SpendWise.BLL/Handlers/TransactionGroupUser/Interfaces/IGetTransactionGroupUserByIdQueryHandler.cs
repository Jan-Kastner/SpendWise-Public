using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    internal interface IGetTransactionGroupUserByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
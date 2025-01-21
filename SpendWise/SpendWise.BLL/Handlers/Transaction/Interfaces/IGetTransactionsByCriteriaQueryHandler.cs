using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetTransactionsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using System.Collections.Generic;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetTransactionsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
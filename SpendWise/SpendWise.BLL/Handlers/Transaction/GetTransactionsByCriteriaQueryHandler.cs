using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetTransactionsByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery, TDto>, IGetTransactionsByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetTransactionsByCriteriaQueryHandler(ITransactionService service) : base(service)
        {
        }
    }
}
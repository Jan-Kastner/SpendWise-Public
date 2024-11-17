using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetTransactionByIdQueryHandler<TDto> : GetItemByIdQueryHandler<TransactionCreateDto, TransactionUpdateDto, ITransactionCriteriaQuery, TDto>, IGetTransactionByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetTransactionByIdQueryHandler(ITransactionService service) : base(service)
        {
        }
    }
}
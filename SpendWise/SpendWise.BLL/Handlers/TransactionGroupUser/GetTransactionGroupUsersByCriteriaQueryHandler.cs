using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class GetTransactionGroupUsersByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery, TDto>, IGetTransactionGroupUsersByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetTransactionGroupUsersByCriteriaQueryHandler(ITransactionGroupUserService service) : base(service)
        {
        }
    }
}
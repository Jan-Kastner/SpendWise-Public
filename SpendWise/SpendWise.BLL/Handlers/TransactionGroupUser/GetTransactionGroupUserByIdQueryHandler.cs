using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    internal class GetTransactionGroupUserByIdQueryHandler<TDto> : GetItemByIdQueryHandler<TransactionGroupUserCreateDto, TransactionGroupUserUpdateDto, ITransactionGroupUserCriteriaQuery, TDto>, IGetTransactionGroupUserByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetTransactionGroupUserByIdQueryHandler(ITransactionGroupUserService service) : base(service)
        {
        }
    }
}
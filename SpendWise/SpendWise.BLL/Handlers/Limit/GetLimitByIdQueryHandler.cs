using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetLimitByIdQueryHandler<TDto> : GetItemByIdQueryHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery, TDto>, IGetLimitByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetLimitByIdQueryHandler(ILimitService service) : base(service)
        {
        }
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetLimitsByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery, TDto>, IGetLimitsByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetLimitsByCriteriaQueryHandler(ILimitService service) : base(service)
        {
        }
    }
}
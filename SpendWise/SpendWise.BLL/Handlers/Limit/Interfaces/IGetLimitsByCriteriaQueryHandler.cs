using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetLimitsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
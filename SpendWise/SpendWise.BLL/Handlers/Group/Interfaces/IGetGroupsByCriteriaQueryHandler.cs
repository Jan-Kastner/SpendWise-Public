using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using System.Collections.Generic;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetGroupsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
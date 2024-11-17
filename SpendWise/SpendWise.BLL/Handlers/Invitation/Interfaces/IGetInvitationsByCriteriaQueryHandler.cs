using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;
using System.Collections.Generic;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetInvitationsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
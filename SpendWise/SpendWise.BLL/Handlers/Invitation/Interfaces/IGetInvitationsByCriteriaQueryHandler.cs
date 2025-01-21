using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetInvitationsByCriteriaQueryHandler<TDto> : IGetItemsByCriteriaQueryHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
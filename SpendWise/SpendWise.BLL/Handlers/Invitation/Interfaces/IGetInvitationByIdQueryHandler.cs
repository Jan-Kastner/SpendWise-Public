using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IGetInvitationByIdQueryHandler<TDto> : IGetItemByIdQueryHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery, TDto>
        where TDto : class, IQueryableDto
    {
    }
}
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetInvitationsByCriteriaQueryHandler<TDto> : GetItemsByCriteriaQueryHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery, TDto>, IGetInvitationsByCriteriaQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetInvitationsByCriteriaQueryHandler(IInvitationService service) : base(service)
        {
        }
    }
}
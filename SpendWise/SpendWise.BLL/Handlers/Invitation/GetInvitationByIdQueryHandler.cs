using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class GetInvitationByIdQueryHandler<TDto> : GetItemByIdQueryHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery, TDto>, IGetInvitationByIdQueryHandler<TDto>
        where TDto : class, IQueryableDto
    {
        public GetInvitationByIdQueryHandler(IInvitationService service) : base(service)
        {
        }
    }
}
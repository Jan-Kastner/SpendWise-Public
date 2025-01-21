using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IUpdateInvitationCommandHandler : IUpdateItemCommandHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery>
    {
    }
}
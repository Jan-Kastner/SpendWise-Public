using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class UpdateInvitationCommandHandler : UpdateItemCommandHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery>, IUpdateInvitationCommandHandler
    {
        public UpdateInvitationCommandHandler(IInvitationService service) : base(service)
        {
        }
    }
}
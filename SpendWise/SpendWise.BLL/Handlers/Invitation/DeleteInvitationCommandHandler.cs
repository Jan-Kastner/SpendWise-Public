using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class DeleteInvitationCommandHandler : DeleteItemCommandHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery>, IDeleteInvitationCommandHandler
    {
        public DeleteInvitationCommandHandler(IInvitationService service) : base(service)
        {
        }
    }
}
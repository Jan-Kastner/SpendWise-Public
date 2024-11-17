using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers
{
    public class CreateInvitationCommandHandler : CreateItemCommandHandler<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery>, ICreateInvitationCommandHandler
    {
        public CreateInvitationCommandHandler(IInvitationService service) : base(service)
        {
        }
    }
}
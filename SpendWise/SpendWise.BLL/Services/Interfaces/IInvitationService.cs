using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing invitations.
    /// </summary>
    public interface IInvitationService : IService<InvitationCreateDto, InvitationUpdateDto, IInvitationCriteriaQuery>
    {
    }
}
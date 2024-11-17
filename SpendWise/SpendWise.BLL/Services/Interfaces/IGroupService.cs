using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing groups.
    /// </summary>
    public interface IGroupService : IService<GroupCreateDto, GroupUpdateDto, IGroupCriteriaQuery>
    {
    }
}
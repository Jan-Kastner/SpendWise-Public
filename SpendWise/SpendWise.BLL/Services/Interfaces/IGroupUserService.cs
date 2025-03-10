using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing group users.
    /// </summary>
    internal interface IGroupUserService : IService<GroupUserCreateDto, GroupUserUpdateDto, IGroupUserCriteriaQuery>
    {
    }
}
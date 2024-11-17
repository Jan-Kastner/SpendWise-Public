using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing users.
    /// </summary>
    public interface IUserService : IService<UserCreateDto, UserUpdateDto, IUserCriteriaQuery>
    {
    }
}
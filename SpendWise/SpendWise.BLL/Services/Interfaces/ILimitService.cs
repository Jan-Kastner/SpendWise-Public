using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service managing limits.
    /// </summary>
    public interface ILimitService : IService<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>
    {
    }
}
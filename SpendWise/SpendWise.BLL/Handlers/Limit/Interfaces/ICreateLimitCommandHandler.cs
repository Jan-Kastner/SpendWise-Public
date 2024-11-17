using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    /// <summary>
    /// Interface for handling the create limit command.
    /// </summary>
    public interface ICreateLimitCommandHandler : ICreateItemCommandHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>
    {
    }
}
using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.Handlers.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using System.Threading.Tasks;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IUpdateLimitCommandHandler : IUpdateItemCommandHandler<LimitCreateDto, LimitUpdateDto, ILimitCriteriaQuery>
    {
    }
}
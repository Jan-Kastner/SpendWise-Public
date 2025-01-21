using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface ICreateItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
    {
        Task Handle(CreateCommand<TCreateDto> command);
    }
}
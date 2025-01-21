using SpendWise.BLL.Commands;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Handlers.Interfaces
{
    public interface IDeleteItemCommandHandler<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : class, ICreatableDto
        where TUpdateDto : class, IUpdatableDto
        where TCriteriaQuery : class, ICriteriaQuery<TCriteriaQuery>
    {
        Task Handle(DeleteCommand command);
    }
}
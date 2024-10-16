using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;

namespace SpendWise.BLL.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a generic service managing entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the DTO used for creating entities.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the DTO used for updating entities.</typeparam>
    /// <typeparam name="TCriteriaQuery">The type of the criteria query object.</typeparam>
    public interface IService<TCreateDto, TUpdateDto, TCriteriaQuery>
        where TCreateDto : ICreatableDto
        where TUpdateDto : IUpdatableDto
        where TCriteriaQuery : ICriteriaQuery
    {
        Task CreateAsync(TCreateDto dto);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(TUpdateDto dto);
        Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto;
        Task<IEnumerable<TDto>> GetAsync<TDto>(TCriteriaQuery query) where TDto : class, IQueryableDto;
    }
}
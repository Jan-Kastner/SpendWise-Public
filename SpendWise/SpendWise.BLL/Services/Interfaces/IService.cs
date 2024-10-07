using SpendWise.BLL.DTOs;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Defines a service for creating, updating, and deleting entities.
    /// </summary>
    /// <typeparam name="TCreateDto">The type of the Data Transfer Object (DTO) used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the Data Transfer Object (DTO) used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public interface IService<TCreateDto, TUpdateDto>
        where TCreateDto : ICreatableDto
        where TUpdateDto : IUpdatableDto
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="dto">The DTO used for creating the entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateAsync(TCreateDto dto);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="dto">The DTO used for updating the entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TUpdateDto dto);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);
    }
}
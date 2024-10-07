using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.Entities;
using SpendWise.DAL.UnitOfWork;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Provides base functionality for services that handle creating, updating, and deleting entities.
    /// </summary>
    /// <typeparam name="TDto">The type of the Data Transfer Object (DTO) used for the entity. Must implement <see cref="IDto"/>.</typeparam>
    /// <typeparam name="TEntity">The type of the entity. Must implement <see cref="IEntity"/>.</typeparam>
    /// <typeparam name="TCreateDto">The type of the DTO used for creation. Must implement <see cref="ICreatableDto"/>.</typeparam>
    /// <typeparam name="TUpdateDto">The type of the DTO used for updating. Must implement <see cref="IUpdatableDto"/>.</typeparam>
    public abstract class BaseService<TDto, TEntity, TCreateDto, TUpdateDto> : IService<TCreateDto, TUpdateDto>
        where TDto : class, IDto
        where TEntity : class, IEntity
        where TCreateDto : ICreatableDto
        where TUpdateDto : IUpdatableDto
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TDto, TEntity, TCreateDto, TUpdateDto}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="dto">The DTO used for creating the entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TDto>(dto);
            await _unitOfWork.Repository<TEntity, TDto>().InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="dto">The DTO used for updating the entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(TUpdateDto dto)
        {
            var entity = _mapper.Map<TDto>(dto);
            await _unitOfWork.Repository<TEntity, TDto>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Repository<TEntity, TDto>().DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
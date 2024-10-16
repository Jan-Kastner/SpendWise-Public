using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.DAL.DTOs;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Provides services for managing categories, including creating, updating, deleting, and retrieving categories.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new category asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the category.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(CategoryCreateDto dto)
        {
            var dalDto = _mapper.Map<CategoryDto>(dto);
            await _unitOfWork.CategoryRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a category by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the category to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing category asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the category.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(CategoryUpdateDto dto)
        {
            var dalDto = _mapper.Map<CategoryDto>(dto);
            await _unitOfWork.CategoryRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a category by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="id">The identifier of the category to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the category.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query, typeof(TDto));
            var dalEntity = await _unitOfWork.CategoryRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves categories based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="queryObject">The query object used to filter the categories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the categories.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(ICategoryCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query, typeof(TDto));
            var dalEntities = await _unitOfWork.CategoryRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <param name="dtoType">The type of the DTO.</param>
        /// <returns>The DAL query object.</returns>
        private CategoryQueryObject BuildQueryObject(IIdQuery idQuery, Type dtoType)
        {
            var dalQuery = SetupQueryObjectIncludes(dtoType);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <param name="dtoType">The type of the DTO.</param>
        /// <returns>The DAL query object.</returns>
        private CategoryQueryObject BuildQueryObject(ICategoryCriteriaQuery query, Type dtoType)
        {
            var dalQuery = SetupQueryObjectIncludes(dtoType);

            if (query.Name != null)
                dalQuery = dalQuery.WithName(query.Name);

            if (query.Id.HasValue)
                dalQuery = dalQuery.WithId(query.Id.Value);

            if (query.Description != null)
                dalQuery = dalQuery.WithDescription(query.Description);

            if (query.Color != null)
                dalQuery = dalQuery.WithColor(query.Color);

            if (query.NamePartialMatch != null)
                dalQuery = dalQuery.WithNamePartialMatch(query.NamePartialMatch);

            if (query.NotName != null)
                dalQuery = dalQuery.NotWithName(query.NotName);

            if (query.NotNamePartialMatch != null)
                dalQuery = dalQuery.NotWithNamePartialMatch(query.NotNamePartialMatch);

            if (query.NotDescription != null)
                dalQuery = dalQuery.NotWithDescription(query.NotDescription);

            if (query.NotDescriptionPartialMatch != null)
                dalQuery = dalQuery.NotWithDescriptionPartialMatch(query.NotDescriptionPartialMatch);

            if (query.NotColor != null)
                dalQuery = dalQuery.NotWithColor(query.NotColor);

            if (query.WithoutDescription.HasValue)
            {
                if (query.WithoutDescription.Value)
                    dalQuery = dalQuery.WithoutDescription();
                else
                    dalQuery = dalQuery.NotWithoutDescription();
            }

            if (query.WithoutIcon.HasValue)
            {
                if (query.WithoutIcon.Value)
                    dalQuery = dalQuery.WithoutIcon();
                else
                    dalQuery = dalQuery.NotWithoutIcon();
            }

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the DTO type.
        /// </summary>
        /// <param name="dtoType">The type of the DTO.</param>
        /// <returns>The query object with necessary includes.</returns>
        private CategoryQueryObject SetupQueryObjectIncludes(Type dtoType)
        {
            var dalQuery = new CategoryQueryObject();

            var includeActions = new Dictionary<Type, Action<CategoryQueryObject>>
            {
                { typeof(ITransactionsDto<>), query => query.Relations.IncludeTransactions() }
            };

            foreach (var includeAction in includeActions)
            {
                if (dtoType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == includeAction.Key))
                {
                    Console.WriteLine($"Including {includeAction.Key.Name}.");
                    includeAction.Value(dalQuery);
                }
            }

            return dalQuery;
        }
    }
}
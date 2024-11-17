using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.DAL.Entities;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.QueryObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpendWise.DAL.DTOs;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Provides services for managing limits, including creating, updating, deleting, and retrieving limits.
    /// </summary>
    public class LimitService : ILimitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LimitService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public LimitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new limit asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the limit.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(LimitCreateDto dto)
        {
            var dalDto = _mapper.Map<LimitDto>(dto);
            await _unitOfWork.LimitRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a limit by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the limit to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.LimitRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing limit asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the limit.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(LimitUpdateDto dto)
        {
            var dalDto = _mapper.Map<LimitDto>(dto);
            await _unitOfWork.LimitRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a limit by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the limit to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the limit.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.LimitRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves limits based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the limits.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the limits.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(ILimitCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.LimitRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private LimitQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((ILimitIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private LimitQueryObject BuildQueryObject(ILimitCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((ILimitIncludeQuery)query);

            // Apply filters based on the query object
            if (query.Amount.HasValue)
                dalQuery = dalQuery.WithAmount(query.Amount.Value);

            if (query.NotAmount.HasValue)
                dalQuery = dalQuery.NotWithAmount(query.NotAmount.Value);

            if (query.NoticeType.HasValue)
                dalQuery = dalQuery.WithNoticeType(query.NoticeType.Value);

            if (query.NotNoticeType.HasValue)
                dalQuery = dalQuery.NotWithNoticeType(query.NotNoticeType.Value);

            if (query.GroupUserId.HasValue)
                dalQuery = dalQuery.WithGroupUser(query.GroupUserId.Value);

            if (query.NotGroupUserId.HasValue)
                dalQuery = dalQuery.NotWithGroupUser(query.NotGroupUserId.Value);

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private LimitQueryObject SetupQueryObjectIncludes(ILimitIncludeQuery query)
        {
            var dalQuery = new LimitQueryObject();

            // Iterate through the include actions and apply them if the conditions are met
            foreach (var (condition, action) in IncludeActions)
            {
                if (condition(query))
                {
                    action(dalQuery);
                }
            }

            return dalQuery;
        }

        /// <summary>
        /// Gets the include actions for setting up the query object.
        /// </summary>
        private IEnumerable<(Func<ILimitIncludeQuery, bool> Condition, Action<LimitQueryObject> Action)> IncludeActions =>
            new List<(Func<ILimitIncludeQuery, bool> Condition, Action<LimitQueryObject> Action)>
            {
                // Add include actions
                // Example:
                // (
                //    query => query.IncludeRelatedEntity,
                //    q => q.Relations.IncludeRelatedEntity()
                // )
            };
    }
}
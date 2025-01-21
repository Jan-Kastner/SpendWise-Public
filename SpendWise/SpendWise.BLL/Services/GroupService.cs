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
    /// Provides services for managing groups, including creating, updating, deleting, and retrieving groups.
    /// </summary>
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new group asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the group.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(GroupCreateDto dto)
        {
            var dalDto = _mapper.Map<GroupDto>(dto);
            await _unitOfWork.GroupRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a group by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the group to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.GroupRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing group asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the group.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(GroupUpdateDto dto)
        {
            var dalDto = _mapper.Map<GroupDto>(dto);
            await _unitOfWork.GroupRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a group by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the group to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the group.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.GroupRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves groups based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the groups.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the groups.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(IGroupCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.GroupRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <param name="dtoType">The type of the DTO.</param>
        /// <returns>The DAL query object.</returns>
        private GroupQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((IGroupIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <param name="dtoType">The type of the DTO.</param>
        /// <returns>The DAL query object.</returns>
        private GroupQueryObject BuildQueryObject(IGroupCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((IGroupIncludeQuery)query);

            if (query.Name != null)
                dalQuery = dalQuery.WithName(query.Name);

            if (query.NamePartialMatch != null)
                dalQuery = dalQuery.WithNamePartialMatch(query.NamePartialMatch);

            if (query.NotName != null)
                dalQuery = dalQuery.NotWithName(query.NotName);

            if (query.NotNamePartialMatch != null)
                dalQuery = dalQuery.NotWithNamePartialMatch(query.NotNamePartialMatch);

            if (query.Description != null)
                dalQuery = dalQuery.WithDescription(query.Description);

            if (query.DescriptionPartialMatch != null)
                dalQuery = dalQuery.WithDescriptionPartialMatch(query.DescriptionPartialMatch);

            if (query.NotDescription != null)
                dalQuery = dalQuery.NotWithDescription(query.NotDescription);

            if (query.NotDescriptionPartialMatch != null)
                dalQuery = dalQuery.NotWithDescriptionPartialMatch(query.NotDescriptionPartialMatch);

            if (query.WithDescription.HasValue)
            {
                if (query.WithDescription.Value)
                    dalQuery = dalQuery.NotWithoutDescription();
                else
                    dalQuery = dalQuery.WithoutDescription();
            }

            if (query.InvitationId.HasValue)
                dalQuery = dalQuery.WithInvitation(query.InvitationId.Value);

            if (query.NotInvitationId.HasValue)
                dalQuery = dalQuery.NotWithInvitation(query.NotInvitationId.Value);

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query flags.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private GroupQueryObject SetupQueryObjectIncludes(IGroupIncludeQuery query)
        {
            var dalQuery = new GroupQueryObject();

            // Iterate through the include actions and apply them if the conditions are met
            foreach (var (condition, action) in IncludeActions)
            {
                if (condition(query))
                    action(dalQuery);
            }

            return dalQuery;
        }

        /// <summary>
        /// Gets the include actions for setting up the query object.
        /// </summary>
        private IEnumerable<(Func<IGroupIncludeQuery, bool> Condition, Action<GroupQueryObject> Action)> IncludeActions =>
            new List<(Func<IGroupIncludeQuery, bool> Condition, Action<GroupQueryObject> Action)>
            {
                (
                    query => query.IncludeUser || query.IncludeTransactions || query.IncludeCategories,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeUser()
                ),
                (
                    query => query.IncludeTransactions,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeTransactionGroupUsers().ThenGuTguIncludeTransaction()
                ),
                (
                    query => query.IncludeCategories,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeTransactionGroupUsers().ThenGuTguIncludeTransaction().ThenGuTguTIncludeCategory()
                )
            };
    }
}
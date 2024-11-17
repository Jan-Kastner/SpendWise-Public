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
    /// Provides services for managing invitations, including creating, updating, deleting, and retrieving invitations.
    /// </summary>
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public InvitationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new invitation asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the invitation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(InvitationCreateDto dto)
        {
            var dalDto = _mapper.Map<InvitationDto>(dto);
            await _unitOfWork.InvitationRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an invitation by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the invitation to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.InvitationRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing invitation asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the invitation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(InvitationUpdateDto dto)
        {
            var dalDto = _mapper.Map<InvitationDto>(dto);
            await _unitOfWork.InvitationRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves an invitation by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the invitation to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the invitation.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.InvitationRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves invitations based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the invitations.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the invitations.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(IInvitationCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.InvitationRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private InvitationQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((IInvitationIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private InvitationQueryObject BuildQueryObject(IInvitationCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((IInvitationIncludeQuery)query);

            if (query.SentDate.HasValue)
                dalQuery = dalQuery.WithSentDate(query.SentDate.Value);

            if (query.NotSentDate.HasValue)
                dalQuery = dalQuery.NotWithSentDate(query.NotSentDate.Value);

            if (query.ResponseDate.HasValue)
                dalQuery = dalQuery.WithResponseDate(query.ResponseDate.Value);

            if (query.NotResponseDate.HasValue)
                dalQuery = dalQuery.NotWithResponseDate(query.NotResponseDate.Value);

            if (query.WithoutResponseDate.HasValue)
            {
                if (query.WithoutResponseDate.Value)
                    dalQuery = dalQuery.WithoutResponseDate();
                else
                    dalQuery = dalQuery.NotWithoutResponseDate();
            }

            if (query.IsAccepted.HasValue)
                dalQuery = dalQuery.IsAccepted();

            if (query.NotIsAccepted.HasValue)
                dalQuery = dalQuery.NotIsAccepted();

            if (query.IsPending.HasValue)
                dalQuery = dalQuery.IsPending();

            if (query.NotIsPending.HasValue)
                dalQuery = dalQuery.NotIsPending();

            if (query.SenderId.HasValue)
                dalQuery = dalQuery.WithSender(query.SenderId.Value);

            if (query.NotSenderId.HasValue)
                dalQuery = dalQuery.NotWithSender(query.NotSenderId.Value);

            if (query.ReceiverId.HasValue)
                dalQuery = dalQuery.WithReceiver(query.ReceiverId.Value);

            if (query.NotReceiverId.HasValue)
                dalQuery = dalQuery.NotWithReceiver(query.NotReceiverId.Value);

            if (query.GroupId.HasValue)
                dalQuery = dalQuery.WithGroup(query.GroupId.Value);

            if (query.NotGroupId.HasValue)
                dalQuery = dalQuery.NotWithGroup(query.NotGroupId.Value);

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private InvitationQueryObject SetupQueryObjectIncludes(IInvitationIncludeQuery query)
        {
            var dalQuery = new InvitationQueryObject();

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
        private IEnumerable<(Func<IInvitationIncludeQuery, bool> Condition, Action<InvitationQueryObject> Action)> IncludeActions =>
            new List<(Func<IInvitationIncludeQuery, bool> Condition, Action<InvitationQueryObject> Action)>
            {
                (
                    query => query.IncludeGroup,
                    q => q.Relations.IncludeGroup()
                ),
                (
                    query => query.IncludeSender,
                    q => q.Relations.IncludeSender()
                ),
                (
                    query => query.IncludeReceiver,
                    q => q.Relations.IncludeReceiver()
                ),
                (
                    query => query.IncludeGroupParticipants,
                    q => q.Relations.IncludeGroup().ThenGIncludeGroupUsers().ThenGGuIncludeUser()
                )
            };
    }
}
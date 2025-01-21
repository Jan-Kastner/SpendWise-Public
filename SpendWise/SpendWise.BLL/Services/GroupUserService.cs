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
    /// Provides services for managing group users, including creating, updating, deleting, and retrieving group users.
    /// </summary>
    internal class GroupUserService : IGroupUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public GroupUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new group user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the group user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(GroupUserCreateDto dto)
        {
            var dalDto = _mapper.Map<GroupUserDto>(dto);
            await _unitOfWork.GroupUserRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a group user by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the group user to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.GroupUserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing group user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the group user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(GroupUserUpdateDto dto)
        {
            var dalDto = _mapper.Map<GroupUserDto>(dto);
            await _unitOfWork.GroupUserRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a group user by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the group user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the group user.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.GroupUserRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves group users based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the group users.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the group users.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(IGroupUserCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.GroupUserRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private GroupUserQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((IGroupUserIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private GroupUserQueryObject BuildQueryObject(IGroupUserCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((IGroupUserIncludeQuery)query);

            if (query.GroupId.HasValue)
                dalQuery = dalQuery.WithGroup(query.GroupId.Value);

            if (query.NotGroupId.HasValue)
                dalQuery = dalQuery.NotWithGroup(query.NotGroupId.Value);

            if (query.UserId.HasValue)
                dalQuery = dalQuery.WithUser(query.UserId.Value);

            if (query.NotUserId.HasValue)
                dalQuery = dalQuery.NotWithUser(query.NotUserId.Value);

            if (query.UserName != null)
                dalQuery = dalQuery.WithUserName(query.UserName);

            if (query.UserNamePartialMatch != null)
                dalQuery = dalQuery.WithUserNamePartialMatch(query.UserNamePartialMatch);

            if (query.NotUserName != null)
                dalQuery = dalQuery.NotWithUserName(query.NotUserName);

            if (query.NotUserNamePartialMatch != null)
                dalQuery = dalQuery.NotWithUserNamePartialMatch(query.NotUserNamePartialMatch);

            if (query.UserSurname != null)
                dalQuery = dalQuery.WithUserSurname(query.UserSurname);

            if (query.UserSurnamePartialMatch != null)
                dalQuery = dalQuery.WithUserSurnamePartialMatch(query.UserSurnamePartialMatch);

            if (query.NotUserSurname != null)
                dalQuery = dalQuery.NotWithUserSurname(query.NotUserSurname);

            if (query.NotUserSurnamePartialMatch != null)
                dalQuery = dalQuery.NotWithUserSurnamePartialMatch(query.NotUserSurnamePartialMatch);

            if (query.UserEmail != null)
                dalQuery = dalQuery.WithUserEmail(query.UserEmail);

            if (query.NotUserEmail != null)
                dalQuery = dalQuery.NotWithUserEmail(query.NotUserEmail);

            if (query.UserPassword != null)
                dalQuery = dalQuery.WithUserPassword(query.UserPassword);

            if (query.NotUserPassword != null)
                dalQuery = dalQuery.NotWithUserPassword(query.NotUserPassword);

            if (query.UserDateOfRegistration.HasValue)
                dalQuery = dalQuery.WithUserDateOfRegistration(query.UserDateOfRegistration.Value);

            if (query.NotUserDateOfRegistration.HasValue)
                dalQuery = dalQuery.NotWithUserDateOfRegistration(query.NotUserDateOfRegistration.Value);

            if (query.WithUserPhoto.HasValue)
            {
                if (query.WithUserPhoto.Value)
                    dalQuery = dalQuery.WithUserPhoto();
                else
                    dalQuery = dalQuery.NotWithUserPhoto();
            }

            if (query.WithUserPhoto.HasValue)
            {
                if (query.WithUserPhoto.Value)
                    dalQuery = dalQuery.NotWithoutUserPhoto();
                else
                    dalQuery = dalQuery.WithoutUserPhoto();
            }

            if (query.WithUserEmailConfirmed.HasValue)
            {
                if (query.WithUserEmailConfirmed.Value)
                    dalQuery = dalQuery.WithUserEmailConfirmed();
                else
                    dalQuery = dalQuery.NotWithUserEmailConfirmed();
            }

            if (query.WithUserTwoFactorEnabled.HasValue)
            {
                if (query.WithUserTwoFactorEnabled.Value)
                    dalQuery = dalQuery.WithUserTwoFactorEnabled();
                else
                    dalQuery = dalQuery.NotWithUserTwoFactorEnabled();
            }

            if (query.UserResetPasswordToken != null)
                dalQuery = dalQuery.WithUserResetPasswordToken(query.UserResetPasswordToken);

            if (query.WithoutUserResetPasswordToken.HasValue)
            {
                if (query.WithoutUserResetPasswordToken.Value)
                    dalQuery = dalQuery.WithoutUserResetPasswordToken();
                else
                    dalQuery = dalQuery.NotWithoutUserResetPasswordToken();
            }

            if (query.UserPreferredTheme.HasValue)
                dalQuery = dalQuery.WithUserPreferredTheme(query.UserPreferredTheme.Value);

            if (query.NotUserPreferredTheme.HasValue)
                dalQuery = dalQuery.NotWithUserPreferredTheme(query.NotUserPreferredTheme.Value);

            if (query.UserFullName != null)
                dalQuery = dalQuery.WithUserFullName(query.UserFullName);

            if (query.NotUserFullName != null)
                dalQuery = dalQuery.NotWithUserFullName(query.NotUserFullName);

            if (query.UserEmailDomain != null)
                dalQuery = dalQuery.WithUserEmailDomain(query.UserEmailDomain);

            if (query.NotUserEmailDomain != null)
                dalQuery = dalQuery.NotWithUserEmailDomain(query.NotUserEmailDomain);

            if (query.LimitId.HasValue)
                dalQuery = dalQuery.WithLimit(query.LimitId.Value);

            if (query.NotLimitId.HasValue)
                dalQuery = dalQuery.NotWithLimit(query.NotLimitId.Value);

            if (query.UserSentInvitationId.HasValue)
                dalQuery = dalQuery.WithUserSentInvitation(query.UserSentInvitationId.Value);

            if (query.NotUserSentInvitationId.HasValue)
                dalQuery = dalQuery.NotWithUserSentInvitation(query.NotUserSentInvitationId.Value);

            if (query.UserReceivedInvitationId.HasValue)
                dalQuery = dalQuery.WithUserReceivedInvitation(query.UserReceivedInvitationId.Value);

            if (query.NotUserReceivedInvitationId.HasValue)
                dalQuery = dalQuery.NotWithUserReceivedInvitation(query.NotUserReceivedInvitationId.Value);

            if (query.WithoutLimit.HasValue)
            {
                if (query.WithoutLimit.Value)
                    dalQuery = dalQuery.WithoutLimit();
                else
                    dalQuery = dalQuery.NotWithoutLimit();
            }

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query flags.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private GroupUserQueryObject SetupQueryObjectIncludes(IGroupUserIncludeQuery query)
        {
            var dalQuery = new GroupUserQueryObject();

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
        private IEnumerable<(Func<IGroupUserIncludeQuery, bool> Condition, Action<GroupUserQueryObject> Action)> IncludeActions =>
            new List<(Func<IGroupUserIncludeQuery, bool> Condition, Action<GroupUserQueryObject> Action)>
            {
                (
                    query => query.IncludeTransactions,
                    q => q.Relations.IncludeTransactionGroupUsers().ThenTguIncludeTransaction()
                ),
                (
                    query => query.IncludeUser,
                    q => q.Relations.IncludeUser()
                )
            };
    }
}
using AutoMapper;
using SpendWise.BLL.DTOs;
using SpendWise.BLL.DTOs.Interfaces;
using SpendWise.BLL.Queries.Interfaces;
using SpendWise.BLL.Services.Interfaces;
using SpendWise.DAL.UnitOfWork;
using SpendWise.DAL.QueryObjects;
using SpendWise.DAL.DTOs;
using SpendWise.BLL.Handlers;
using SpendWise.BLL.Mappers;
using SpendWise.BLL.Queries;

namespace SpendWise.BLL.Services
{
    /// <summary>
    /// Provides services for managing users, including creating, updating, deleting, and retrieving users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGroupUserService _groupUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        /// <param name="groupUserService">The service used to manage group users.</param>
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _groupUserService = new GroupUserService(unitOfWork, mapper);
        }

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(UserCreateDto dto)
        {
            var dalDto = _mapper.Map<UserDto>(dto);
            await _unitOfWork.UserRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a user by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the user to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(UserUpdateDto dto)
        {
            var dalDto = _mapper.Map<UserDto>(dto);
            await _unitOfWork.UserRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a user by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the user.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.UserRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves users based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the users.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the users.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(IUserCriteriaQuery query) where TDto : class, IQueryableDto
        {
            if (typeof(TDto).GetInterfaces().Contains(typeof(IRole)))
            {
                return await GetGroupUsersAsync<TDto>(query);
            }
            return await GetUsersAsync<TDto>(query);
        }

        /// <summary>
        /// Retrieves group users based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the group users.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the group users.</returns>
        private async Task<IEnumerable<TDto>> GetGroupUsersAsync<TDto>(IUserCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var groupUserQuery = _mapper.Map<GetGroupUsersByCriteriaQuery>(query);
            var handler = new GetGroupUsersByCriteriaQueryHandler<TDto>(_groupUserService);
            return await handler.Handle(groupUserQuery);
        }

        /// <summary>
        /// Retrieves users based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the users.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the users.</returns>
        private async Task<IEnumerable<TDto>> GetUsersAsync<TDto>(IUserCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.UserRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private UserQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((IUserIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private UserQueryObject BuildQueryObject(IUserCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((IUserIncludeQuery)query);

            if (query.Name != null)
                dalQuery = dalQuery.WithName(query.Name);

            if (query.NotName != null)
                dalQuery = dalQuery.NotWithName(query.NotName);

            if (query.NamePartialMatch != null)
                dalQuery = dalQuery.WithNamePartialMatch(query.NamePartialMatch);

            if (query.NotNamePartialMatch != null)
                dalQuery = dalQuery.NotWithNamePartialMatch(query.NotNamePartialMatch);

            if (query.Surname != null)
                dalQuery = dalQuery.WithSurname(query.Surname);

            if (query.NotSurname != null)
                dalQuery = dalQuery.NotWithSurname(query.NotSurname);

            if (query.SurnamePartialMatch != null)
                dalQuery = dalQuery.WithSurnamePartialMatch(query.SurnamePartialMatch);

            if (query.NotSurnamePartialMatch != null)
                dalQuery = dalQuery.NotWithSurnamePartialMatch(query.NotSurnamePartialMatch);

            if (query.Email != null)
                dalQuery = dalQuery.WithEmail(query.Email);

            if (query.NotEmail != null)
                dalQuery = dalQuery.NotWithEmail(query.NotEmail);

            if (query.PasswordHash != null)
                dalQuery = dalQuery.WithPassword(query.PasswordHash);

            if (query.DateOfRegistration.HasValue)
                dalQuery = dalQuery.WithDateOfRegistration(query.DateOfRegistration.Value);

            if (query.NotDateOfRegistration.HasValue)
                dalQuery = dalQuery.NotWithDateOfRegistration(query.NotDateOfRegistration.Value);

            if (query.WithPhoto.HasValue)
            {
                if (query.WithPhoto.Value)
                    dalQuery = dalQuery.WithPhoto();
                else
                    dalQuery = dalQuery.WithoutPhoto();
            }

            if (query.EmailConfirmed.HasValue)
            {
                if (query.EmailConfirmed.Value)
                    dalQuery = dalQuery.WithEmailConfirmed();
                else
                    dalQuery = dalQuery.WithoutEmailConfirmed();
            }

            if (query.TwoFactorEnabled.HasValue)
            {
                if (query.TwoFactorEnabled.Value)
                    dalQuery = dalQuery.WithTwoFactorEnabled();
                else
                    dalQuery = dalQuery.WithoutTwoFactorEnabled();
            }

            if (query.ResetPasswordToken != null)
                dalQuery = dalQuery.WithResetPasswordToken(query.ResetPasswordToken);

            if (query.PreferredTheme.HasValue)
                dalQuery = dalQuery.WithPreferredTheme(query.PreferredTheme.Value);

            if (query.NotPreferredTheme.HasValue)
                dalQuery = dalQuery.NotWithPreferredTheme(query.NotPreferredTheme.Value);

            if (query.SentInvitationId.HasValue)
                dalQuery = dalQuery.WithSentInvitation(query.SentInvitationId.Value);

            if (query.NotSentInvitationId.HasValue)
                dalQuery = dalQuery.NotWithSentInvitation(query.NotSentInvitationId.Value);

            if (query.ReceivedInvitationId.HasValue)
                dalQuery = dalQuery.WithReceivedInvitation(query.ReceivedInvitationId.Value);

            if (query.NotReceivedInvitationId.HasValue)
                dalQuery = dalQuery.NotWithReceivedInvitation(query.NotReceivedInvitationId.Value);

            if (query.GroupId.HasValue)
                dalQuery = dalQuery.WithGroup(query.GroupId.Value);

            if (query.NotGroupId.HasValue)
                dalQuery = dalQuery.NotWithGroup(query.NotGroupId.Value);

            if (query.FullName != null)
                dalQuery = dalQuery.WithFullName(query.FullName);

            if (query.NotFullName != null)
                dalQuery = dalQuery.NotWithFullName(query.NotFullName);

            if (query.EmailDomain != null)
                dalQuery = dalQuery.WithEmailDomain(query.EmailDomain);

            if (query.NotEmailDomain != null)
                dalQuery = dalQuery.NotWithEmailDomain(query.NotEmailDomain);

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private UserQueryObject SetupQueryObjectIncludes(IUserIncludeQuery query)
        {
            var dalQuery = new UserQueryObject();

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
        private IEnumerable<(Func<IUserIncludeQuery, bool> Condition, Action<UserQueryObject> Action)> IncludeActions =>
            new List<(Func<IUserIncludeQuery, bool> Condition, Action<UserQueryObject> Action)>
            {
                (
                    query => query.IncludeGroupUsers,
                    q => q.Relations.IncludeGroupUsers()
                ),
                (
                    query => query.IncludeSentInvitations,
                    q => q.Relations.IncludeSentInvitations()
                ),
                (
                    query => query.IncludeReceivedInvitations,
                    q => q.Relations.IncludeReceivedInvitations()
                ),
                (
                    query => query.IncludeGroups,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeGroup()
                ),
                (
                    query => query.IncludeGroupParticipants,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeGroup().ThenGuGIncludeGroupUsers().ThenGuGGuIncludeUser()
                ),
                (
                    query => query.IncludeTransactions,
                    q => q.Relations.IncludeGroupUsers().ThenGuIncludeTransactionGroupUsers().ThenGuTguIncludeTransaction()
                )
            };
    }
}
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
    /// Provides services for managing transaction group users, including creating, updating, deleting, and retrieving transaction group users.
    /// </summary>
    internal class TransactionGroupUserService : ITransactionGroupUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionGroupUserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public TransactionGroupUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new transaction group user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the transaction group user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(TransactionGroupUserCreateDto dto)
        {
            var dalDto = _mapper.Map<TransactionGroupUserDto>(dto);
            await _unitOfWork.TransactionGroupUserRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a transaction group user by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the transaction group user to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.TransactionGroupUserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing transaction group user asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the transaction group user.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(TransactionGroupUserUpdateDto dto)
        {
            var dalDto = _mapper.Map<TransactionGroupUserDto>(dto);
            await _unitOfWork.TransactionGroupUserRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a transaction group user by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the transaction group user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the transaction group user.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.TransactionGroupUserRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves transaction group users based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the transaction group users.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the transaction group users.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(ITransactionGroupUserCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.TransactionGroupUserRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private TransactionGroupUserQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((ITransactionGroupUserIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private TransactionGroupUserQueryObject BuildQueryObject(ITransactionGroupUserCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((ITransactionGroupUserIncludeQuery)query);

            if (query.Id.HasValue)
                dalQuery = dalQuery.WithId(query.Id.Value);

            if (query.NotId.HasValue)
                dalQuery = dalQuery.NotWithId(query.NotId.Value);

            if (query.IsRead.HasValue)
                if (query.IsRead.Value)
                    dalQuery = dalQuery.IsRead();
                else
                    dalQuery = dalQuery.IsNotRead();

            if (query.TransactionId.HasValue)
                dalQuery = dalQuery.WithTransaction(query.TransactionId.Value);

            if (query.NotTransactionId.HasValue)
                dalQuery = dalQuery.NotWithTransaction(query.NotTransactionId.Value);

            if (query.UserId.HasValue)
                dalQuery = dalQuery.WithUser(query.UserId.Value);

            if (query.NotUserId.HasValue)
                dalQuery = dalQuery.NotWithUser(query.NotUserId.Value);

            if (query.GroupId.HasValue)
                dalQuery = dalQuery.WithGroup(query.GroupId.Value);

            if (query.NotGroupId.HasValue)
                dalQuery = dalQuery.NotWithGroup(query.NotGroupId.Value);

            if (query.TransactionDate.HasValue)
                dalQuery = dalQuery.WithTransactionDate(query.TransactionDate.Value);

            if (query.NotTransactionDate.HasValue)
                dalQuery = dalQuery.NotWithTransactionDate(query.NotTransactionDate.Value);

            if (query.TransactionDateFrom.HasValue)
                dalQuery = dalQuery.WithTransactionDateFrom(query.TransactionDateFrom.Value);

            if (query.TransactionDateTo.HasValue)
                dalQuery = dalQuery.WithTransactionDateTo(query.TransactionDateTo.Value);

            if (query.TransactionAmount.HasValue)
                dalQuery = dalQuery.WithTransactionAmountEqual(query.TransactionAmount.Value);

            if (query.NotTransactionAmount.HasValue)
                dalQuery = dalQuery.NotWithTransactionAmountEqual(query.NotTransactionAmount.Value);

            if (query.TransactionAmountGreaterThan.HasValue)
                dalQuery = dalQuery.WithTransactionAmountGreaterThan(query.TransactionAmountGreaterThan.Value);

            if (query.NotTransactionAmountGreaterThan.HasValue)
                dalQuery = dalQuery.NotWithTransactionAmountGreaterThan(query.NotTransactionAmountGreaterThan.Value);

            if (query.TransactionAmountLessThan.HasValue)
                dalQuery = dalQuery.WithTransactionAmountLessThan(query.TransactionAmountLessThan.Value);

            if (query.NotTransactionAmountLessThan.HasValue)
                dalQuery = dalQuery.NotWithTransactionAmountLessThan(query.NotTransactionAmountLessThan.Value);

            if (query.TransactionDescription != null)
                dalQuery = dalQuery.WithTransactionDescription(query.TransactionDescription);

            if (query.TransactionDescriptionPartialMatch != null)
                dalQuery = dalQuery.WithTransactionDescriptionPartialMatch(query.TransactionDescriptionPartialMatch);

            if (query.NotTransactionDescription != null)
                dalQuery = dalQuery.NotWithTransactionDescription(query.NotTransactionDescription);

            if (query.NotTransactionDescriptionPartialMatch != null)
                dalQuery = dalQuery.NotWithTransactionDescriptionPartialMatch(query.NotTransactionDescriptionPartialMatch);

            if (query.TransactionType.HasValue)
                dalQuery = dalQuery.WithTransactionType(query.TransactionType.Value);

            if (query.NotTransactionType.HasValue)
                dalQuery = dalQuery.NotWithTransactionType(query.NotTransactionType.Value);

            if (query.TransactionCategoryId.HasValue)
                dalQuery = dalQuery.WithTransactionCategory(query.TransactionCategoryId.Value);

            if (query.NotTransactionCategoryId.HasValue)
                dalQuery = dalQuery.NotWithTransactionCategory(query.NotTransactionCategoryId.Value);

            if (query.WithTransactionCategory.HasValue)
            {
                if (query.WithTransactionCategory.Value)
                    dalQuery = dalQuery.NotWithoutTransactionCategory();
                else
                    dalQuery = dalQuery.WithoutTransactionCategory();
            }

            if (query.WithTransactionDescription.HasValue)
            {
                if (query.WithTransactionDescription.Value)
                    dalQuery = dalQuery.NotWithoutTransactionDescription();
                else
                    dalQuery = dalQuery.WithoutTransactionDescription();
            }

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query flags.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private TransactionGroupUserQueryObject SetupQueryObjectIncludes(ITransactionGroupUserIncludeQuery query)
        {
            var dalQuery = new TransactionGroupUserQueryObject();

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
        private IEnumerable<(Func<ITransactionGroupUserIncludeQuery, bool> Condition, Action<TransactionGroupUserQueryObject> Action)> IncludeActions =>
            new List<(Func<ITransactionGroupUserIncludeQuery, bool> Condition, Action<TransactionGroupUserQueryObject> Action)>
            {
                (
                    query => query.IncludeTransactions,
                    q => q.Relations.IncludeTransaction()
                ),
                (
                    query => query.IncludeCategory,
                    q => q.Relations.IncludeTransaction().ThenTIncludeCategory()
                )
            };
    }
}
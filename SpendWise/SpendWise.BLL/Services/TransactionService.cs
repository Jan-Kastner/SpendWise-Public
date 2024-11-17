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
    /// Provides services for managing transactions, including creating, updating, deleting, and retrieving transactions.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the data layer.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new transaction asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to create the transaction.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateAsync(TransactionCreateDto dto)
        {
            var dalDto = _mapper.Map<TransactionDto>(dto);
            await _unitOfWork.TransactionRepository.InsertAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a transaction by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the transaction to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.TransactionRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing transaction asynchronously.
        /// </summary>
        /// <param name="dto">The DTO used to update the transaction.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(TransactionUpdateDto dto)
        {
            var dalDto = _mapper.Map<TransactionDto>(dto);
            await _unitOfWork.TransactionRepository.UpdateAsync(dalDto);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a transaction by its identifier asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object containing the identifier of the transaction to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the DTO of the transaction.</returns>
        public async Task<TDto> GetByIdAsync<TDto>(IIdQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntity = await _unitOfWork.TransactionRepository.SingleOrDefaultAsync(queryObject);
            return _mapper.Map<TDto>(dalEntity);
        }

        /// <summary>
        /// Retrieves transactions based on a query object asynchronously.
        /// </summary>
        /// <typeparam name="TDto">The type of the DTO to return.</typeparam>
        /// <param name="query">The query object used to filter the transactions.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of DTOs of the transactions.</returns>
        public async Task<IEnumerable<TDto>> GetAsync<TDto>(ITransactionCriteriaQuery query) where TDto : class, IQueryableDto
        {
            var queryObject = BuildQueryObject(query);
            var dalEntities = await _unitOfWork.TransactionRepository.ListAsync(queryObject);
            return _mapper.Map<IEnumerable<TDto>>(dalEntities);
        }

        /// <summary>
        /// Builds a DAL query object based on an ID-based BLL query object.
        /// </summary>
        /// <param name="idQuery">The ID-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private TransactionQueryObject BuildQueryObject(IIdQuery idQuery)
        {
            var dalQuery = SetupQueryObjectIncludes((ITransactionIncludeQuery)idQuery);
            return dalQuery.WithId(idQuery.Id);
        }

        /// <summary>
        /// Builds a DAL query object based on a criteria-based BLL query object.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The DAL query object.</returns>
        private TransactionQueryObject BuildQueryObject(ITransactionCriteriaQuery query)
        {
            var dalQuery = SetupQueryObjectIncludes((ITransactionIncludeQuery)query);

            if (query.Amount.HasValue)
                dalQuery = dalQuery.WithAmount(query.Amount.Value);

            if (query.NotAmount.HasValue)
                dalQuery = dalQuery.NotWithAmount(query.NotAmount.Value);

            if (query.Date.HasValue)
                dalQuery = dalQuery.WithDate(query.Date.Value);

            if (query.NotDate.HasValue)
                dalQuery = dalQuery.NotWithDate(query.NotDate.Value);

            if (query.Description != null)
                dalQuery = dalQuery.WithDescription(query.Description);

            if (query.DescriptionPartialMatch != null)
                dalQuery = dalQuery.WithDescriptionPartialMatch(query.DescriptionPartialMatch);

            if (query.NotDescription != null)
                dalQuery = dalQuery.NotWithDescription(query.NotDescription);

            if (query.NotDescriptionPartialMatch != null)
                dalQuery = dalQuery.NotWithDescriptionPartialMatch(query.NotDescriptionPartialMatch);

            if (query.WithoutDescription.HasValue)
            {
                if (query.WithoutDescription.Value)
                    dalQuery = dalQuery.WithoutDescription();
                else
                    dalQuery = dalQuery.NotWithoutDescription();
            }

            if (query.Type.HasValue)
                dalQuery = dalQuery.WithType(query.Type.Value);

            if (query.NotType.HasValue)
                dalQuery = dalQuery.NotWithType(query.NotType.Value);

            if (query.CategoryId.HasValue)
                dalQuery = dalQuery.WithCategory(query.CategoryId.Value);

            if (query.NotCategoryId.HasValue)
                dalQuery = dalQuery.NotWithCategory(query.NotCategoryId.Value);

            if (query.WithoutCategory.HasValue)
            {
                if (query.WithoutCategory.Value)
                    dalQuery = dalQuery.WithoutCategory();
                else
                    dalQuery = dalQuery.NotWithoutCategory();
            }

            if (query.TransactionGroupUserId.HasValue)
                dalQuery = dalQuery.WithTransactionGroupUser(query.TransactionGroupUserId.Value);

            if (query.NotTransactionGroupUserId.HasValue)
                dalQuery = dalQuery.NotWithTransactionGroupUser(query.NotTransactionGroupUserId.Value);

            return dalQuery;
        }

        /// <summary>
        /// Sets up the query object with necessary includes based on the query.
        /// </summary>
        /// <param name="query">The criteria-based BLL query object.</param>
        /// <returns>The query object with necessary includes.</returns>
        private TransactionQueryObject SetupQueryObjectIncludes(ITransactionIncludeQuery query)
        {
            var dalQuery = new TransactionQueryObject();

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
        private IEnumerable<(Func<ITransactionIncludeQuery, bool> Condition, Action<TransactionQueryObject> Action)> IncludeActions =>
            new List<(Func<ITransactionIncludeQuery, bool> Condition, Action<TransactionQueryObject> Action)>
            {
                (
                    query => query.IncludeCategory,
                    q => q.Relations.IncludeCategory()
                ),
                (
                    query => query.IncludeGroups,
                    q => q.Relations.IncludeTransactionGroupUsers().ThenTguIncludeGroupUser().ThenTguGuIncludeGroup()
                ),
                (
                    query => query.IncludeUser,
                    q => q.Relations.IncludeTransactionGroupUsers().ThenTguIncludeGroupUser().ThenTguGuIncludeUser()
                ),
                (
                    query => query.IncludeParticipants,
                    q => q.Relations.IncludeTransactionGroupUsers().ThenTguIncludeGroupUser().ThenTguGuIncludeGroup().ThenTguGuGIncludeGroupUsers().ThenTguGuGGuIncludeUser()
                )
            };
    }
}
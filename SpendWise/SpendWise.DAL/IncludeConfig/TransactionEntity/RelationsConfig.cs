using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity
{
    public class TransactionEntityRelationsConfig : IThenTguIncludeGroupUser, IIncludeCategory, ITransactionEntityInitialState, IIncludeTransactionGroupUsers, IThenTguGuIncludeUser
{

        private readonly List<string> _includes = new List<string>(); // Stores the includes for related entities

        /// <summary>
        /// Gets the list of includes to be applied to the query.
        /// </summary>
        public virtual List<string> Includes => _includes;

        /// <summary>
        /// Adds an include path to the current query object.
        /// </summary>
        /// <param name="include">The path of the include to be added.</param>
        protected void AddInclude(string include)
        {
            if (!string.IsNullOrWhiteSpace(include) && !_includes.Contains(include))
            {
                _includes.Add(include);
            }
        }

        /// <summary>
        /// Removes an include path from the current query object.
        /// </summary>
        /// <param name="include">The path of the include to be removed.</param>
        protected void RemoveInclude(string include)
        {
            if (_includes.Contains(include))
            {
                _includes.Remove(include);
            }
        }
    
        public ITransactionEntityInitialState TransactionEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public IIncludeCategory IncludeCategory(string path = "Category") {
            AddInclude(path);
            return this;
        }
        public IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenTguIncludeGroupUser ThenTguIncludeGroupUser(string path = "TransactionGroupUsers.GroupUser") {
            AddInclude(path);
            return this;
        }
        public IThenTguGuIncludeUser ThenTguGuIncludeUser(string path = "TransactionGroupUsers.GroupUser.User") {
            AddInclude(path);
            return this;
        }
    }
}

using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity
{
    public class GroupUserEntityRelationsConfig : IThenTguTIncludeCategory, IIncludeGroup, IIncludeTransactionGroupUsers, IIncludeUser, IIncludeLimit, IThenTguIncludeTransaction, IGroupUserEntityInitialState
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
    
        public IGroupUserEntityInitialState GroupUserEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public IIncludeGroup IncludeGroup(string path = "Group") {
            AddInclude(path);
            return this;
        }
        public IIncludeLimit IncludeLimit(string path = "Limit") {
            AddInclude(path);
            return this;
        }
        public IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers") {
            AddInclude(path);
            return this;
        }
        public IIncludeUser IncludeUser(string path = "User") {
            AddInclude(path);
            return this;
        }
        public IThenTguIncludeTransaction ThenTguIncludeTransaction(string path = "TransactionGroupUsers.Transaction") {
            AddInclude(path);
            return this;
        }
        public IThenTguTIncludeCategory ThenTguTIncludeCategory(string path = "TransactionGroupUsers.Transaction.Category") {
            AddInclude(path);
            return this;
        }
    }
}

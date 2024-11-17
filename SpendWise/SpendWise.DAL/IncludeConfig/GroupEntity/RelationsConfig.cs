using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity
{
    public class GroupEntityRelationsConfig : IThenGuTguIncludeTransaction, IThenGuIncludeUser, IIncludeGroupUsers, IThenGuIncludeTransactionGroupUsers, IGroupEntityInitialState
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
    
        public IGroupEntityInitialState GroupEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User") {
            AddInclude(path);
            return this;
        }
        public IThenGuTguIncludeTransaction ThenGuTguIncludeTransaction(string path = "GroupUsers.TransactionGroupUsers.Transaction") {
            AddInclude(path);
            return this;
        }
        public void ThenGuTguTIncludeCategory(string path = "GroupUsers.TransactionGroupUsers.Transaction.Category") {
            AddInclude(path);
        }
    }
}

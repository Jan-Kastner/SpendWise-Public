using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity
{
    public class UserEntityRelationsConfig : IThenGuIncludeTransactionGroupUsers, IUserEntityInitialState, IThenGuIncludeGroup, IThenGuGGuIncludeUser, IIncludeSentInvitations, IIncludeReceivedInvitations, IThenGuTguIncludeTransaction, IThenGuGIncludeGroupUsers, IIncludeGroupUsers
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
    
        public IUserEntityInitialState UserEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public IIncludeGroupUsers IncludeGroupUsers(string path = "GroupUsers") {
            AddInclude(path);
            return this;
        }
        public IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations") {
            AddInclude(path);
            return this;
        }
        public IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations") {
            AddInclude(path);
            return this;
        }
        public IThenGuIncludeGroup ThenGuIncludeGroup(string path = "GroupUsers.Group") {
            AddInclude(path);
            return this;
        }
        public IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenGuGIncludeGroupUsers ThenGuGIncludeGroupUsers(string path = "GroupUsers.Group.GroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenGuTguIncludeTransaction ThenGuTguIncludeTransaction(string path = "GroupUsers.TransactionGroupUsers.Transaction") {
            AddInclude(path);
            return this;
        }
        public IThenGuGGuIncludeUser ThenGuGGuIncludeUser(string path = "GroupUsers.Group.GroupUsers.User") {
            AddInclude(path);
            return this;
        }
    }
}

using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity
{
    public class InvitationEntityRelationsConfig : IIncludeGroup, IIncludeSender, IThenGIncludeGroupUsers, IInvitationEntityInitialState, IIncludeReceiver, IThenGGuIncludeUser
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
    
        public IInvitationEntityInitialState InvitationEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public IIncludeGroup IncludeGroup(string path = "Group") {
            AddInclude(path);
            return this;
        }
        public IIncludeReceiver IncludeReceiver(string path = "Receiver") {
            AddInclude(path);
            return this;
        }
        public IIncludeSender IncludeSender(string path = "Sender") {
            AddInclude(path);
            return this;
        }
        public IThenGIncludeGroupUsers ThenGIncludeGroupUsers(string path = "Group.GroupUsers") {
            AddInclude(path);
            return this;
        }
        public IThenGGuIncludeUser ThenGGuIncludeUser(string path = "Group.GroupUsers.User") {
            AddInclude(path);
            return this;
        }
    }
}

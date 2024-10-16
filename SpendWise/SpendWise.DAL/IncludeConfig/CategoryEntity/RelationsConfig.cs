using SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.CategoryEntity.Interfaces;

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.CategoryEntity
{
    public class CategoryEntityRelationsConfig : ICategoryEntityInitialState
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
    
        public ICategoryEntityInitialState CategoryEntityInitialState(string path = "") {
            AddInclude(path);
            return this;
        }
        public void IncludeTransactions(string path = "Transactions") {
            AddInclude(path);
        }
    }
}

namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.CategoryEntity.Interfaces
{
    public interface ICategoryEntityInitialState
    {
        void IncludeTransactions(string path = "Transactions");
    }
}

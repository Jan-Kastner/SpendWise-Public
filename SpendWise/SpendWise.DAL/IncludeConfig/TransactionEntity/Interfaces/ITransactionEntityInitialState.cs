namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionEntity.Interfaces
{
    public interface ITransactionEntityInitialState
    {
        IIncludeCategory IncludeCategory(string path = "Category");
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
    }
}
